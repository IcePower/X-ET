using System;

namespace ET
{
    [ObjectSystem]
    public class FUIEventComponentAwakeSystem : AwakeSystem<FUIEventComponent>
    {
        public override void Awake(FUIEventComponent self)
        {
            FUIEventComponent.Instance = self;
            self.Awake();
        }
    }
    
    [ObjectSystem]
    public class FUIEventComponentDestroySystem : DestroySystem<FUIEventComponent>
    {
        public override void Destroy(FUIEventComponent self)
        {
            self.UIEventHandlers.Clear();
            self.PanelIdInfoDict.Clear();
            self.PanelTypeInfoDict.Clear();
            self.isClicked = false;
            FUIEventComponent.Instance = null;
        }
    }
    
    [FriendClass(typeof(FUIEventComponent))]
    public static class FUIEventComponentSystem
    {
        public static void Awake(this FUIEventComponent self)
        {
            self.UIEventHandlers.Clear();
            foreach (Type v in Game.EventSystem.GetTypes(typeof(FUIEventAttribute)))
            {
                FUIEventAttribute attr = v.GetCustomAttributes(typeof(FUIEventAttribute), false)[0] as FUIEventAttribute;
                self.UIEventHandlers.Add(attr.PanelId, Activator.CreateInstance(v) as IFUIEventHandler);
                self.PanelIdInfoDict.Add(attr.PanelId, attr.PanelInfo);
                self.PanelTypeInfoDict.Add(attr.PanelId.ToString(), attr.PanelInfo);
            }
        }
        
        public static IFUIEventHandler GetUIEventHandler(this FUIEventComponent self, PanelId panelId)
        {
            if (self.UIEventHandlers.TryGetValue(panelId, out IFUIEventHandler handler))
            {
                return handler;
            }
            Log.Error($"panelId : {panelId} is not have any uiEvent");
            return null;
        }

        public static PanelInfo GetPanelInfo(this FUIEventComponent self, PanelId panelId)
        {
            if (self.PanelIdInfoDict.TryGetValue(panelId, out PanelInfo panelInfo))
            {
                return panelInfo;
            }
            Log.Error($"panelId : {panelId} is not have any panelInfo");
            return default;
        }
    }
}