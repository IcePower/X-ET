namespace ET
{
    [ComponentOf(typeof(FUIEntity))]
    public class SamplePanel : Entity, IAwake
    {
        public FUI_SamplePanel FUILoginPanel
        {
            get => (FUI_SamplePanel)this.GetParent<FUIEntity>().GComponent;
        } 
    }
}