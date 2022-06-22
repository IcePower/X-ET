using System;
using FairyGUI;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    public static class FUIRootHelper
    {
        public static void Init()
        {
          
        }
        
        public static GComponent GetTargetRoot(UIPanelType type)
        {
            if (type == UIPanelType.Normal)
            {
                return Game.Scene.GetComponent<GlobalComponent>().NormalGRoot;
            }
            else if (type == UIPanelType.Fixed)
            {
                return Game.Scene.GetComponent<GlobalComponent>().FixedGRoot;
            }
            else if (type == UIPanelType.PopUp)
            {
                return Game.Scene.GetComponent<GlobalComponent>().PopUpGRoot;
            }
            else if (type == UIPanelType.Other)
            {
                return Game.Scene.GetComponent<GlobalComponent>().OtherGRoot;
            }

            Log.Error("uiroot type is error: " + type.ToString());
            return null;
        }
    }
}