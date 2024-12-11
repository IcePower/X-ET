using FairyGUI;

namespace ET.Client
{
    [FriendOf(typeof(GlobalComponent))]
    public static class FUIRootHelper
    {
        public static void Init()
        {
          
        }
        
        public static GComponent GetTargetRoot(Scene root, UIPanelType type)
        {
            switch (type)
            {
                case UIPanelType.Scene:
                    return null;
                case UIPanelType.Normal:
                    return root.GetComponent<GlobalComponent>().NormalGRoot;
                case UIPanelType.Fixed:
                    return root.GetComponent<GlobalComponent>().FixedGRoot;
                case UIPanelType.PopUp:
                    return root.GetComponent<GlobalComponent>().PopUpGRoot;
                case UIPanelType.Other:
                    return root.GetComponent<GlobalComponent>().OtherGRoot;
                case UIPanelType.Top:
                    return root.GetComponent<GlobalComponent>().TopGRoot;
                default:
                    Log.Error("uiroot type is error: " + type.ToString());
                    return null;
            }
        }
    }
}