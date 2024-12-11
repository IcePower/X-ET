
using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(FUIComponent))]
    [FriendOf(typeof(FUIComponent))]
    public static partial class FUIComponentSystem
    {
        [EntitySystem]
        public static void Awake(this FUIComponent self)
        {
            UIConfig.defaultFont = "FangYuan";
            FUIBinder.BindAll();
        }
        
        [EntitySystem]
        public static void Destroy(this FUIComponent self)
        {
            self.CloseAllPanel();
        }
        
        public static void Restart(this FUIComponent self)
        {
            self.CloseAllPanel();
            
            FUIBinder.BindAll();
        }
    }
}