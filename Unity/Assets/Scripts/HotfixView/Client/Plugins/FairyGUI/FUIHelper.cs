using System;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    public static class FUIHelper
    {
        public static void EnableTouchable(GComponent gComponent, bool touchable)
        {
            gComponent.grayed = !touchable;
            gComponent.touchable = touchable;
        }
        
        // 获取 unit 上的 UIPanel
        public static async ETTask<UIPanel> GetUIPanelAsync(Unit unit)
        {
            GameObjectComponent goCom = unit.GetComponent<GameObjectComponent>();
            
            if (goCom.UIPanel == null)
            {
                var ResComponent = unit.Root().GetComponent<ResourcesLoaderComponent>();
                var unitUIPanelPreafb = await ResComponent.LoadAssetAsync<GameObject>("Prefab_UnitUIPanel");
                GameObject uiPanelObj = UnityEngine.Object.Instantiate(unitUIPanelPreafb, goCom.GameObject.transform) as GameObject;
                uiPanelObj.transform.localScale = Vector3.one;
                uiPanelObj.transform.localPosition = Vector3.one;
                goCom.UIPanel = uiPanelObj;
            }

            UIPanel uiPanel = goCom.UIPanel.GetComponent<UIPanel>();
            return uiPanel;
        }
        
        #region AddListnerAsync(this GObject self, Func<ETTask> action)

        public static void AddListnerAsync(this GObject self, Func<ETTask> action)
        {
            async ETTask ClickActionAsync()
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action();
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }
        
        public static void AddListnerAsync<P1>(this GObject self, Func<P1, ETTask> action, P1 p1)
        {
            async ETTask ClickActionAsync()
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(p1);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }
        
        public static void AddListnerAsync<P1, P2>(this GObject self, Func<P1, P2, ETTask> action, P1 p1, P2 p2)
        {
            async ETTask ClickActionAsync()
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(p1, p2);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }
        
        public static void AddListnerAsync<P1, P2 ,P3>(this GObject self, Func<P1, P2, P3, ETTask> action, P1 p1, P2 p2, P3 p3)
        {
            async ETTask ClickActionAsync()
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(p1, p2, p3);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set(() =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync().Coroutine();
            });
        }

        #endregion

        #region AddListner(this GObject self, Action action)

        public static void AddListner(this GObject self, Action action)
        {
            self.onClick.Set(() =>
            {
                action?.Invoke();
            });
        }

        public static void AddListner<P1>(this GObject self, Action<P1> action, P1 p1)
        {
            self.onClick.Set(() =>
            {
                action?.Invoke(p1);
            });
        }
        
        public static void AddListner<P1, P2>(this GObject self, Action<P1, P2> action, P1 p1, P2 p2)
        {
            self.onClick.Set(() =>
            {
                action?.Invoke(p1, p2);
            });
        }
        
        public static void AddListner<P1, P2, P3>(this GObject self, Action<P1, P2, P3> action, P1 p1, P2 p2, P3 p3)
        {
            self.onClick.Set(() =>
            {
                action?.Invoke(p1, p2, p3);
            });
        }

        #endregion

        #region AddListnerAsync(this GObject self, Func<EventContext, ETTask> action)

        public static void AddListnerAsync(this GObject self, Func<EventContext, ETTask> action)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(context);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }

        public static void AddListnerAsync<P1>(this GObject self, Func<EventContext, P1, ETTask> action, P1 p1)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(context, p1);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }
        
        public static void AddListnerAsync<P1, P2>(this GObject self, Func<EventContext, P1, P2, ETTask> action, P1 p1, P2 p2)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(context, p1, p2);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }
        
        public static void AddListnerAsync<P1, P2, P3>(this GObject self, Func<EventContext, P1, P2, P3, ETTask> action, P1 p1, P2 p2, P3 p3)
        {
            async ETTask ClickActionAsync(EventContext context)
            {
                FUIEntitySystemSingleton.Instance.isClicked = true;
                await action(context, p1, p2, p3);
                FUIEntitySystemSingleton.Instance.isClicked = false;
            }

            self.onClick.Set((context) =>
            {
                if (FUIEntitySystemSingleton.Instance.isClicked)
                {
                    return;
                }

                ClickActionAsync(context).Coroutine();
            });
        }

        #endregion

        #region AddListner(this GObject self, Action<EventContext> action)

        public static void AddListner(this GObject self, Action<EventContext> action)
        {
            self.onClick.Set((contex) =>
            {
                action?.Invoke(contex);
            });
        }

        public static void AddListner<P1>(this GObject self, Action<EventContext, P1> action, P1 p1)
        {
            self.onClick.Set((contex) =>
            {
                action?.Invoke(contex, p1);
            });
        }
        
        public static void AddListner<P1, P2>(this GObject self, Action<EventContext, P1, P2> action, P1 p1, P2 p2)
        {
            self.onClick.Set((contex) =>
            {
                action?.Invoke(contex, p1, p2);
            });
        }
        
        public static void AddListner<P1, P2, P3>(this GObject self, Action<EventContext, P1, P2, P3> action, P1 p1, P2 p2, P3 p3)
        {
            self.onClick.Set((contex) =>
            {
                action?.Invoke(contex, p1, p2, p3);
            });
        }

        #endregion
    }
}