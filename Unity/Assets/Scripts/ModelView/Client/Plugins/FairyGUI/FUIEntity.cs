using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class FUIEntity : Entity, IAwake, IDestroy
    {
        public bool Visible
        {
            get
            {
                if (this.GComponent == null)
                {
                    return false;
                }
                
                return this.GComponent.visible;
            }

            set
            {
                this.GComponent.visible = value;
            }
        }
        
        public bool IsPreLoad
        {
            get
            {
                return this.GComponent != null;
            }
        }
        
        public PanelId PanelId
        {
            get
            {
                if (this.panelId == PanelId.Invalid)
                {
                    Log.Error("panel id is " + PanelId.Invalid);
                }
                return this.panelId;
            }
            set { this.panelId = value; }
        }
      
        private PanelId panelId = PanelId.Invalid;

        public GComponent GComponent { get; set; }

        public bool DontDestroyOnLoad { get; set; } = false;

        public SystemLanguage Language { get; set; }

        public bool IsUsingStack { get; set; }

        public EntityRef<Entity> Component { get; set; }
        
        public UIPanelType panelType = UIPanelType.Normal;
    }
}