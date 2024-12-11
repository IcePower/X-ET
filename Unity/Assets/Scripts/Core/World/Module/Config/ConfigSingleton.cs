using System.Collections.Generic;

namespace ET
{
    public interface IConfigSingleton
    {
        void Resolve(Dictionary<string, IConfigSingleton> _tables);
    }

    public abstract class ConfigSingleton<T>: Singleton<T>, IConfigSingleton where T: ConfigSingleton<T>
    {
        public virtual string ConfigName()
        {
            return string.Empty;
        }

        public abstract void Resolve(Dictionary<string, IConfigSingleton> _tables);
    }
}