
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
    public sealed partial class StartZoneConfig : Luban.BeanBase
    {
        public StartZoneConfig(ByteBuf _buf) 
        {
            Id = _buf.ReadInt();
            DBConnection = _buf.ReadString();
            ZoneType = _buf.ReadInt();
            DBName = _buf.ReadString();
            Desc = _buf.ReadString();
            PostInit();
        }
    
        public static StartZoneConfig DeserializeStartZoneConfig(ByteBuf _buf)
        {
            return new StartZoneConfig(_buf);
        }
    
        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;
        /// <summary>
        /// 数据库地址
        /// </summary>
        public readonly string DBConnection;
        /// <summary>
        /// 分区类型
        /// </summary>
        public readonly int ZoneType;
        /// <summary>
        /// 数据库名
        /// </summary>
        public readonly string DBName;
        /// <summary>
        /// 说明
        /// </summary>
        public readonly string Desc;
       
        public const int __ID__ = -457316368;
        public override int GetTypeId() => __ID__;
    
        public  void Resolve(Dictionary<string, IConfigSingleton> _tables)
        {
            
            
            
            
            
            PostResolve();
        }
    
        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "DBConnection:" + DBConnection + ","
            + "ZoneType:" + ZoneType + ","
            + "DBName:" + DBName + ","
            + "Desc:" + Desc + ","
            + "}";
        }
        
        partial void PostInit();
        partial void PostResolve();
    }

}
