
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
    public partial struct vector4
    {
        public vector4(ByteBuf _buf) 
        {
            X = _buf.ReadFloat();
            Y = _buf.ReadFloat();
            Z = _buf.ReadFloat();
            W = _buf.ReadFloat();
            PostInit();
        }
    
        public static vector4 Deserializevector4(ByteBuf _buf)
        {
            return new vector4(_buf);
        }
    
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
        public readonly float W;
       
    
        public  void Resolve(Dictionary<string, IConfigSingleton> _tables)
        {
            
            
            
            
            PostResolve();
        }
    
        public override string ToString()
        {
            return "{ "
            + "x:" + X + ","
            + "y:" + Y + ","
            + "z:" + Z + ","
            + "w:" + W + ","
            + "}";
        }
        
        partial void PostInit();
        partial void PostResolve();
    }

}
