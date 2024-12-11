using FairyGUI;
using UnityEngine;

namespace ET
{
    [FriendOf(typeof(GlobalComponent))]
    public static partial class GlobalComponentSystem
    {
        [EntitySystem]
        public static void Awake(this GlobalComponent self)
        {
            self.Global = GameObject.Find("/Global").transform;
            self.Unit = GameObject.Find("/Global/Unit").transform;
            self.UI = GameObject.Find("/Global/UI").transform;
            self.GlobalConfig = Resources.Load<GlobalConfig>("GlobalConfig");

            self.GRoot = GRoot.inst;
            
            self.NormalGRoot = new GComponent();
            self.NormalGRoot.gameObjectName = "NormalGRoot";
            GRoot.inst.AddChild(self.NormalGRoot);
            
            self.PopUpGRoot = new GComponent();
            self.PopUpGRoot.gameObjectName = "PopUpGRoot";
            GRoot.inst.AddChild(self.PopUpGRoot);
            
            self.FixedGRoot = new GComponent();
            self.FixedGRoot.gameObjectName = "FixedGRoot";
            GRoot.inst.AddChild(self.FixedGRoot);
            
            self.OtherGRoot = new GComponent();
            self.OtherGRoot.gameObjectName = "OtherGRoot";
            GRoot.inst.AddChild(self.OtherGRoot);
            
            self.TopGRoot = new GComponent();
            self.TopGRoot.gameObjectName = "TopGRoot";
            GRoot.inst.AddChild(self.TopGRoot);
        }
    }
    
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent: Entity, IAwake
    {
        public Transform Global;
        public Transform Unit { get; set; }
        public Transform UI;

        public GlobalConfig GlobalConfig { get; set; }
        
        public GComponent GRoot{ get; set; }
        public GComponent NormalGRoot{ get; set; }
        public GComponent PopUpGRoot{ get; set; }
        public GComponent FixedGRoot{ get; set; }
        public GComponent OtherGRoot{ get; set; }
        public GComponent TopGRoot{ get; set; }
    }
}