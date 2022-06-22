using System.Collections.Generic;

namespace ET
{
    public interface IFUILogic
    {
        
    }

    
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(FUIEntity))]
    public class FUIComponent : Entity,IAwake,IDestroy
    {
        public HashSet<PanelId> LoadingPanels              = new HashSet<PanelId>();
        public List<PanelId> VisiblePanelsQueue            = new List<PanelId>();
        public Dictionary<int, FUIEntity> AllPanelsDic     = new Dictionary<int, FUIEntity>();
        public List<PanelId> FUIEntitylistCached            = new List<PanelId>();
        public Dictionary<int, FUIEntity> VisiblePanelsDic = new Dictionary<int, FUIEntity>();
        public Stack<PanelId> HidePanelsStack              = new Stack<PanelId>();
    }
}