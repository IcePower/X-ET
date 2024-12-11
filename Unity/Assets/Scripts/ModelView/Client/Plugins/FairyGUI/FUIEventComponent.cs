using System;
using System.Collections.Generic;

namespace ET.Client
{
    public struct PanelInfo
    {
        public PanelId PanelId;
    
        public string PackageName;
    
        public string ComponentName;

        public UIPanelType PanelType;
    }
    
    [Code]
    public class FUIEventComponent : Singleton<FUIEventComponent>, ISingletonAwake
    {
        private readonly Dictionary<PanelId, PanelInfo> PanelIdToInfoDict = new();
        private readonly Dictionary<PanelId, Type> PanelIdToTypeDict = new();
        private readonly Dictionary<Type, PanelInfo> PanelTypeToInfoDict = new();

        public void Awake()
        {
            this.PanelIdToInfoDict.Clear();
            this.PanelTypeToInfoDict.Clear();
            
            foreach (Type v in CodeTypes.Instance.GetTypes(typeof(FUIPanelAttribute)))
            {
                FUIPanelAttribute attr = v.GetCustomAttributes(typeof(FUIPanelAttribute), false)[0] as FUIPanelAttribute;
                this.PanelIdToInfoDict.Add(attr.PanelId, attr.PanelInfo);
                this.PanelIdToTypeDict.Add(attr.PanelId, v);
                this.PanelTypeToInfoDict.Add(v, attr.PanelInfo);
            }
        }

        protected override void Destroy()
        {
            this.PanelIdToInfoDict.Clear();
            this.PanelIdToTypeDict.Clear();
            this.PanelTypeToInfoDict.Clear();
        }

        public bool TryGetPanelInfo<T>(out PanelInfo panelInfo)
        {
            return this.TryGetPanelInfo(typeof(T), out panelInfo);
        }
        
        public bool TryGetPanelInfo(Type type, out PanelInfo panelInfo)
        {
            if (this.PanelTypeToInfoDict.TryGetValue(type, out panelInfo))
            {
                return true;
            }
            
            Log.Error($"panelId : {type.FullName} does not have any panelInfo");
            return false;
        }

        public bool TryGetPanelInfo(PanelId panelId, out PanelInfo panelInfo)
        {
            if (this.PanelIdToInfoDict.TryGetValue(panelId, out panelInfo))
            {
                return true;
            }
            
            Log.Error($"panelId : {panelId} does not have any panelInfo");
            return false;
        }

        public bool TryGetType(PanelId panelId, out Type type)
        {
            if (this.PanelIdToTypeDict.TryGetValue(panelId, out type))
            {
                return true;
            }

            Log.Error($"panelId : {panelId} does not have any type");
            return false;
        }
    }
}