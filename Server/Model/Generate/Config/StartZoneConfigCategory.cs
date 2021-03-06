//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace ET
{
   
public partial class StartZoneConfigCategory: IConfigCategory
{
    public static StartZoneConfigCategory Instance;
    private readonly Dictionary<int, StartZoneConfig> _dataMap;
    private readonly List<StartZoneConfig> _dataList;
    
    public StartZoneConfigCategory(ByteBuf _buf)
    {
        Instance = this;
        _dataMap = new Dictionary<int, StartZoneConfig>();
        _dataList = new List<StartZoneConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            StartZoneConfig _v;
            _v = StartZoneConfig.DeserializeStartZoneConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, StartZoneConfig> GetAll()
    {
        return _dataMap;
    }
    
    public List<StartZoneConfig> DataList => _dataList;

    public StartZoneConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public StartZoneConfig Get(int key) => _dataMap[key];
    public StartZoneConfig this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, IConfigCategory> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}