namespace ET
{
    public static class GameResLoaderComponentSystem
    {
        public static async ETTask LoadAsync(this GameResLoaderComponent self)
        {
            if (Define.IsAsync)
            {
                await self.AddPackageAsync();
            }
            else
            {
                self.AddPackage();
            }
        }
        
        private static async ETTask AddPackageAsync(this GameResLoaderComponent self)
        {
            await UIPackageHelper.AddPackageAsync("Common");
            await UIPackageHelper.AddPackageAsync("Sample");

            CommonBinder.BindAll();
            SampleBinder.BindAll();
        }
        
        private static void AddPackage(this GameResLoaderComponent self)
        {
            UIPackageHelper.AddPackage("Assets/Bundles/FUI/Common/Common");
            UIPackageHelper.AddPackage("Assets/Bundles/FUI/Sample/Sample");

            CommonBinder.BindAll();
            SampleBinder.BindAll();
        }
    }
}
