namespace ET.Client
{
	[Event(SceneType.Demo)]
	public class LoginFinish_RemoveLoginUI: AEvent<Scene, LoginFinish>
	{
		protected override async ETTask Run(Scene scene, LoginFinish args)
		{
			// await UIHelper.Remove(scene, UIType.UILogin);
			scene.GetComponent<FUIComponent>().ClosePanel<LoginPanel>();
			await ETTask.CompletedTask;
		}
	}
}
