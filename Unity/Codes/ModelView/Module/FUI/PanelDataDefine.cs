namespace ET
{
   public enum UIPanelType
   {
      Normal,    // 普通主界面
      Fixed,     // 固定窗口
      PopUp,     // 弹出窗口
      Other,     //其他窗口
   }

   public class PanelCoreData: Entity, IAwake
   {
      public UIPanelType panelType = UIPanelType.Normal;
   }
}