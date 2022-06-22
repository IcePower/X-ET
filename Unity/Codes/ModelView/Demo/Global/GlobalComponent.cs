using FairyGUI;
using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent: Entity, IAwake
    {
        public static GlobalComponent Instance;
        
        public Transform Global { get; set; }
        public Transform Unit { get; set; }
        // public Transform UI { get; set; }
        
        public GComponent GRoot{ get; set; }
        public GComponent NormalGRoot{ get; set; }
        public GComponent PopUpGRoot{ get; set; }
        public GComponent FixedGRoot{ get; set; }
        public GComponent OtherGRoot{ get; set; }

    }
}