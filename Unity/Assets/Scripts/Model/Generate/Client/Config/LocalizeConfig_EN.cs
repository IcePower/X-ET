
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Collections.Generic;


namespace ET
{
    public sealed partial class LocalizeConfig_EN : ALocalizeConfig
    {
        public LocalizeConfig_EN(ByteBuf _buf)  : base(_buf) 
        {
            TextEN = _buf.ReadString();
            PostInit();
        }
    
        public static LocalizeConfig_EN DeserializeLocalizeConfig_EN(ByteBuf _buf)
        {
            return new LocalizeConfig_EN(_buf);
        }
    
        public readonly string TextEN;
       
        public const int __ID__ = 2049582749;
        public override int GetTypeId() => __ID__;
    
        public override void Resolve(Dictionary<string, IConfigSingleton> _tables)
        {
            base.Resolve(_tables);
            
            PostResolve();
        }
    
        public override string ToString()
        {
            return "{ "
            + "key:" + Key + ","
            + "TextEN:" + TextEN + ","
            + "}";
        }
        
        partial void PostInit();
        partial void PostResolve();
    }

}
