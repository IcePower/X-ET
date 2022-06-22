using System;
using FairyGUI;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(ResourcesComponent))]
    public static class UIPackageHelper
    {
#region 同步接口
        public static void AddPackage(string descFilePath)
        {
            UIPackage.AddPackage(descFilePath);
        }

        public static void RemovePackage(string packageName)
        {
            UIPackage.RemovePackage(packageName);

            string resBundleName = packageName.FUIResToBundleName();
            ResourcesComponent.Instance.UnloadBundle(resBundleName);
        }

        public static GComponent CreateObject(string packageName, string componentName)
        {
            return UIPackage.CreateObject(packageName, componentName).asCom;
        }
#endregion

#region 异步接口
        public static async ETTask AddPackageAsync(string packageName)
        {
            if (!Define.IsAsync)
            {
                Log.Error("AddPackageAsync 只能在异步模式下使用！");
                return;
            }

            string descBundleName = packageName.FUIDescToBundleName();
            string resBundleName = packageName.FUIResToBundleName();

            await ResourcesComponent.Instance.LoadBundleAsync(descBundleName);
            await ResourcesComponent.Instance.LoadBundleAsync(resBundleName);

            try
            {
                AssetBundle descBundle = ResourcesComponent.Instance.GetAssetBundle(descBundleName);
                AssetBundle resBundle = ResourcesComponent.Instance.GetAssetBundle(resBundleName);
                UIPackage.AddPackage(descBundle, resBundle);
                await ResourcesComponent.Instance.UnloadBundleAsync(descBundleName);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static async ETTask RemovePackageAsync(string packageName)
        {
            UIPackage.RemovePackage(packageName);

            string resBundleName = packageName.FUIResToBundleName();
            await ResourcesComponent.Instance.UnloadBundleAsync(resBundleName);
        }

        public static async ETTask<GComponent> CreateObjectAsync(string packageName, string componentName)
        {
            ETTask<GComponent> tcs = ETTask<GComponent>.Create(true);
            UIPackage.CreateObjectAsync(packageName, componentName, result =>
            {
                tcs.SetResult(result.asCom);
            });
            var result = await tcs;
            return result;
        }
#endregion
    }
}