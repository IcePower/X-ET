﻿using System;
using System.Collections.Generic;
using Luban;
#if DOTNET || UNITY_STANDALONE
using System.Threading.Tasks;
#endif

namespace ET
{
    /// <summary>
    /// ConfigLoader会扫描所有的有ConfigAttribute标签的配置,加载进来
    /// </summary>
    public class ConfigLoader : Singleton<ConfigLoader>, ISingletonAwake
    {
        private readonly Dictionary<string, IConfigSingleton> allConfig = new Dictionary<string, IConfigSingleton>(20);

        public struct GetAllConfigBytes
        {
        }

        public struct GetOneConfigBytes
        {
            public string ConfigName;
        }

        public void Awake()
        {
        }

        public async ETTask Reload(Type configType)
        {
            this.allConfig.TryGetValue(configType.Name, out IConfigSingleton oneConfig);
            if (oneConfig != null)
            {
                (oneConfig as ASingleton)?.Dispose();
            }
            
            GetOneConfigBytes getOneConfigBytes = new() { ConfigName = configType.Name };
            ByteBuf oneConfigBytes = await EventSystem.Instance.Invoke<GetOneConfigBytes, ETTask<ByteBuf>>(getOneConfigBytes);
            LoadOneConfig(configType, oneConfigBytes);
        }

        public async ETTask LoadAsync()
        {
            Dictionary<Type, ByteBuf> configBytes = await EventSystem.Instance.Invoke<GetAllConfigBytes, ETTask<Dictionary<Type, ByteBuf>>>(new GetAllConfigBytes());

#if DOTNET || UNITY_STANDALONE
            using ListComponent<Task> listTasks = ListComponent<Task>.Create();

            foreach (Type type in configBytes.Keys)
            {
                ByteBuf oneConfigBytes = configBytes[type];
                Task task = Task.Run(() => LoadOneConfig(type, oneConfigBytes));
                listTasks.Add(task);
            }

            await Task.WhenAll(listTasks.ToArray());
#else
            foreach (Type type in configBytes.Keys)
            {
                LoadOneConfig(type, configBytes[type]);
            }
#endif
            
            foreach (IConfigSingleton category in this.allConfig.Values)
            {
                category.Resolve(allConfig);
            }
        }

        private void LoadOneConfig(Type configType, ByteBuf oneConfigBytes)
        {
            object category = Activator.CreateInstance(configType, oneConfigBytes);
            ASingleton singleton = category as ASingleton;
            World.Instance.AddSingleton(singleton);
            
            this.allConfig[configType.Name] = category as IConfigSingleton;

        }
    }
}