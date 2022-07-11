namespace ET
{
	[FriendClass(typeof(PanelCoreData))]
	[FriendClass(typeof(FUIEntity))]
	[FUIEvent(PanelId.SamplePanel, "Sample", "SamplePanel")]
	public class SampleEventHandler: IFUIEventHandler
	{
		public void OnInitPanelCoreData(FUIEntity fuiEntity)
		{
			fuiEntity.PanelCoreData.panelType = UIPanelType.Normal;
		}

		public void OnInitComponent(FUIEntity fuiEntity)
		{
			fuiEntity.AddComponent<SamplePanel>();
		}

		public void OnRegisterUIEvent(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<SamplePanel>().RegisterUIEvent();
		}

		public void OnShow(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<SamplePanel>().OnShow();
		}

		public void OnHide(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<SamplePanel>().OnHide();
		}

		public void BeforeUnload(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<SamplePanel>().BeforeUnload();
		}
	}
}