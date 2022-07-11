namespace ET
{
	public static class SamplePanelSystem
	{
		public static void RegisterUIEvent(this SamplePanel self)
		{
			self.FUILoginPanel.LoginBtn.AddListnerAsync(self.Login);
		}

		public static void OnShow(this SamplePanel self)
		{

		}

		public static void OnHide(this SamplePanel self)
		{

		}

		public static void BeforeUnload(this SamplePanel self)
		{

		}
		
		private static async ETTask Login(this SamplePanel self)
		{
			Log.Info("Login!");
			await TimerComponent.Instance.WaitAsync(1000);
			self.ZoneScene().GetComponent<FUIComponent>().ClosePanel(PanelId.SamplePanel);
		}
	}
}