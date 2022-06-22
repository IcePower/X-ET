using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bright.Serialization;

namespace ET
{
    [ObjectSystem]
    public class ConfigAwakeSystem : AwakeSystem<ConfigComponent>
    {
        public override void Awake(ConfigComponent self)
        {
            ConfigComponent.Instance = self;
        }
    }
    
    [ObjectSystem]
    public class ConfigDestroySystem : DestroySystem<ConfigComponent>
    {
        public override void Destroy(ConfigComponent self)
        {
            ConfigComponent.Instance = null;
        }
    }
    
    [FriendClass(typeof(ConfigComponent))]
    public static class ConfigComponentSystem
    {
        public static void Load(this ConfigComponent self, Func<string, ByteBuf> loadFunc)
        {
            self.Tables = new Tables(loadFunc);
        }

        public static void LoadOneConfig(this ConfigComponent self, Type configType, Func<string, ByteBuf> loadFunc)
        {
            self.Tables.LoadOneConfig(configType, loadFunc);
        }
    }
}