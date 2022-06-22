using FairyGUI;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class FUIEntityAwakeSystem : AwakeSystem<FUIEntity>
    {
        public override void Awake(FUIEntity self)
        {
            self.PanelCoreData = self.AddChild<PanelCoreData>();
        }
    }

    public static class FUIEntitySystem
    {
        public static void SetRoot(this FUIEntity self, GComponent rootGComponent)
        {
            if(self.GComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} GComponent is null!!!");
                return;
            }
            if(rootGComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} rootGComponent is null!!!");
                return;
            }
            rootGComponent.AddChild(self.GComponent);
        }
    }
}