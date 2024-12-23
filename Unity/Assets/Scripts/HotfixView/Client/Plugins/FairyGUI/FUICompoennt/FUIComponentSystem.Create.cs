
using System;
using System.Collections.Generic;
using FairyGUI;

namespace ET.Client
{
    [FriendOf(typeof(FUIComponent))]
    public static partial class FUIComponentSystem
    {
        public static async ETTask<T> LoadUIPanel<T>(this FUIComponent self, UIPanel uiPanel, long id = 0) where T : Entity, IAwake, new()
        {
            PanelId panelId = self.GetPanelIdByGeneric<T>();
            FUIEntity fuiEntity = await self.CreatePanelAsync<T>(panelId, id);
            uiPanel.SetUI(fuiEntity.GComponent);
            uiPanel.EntityId = fuiEntity.Id;
            
            fuiEntity.SetPanelType(UIPanelType.Scene);

            return self.GetPanelLogic<T>(id, true);
        }
        
        /// <summary>
        /// 创建一个新界面。适用于会创建多个副本的情况。
        /// </summary>
        public static async ETTask<FUIEntity> CreatePanelAsync<T>(this FUIComponent self, PanelId panelId, long id = 0) where T: Entity, IAwake, new()
        {
            return await self.CreatePanelAsync(typeof(T), panelId, id);
        }
        
        public static async ETTask<FUIEntity> CreatePanelAsync(this FUIComponent self, Type type, PanelId panelId, long id = 0)
        {
            FUIEntity fuiEntity = await self.CreateFUIEntityAsync(type, panelId, id);
            self.SetPanelVisible(fuiEntity);

            return fuiEntity;
        }
        
        private static async ETTask<FUIEntity> CreateFUIEntityAsync(this FUIComponent self, Type type, PanelId panelId, long id = 0)
        {
            CoroutineLock coroutineLock = null;
            try
            {
                coroutineLock = await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoadingPanels, (int)id);
                
                FUIEntity fuiEntity = null;
                if (id != 0)
                {
                    fuiEntity = self.AddChildWithId<FUIEntity>(id, true);
                }
                else
                {
                    fuiEntity = self.AddChild<FUIEntity>(true);
                }
                fuiEntity.PanelId = panelId;
                
                bool isSuccess = await self.LoadFUIEntitysAsync(type, fuiEntity);
                if (isSuccess)
                {
                    return fuiEntity;
                }

                fuiEntity.Dispose();
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                coroutineLock?.Dispose();
            }
        }
        
        /// <summary>
        /// 异步加载
        /// </summary>
        private static async ETTask<bool> LoadFUIEntitysAsync(this FUIComponent self, Type type, FUIEntity fuiEntity)
        {
            if (!FUIEventComponent.Instance.TryGetPanelInfo(type, out PanelInfo panelInfo))
            {
                return false;
            }
            
            // 创建组件
            fuiEntity.GComponent = await self.CreateObjectAsync(panelInfo.PackageName, panelInfo.ComponentName);
            if (fuiEntity.GComponent == null)
            {
                return false;
            }
            
            // 设置根节点
            fuiEntity.SetPanelType(panelInfo.PanelType);

            Entity component = fuiEntity.AddComponent(type);
            fuiEntity.Component = component;

            // 记录fuiEntity
            if (!self.AllPanelsDict.TryGetValue(fuiEntity.PanelId, out var list))
            {
                list = new List<long>();
                self.AllPanelsDict[fuiEntity.PanelId] = list;
            }
            list.Add(fuiEntity.Id);
            
            self.IdToEntity[fuiEntity.Id] = fuiEntity;

            return true;
        }
        
        private static async ETTask<GComponent> CreateObjectAsync(this FUIComponent self, string packageName, string componentName)
        {
            return (await self.Root().GetComponent<FUIAssetComponent>().CreateObjectAsync(packageName, componentName)).asCom;
        }
    }
}