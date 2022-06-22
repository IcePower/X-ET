namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEventAsync<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<ResourcesLoaderComponent>();
            
            await zoneScene.AddComponent<GameResLoaderComponent>().LoadAsync();
            zoneScene.AddComponent<FUIEventComponent>();
            zoneScene.AddComponent<FUIComponent>();
            
            zoneScene.GetComponent<FUIComponent>().ShowPanelAsync(PanelId.SamplePanel).Coroutine();
        }
    }
}