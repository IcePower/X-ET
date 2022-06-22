using System.Collections.Generic;

namespace ET
{
    public interface IConfigCategory
    {
        void Resolve(Dictionary<string, IConfigCategory> _tables);
        
        void TranslateText(System.Func<string, string, string> translator);
    }
}