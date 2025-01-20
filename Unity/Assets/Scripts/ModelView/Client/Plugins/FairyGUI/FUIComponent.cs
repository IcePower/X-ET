using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf]
    public class FUIComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<PanelId, List<long>> AllPanelsDict = new();
        
        /// 当前打开的各个类型的界面
        public MultiMapSet<UIPanelType, PanelId> VisiblePanelTypeDict = new();
        
        /// 隐藏所有界面时临时的存储
        public List<EntityRef<FUIEntity>> VisiblePanelCache = new();
        
        public Stack<EntityRef<FUIEntity>> HidePanelsStack = new();

        public Dictionary<long, EntityRef<FUIEntity>> IdToEntity = new();
    }
}