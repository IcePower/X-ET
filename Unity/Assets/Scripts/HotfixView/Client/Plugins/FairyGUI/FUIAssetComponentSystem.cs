using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Dynamic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(FUIAssetComponent))]
    [FriendOf(typeof (FUIAssetComponent))]
    public static partial class FUIAssetComponentSystem
    {
        [EntitySystem]
        public static void Awake(this FUIAssetComponent self, bool unloadUnusedUIPackageImmediately)
        {
            self.UnloadUnusedUIPackageImmediately = unloadUnusedUIPackageImmediately;
            
            void LoadUIPackageAsyncHandler(string packageName, LoadUIPackageBytesCallback callback)
            {
                self.LoadUIPackageAsyncInner(packageName, callback).Coroutine();
            }

            void LoadTextureAsyncHandler(string packageName, string assetName, string extension, LoadTextureCallback callback)
            {
                self.LoadTextureAsyncInner(assetName, callback).Coroutine();
            }

            void LoadAudioClipAsyncHandler(string packageName, string assetName, string extension, LoadAudioClipCallback callback)
            {
                self.LoadAudioClipAsyncInner(assetName, callback).Coroutine();
            }

            self.Locations = new Dictionary<int, string>();
            var assetLoader = new DelegateUIAssetLoader();
            assetLoader.LoadUIPackageBytesAsyncHandlerImpl = LoadUIPackageAsyncHandler;
            assetLoader.LoadUIPackageBytesHandlerImpl = self.LoadUIPackageSyncInner;
            assetLoader.LoadTextureAsyncHandlerImpl = LoadTextureAsyncHandler;
            assetLoader.UnloadTextureHandlerImpl = self.UnloadAssetInner;
            assetLoader.LoadAudioClipAsyncHandlerImpl = LoadAudioClipAsyncHandler;
            assetLoader.UnloadAudioClipHandlerImpl = self.UnloadAssetInner;

            self.AssetLoader = assetLoader;

            self.PackageHelper = new UIPackageMapping();

            self.UIAssetManager = new UIAssetManager();
            self.UIAssetManager.Initialize(self);
        }
        
        [EntitySystem]
        public static void Destroy(this FUIAssetComponent self)
        {
            self.UIAssetManager.Dispose();
            self.UIAssetManager = null;
            self.AssetLoader = null;

            var resLoaderCom = self.Scene().GetComponent<ResourcesLoaderComponent>();
            foreach (string location in self.Locations.Values)
            {
                resLoaderCom.UnloadAsset(location);
            }
            
            self.Locations.Clear();
        }
        
        public static ETTask<PackageItem> GetItemByURLAsync(this FUIAssetComponent self, string url)
        {
            ETTask<PackageItem> task = ETTask<PackageItem>.Create(true);

            UIPackage.GetItemByURLAsync(url, result =>
            {
                task.SetResult(result);
            });

            return task;
        }
        
        public static PackageItem GetItemByURL(this FUIAssetComponent self, string url)
        {
            PackageItem result = UIPackage.GetItemByURL(url);
            return result;
        }
        
        public static async ETTask<GImage> CreateGImageFromUrlAsync(this FUIAssetComponent self, string url)
        {
            PackageItem packageItem = await self.GetItemByURLAsync(url);
            
            string atlasFile = packageItem.owner.GetAtlasFile(packageItem.id);
            if (string.IsNullOrEmpty(atlasFile))
            {
                return null;
            }
            
            await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<UnityEngine.Object>("LoginPkg_atlas0");

            GObject gObject = await self.CreateObjectFromURLAsync(url);
            return gObject as GImage;
        }
        
        public static ETTask<GObject> CreateObjectFromURLAsync(this FUIAssetComponent self, string url)
        {
            ETTask<GObject> task = ETTask<GObject>.Create(true);
            UIPackage.CreateObjectFromURLAsync(url, result =>
            {
                task.SetResult(result);
            });
            return task;
        }

        public static ETTask<GObject> CreateObjectAsync(this FUIAssetComponent self, string pkgName, string resName)
        {
            ETTask<GObject> task = ETTask<GObject>.Create(true);
            UIPackage.CreateObjectAsync(pkgName, resName, result =>
            {
                task.SetResult(result);
            });
            return task;
        }
        
        public static GObject CreateObject(this FUIAssetComponent self, string pkgName, string resName)
        {
            return UIPackage.CreateObject(pkgName, resName);
        }
        
        public static void UnloadUnusedUIPackages(this FUIAssetComponent self)
        {
            UIPackage.RemoveUnusedPackages();
        }

        private static void LoadUIPackageSyncInner(this FUIAssetComponent self, string packageName, out byte[] bytes, out string assetNamePrefix)
        {
            string location = "{0}{1}".Fmt(packageName, "_fui");
            
            TextAsset descData = self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<TextAsset>(location);

            bytes = descData.bytes;
            assetNamePrefix = packageName;
        }

        private static async ETTask LoadUIPackageAsyncInner(this FUIAssetComponent self, string packageName, LoadUIPackageBytesCallback callback)
        {
            string location = "{0}{1}".Fmt(packageName, "_fui");
            
            var descData = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<TextAsset>(location);
                
            callback(descData.bytes, packageName);
        }

        private static async ETTask LoadTextureAsyncInner(this FUIAssetComponent self, string assetName, LoadTextureCallback callback)
        {
            Texture res = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<Texture>(assetName);

            if (res != null)
            {
                self.Locations[res.GetInstanceID()] = assetName;
            }

            callback(res);
        }

        private static async ETTask LoadAudioClipAsyncInner(this FUIAssetComponent self, string assetName, LoadAudioClipCallback callback)
        {
            AudioClip res = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<AudioClip>(assetName);

            if (res != null)
            {
                self.Locations[res.GetInstanceID()] = assetName;
            }

            callback(res);
        }

        private static void UnloadAssetInner(this FUIAssetComponent self, UnityEngine.Object obj)
        {
            if (obj == null)
            {
                return;
            }

            int instanceId = obj.GetInstanceID();
            if (!self.Locations.TryGetValue(instanceId, out string location))
                return;

            self.Locations.Remove(instanceId);

            self.Scene().GetComponent<ResourcesLoaderComponent>().UnloadAsset(location);
        }
    }
}