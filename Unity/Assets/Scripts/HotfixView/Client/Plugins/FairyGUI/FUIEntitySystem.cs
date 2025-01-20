using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(FUIEntity))]
    [FriendOf(typeof(FUIEntity))]
    public static partial class FUIEntitySystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.FUIEntity self)
        {
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.FUIEntity self)
        {
            self.PanelId = PanelId.Invalid;
            if (self.GComponent != null)
            {
                self.GComponent.Dispose();
                self.GComponent = null;
            }
            
            self.DontDestroyOnLoad = false;
            self.IsUsingStack = false;
        }

        public static void SetPanelType(this FUIEntity self, UIPanelType panelType)
        {
            self.panelType = panelType;
            self.SetRoot(FUIRootHelper.GetTargetRoot(self.Root(), panelType));
        }

        public static UIPanelType GetPanelType(this FUIEntity self)
        {
            return self.panelType;
        }
        
        public static void SetRoot(this FUIEntity self, GComponent rootGComponent)
        {
            if (self.GComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} GComponent is null!!!");
                return;
            }
            if (rootGComponent == null)
            {
                return;
            }
            rootGComponent.AddChild(self.GComponent);
        }
        
        public static void SetDontDestroyOnLoad(this FUIEntity self, bool dontDestroyOnLoad)
        {
            self.DontDestroyOnLoad = dontDestroyOnLoad;
        }
    }
}