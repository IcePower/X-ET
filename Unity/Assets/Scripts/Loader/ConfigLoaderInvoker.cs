using System;
using System.Collections.Generic;
using System.IO;
using Luban;
using UnityEngine;

namespace ET
{
    [Invoke]
    public class GetAllConfigBytes: AInvokeHandler<ConfigLoader.GetAllConfigBytes, ETTask<Dictionary<Type, ByteBuf>>>
    {
        public override async ETTask<Dictionary<Type, ByteBuf>> Handle(ConfigLoader.GetAllConfigBytes args)
        {
            Dictionary<Type, ByteBuf> output = new Dictionary<Type, ByteBuf>();
            HashSet<Type> configTypes = CodeTypes.Instance.GetTypes(typeof (ConfigAttribute));
            
            if (Define.IsEditor)
            {
                string ct = "cs";
                GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
                CodeMode codeMode = globalConfig.CodeMode;
                switch (codeMode)
                {
                    case CodeMode.Client:
                        ct = "c";
                        break;
                    case CodeMode.Server:
                        ct = "s";
                        break;
                    case CodeMode.ClientServer:
                        ct = "cs";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                List<string> startConfigs = new List<string>()
                {
                    "StartMachineConfigCategory", 
                    "StartProcessConfigCategory", 
                    "StartSceneConfigCategory", 
                    "StartZoneConfigCategory",
                };
                foreach (Type configType in configTypes)
                {
                    string configFilePath;
                    if (startConfigs.Contains(configType.Name))
                    {
                        configFilePath = $"../Config/Excel/{ct}/{Options.Instance.StartConfig}/{configType.Name}.bytes";
                    }
                    else
                    {
                        configFilePath = $"../Config/Excel/{ct}/GameConfig/{configType.Name}.bytes";
                    }
                    output[configType] = new ByteBuf(File.ReadAllBytes(configFilePath));
                }
            }
            else
            {
                foreach (Type type in configTypes)
                {
                    // TextAsset v = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>($"Assets/Bundles/Config/{type.Name}.bytes");
                    // output[type] = v.bytes;

                    TextAsset textAsset = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(type.Name);
                    output[type] = new ByteBuf(textAsset.bytes);
                }
            }

            return output;
        }
    }
    
    [Invoke]
    public class GetOneConfigBytes: AInvokeHandler<ConfigLoader.GetOneConfigBytes, ETTask<byte[]>>
    {
        public override async ETTask<byte[]> Handle(ConfigLoader.GetOneConfigBytes args)
        {
            string ct = "cs";
            GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
            CodeMode codeMode = globalConfig.CodeMode;
            switch (codeMode)
            {
                case CodeMode.Client:
                    ct = "c";
                    break;
                case CodeMode.Server:
                    ct = "s";
                    break;
                case CodeMode.ClientServer:
                    ct = "cs";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            List<string> startConfigs = new List<string>()
            {
                "StartMachineConfigCategory", 
                "StartProcessConfigCategory", 
                "StartSceneConfigCategory", 
                "StartZoneConfigCategory",
            };

            string configName = args.ConfigName;
                
            string configFilePath;
            if (startConfigs.Contains(configName))
            {
                configFilePath = $"../Config/Excel/{ct}/{Options.Instance.StartConfig}/{configName}.bytes";    
            }
            else
            {
                configFilePath = $"../Config/Excel/{ct}/{configName}.bytes";
            }

            await ETTask.CompletedTask;
            return File.ReadAllBytes(configFilePath);
        }
    }
}