//
// using System;
// using System.Collections.Generic;
// using FairyGUI.Dynamic;
//
// namespace ET.Client
// {
//     [Code]
//     public partial class FUIPackageHelper: Singleton<FUIPackageHelper>, ISingletonAwake, IUIPackageHelper
//     {
//         private readonly Dictionary<string, string> PackageIdToNameDict = new();
//         
//         private readonly Dictionary<Type, PanelInfo> PanelTypeToInfoDict = new();
//
//         public void Awake()
//         {
//             this.Init();
//         }
//
//         partial void Init();
//         
//         protected override void Destroy()
//         {
//             this.PackageIdToNameDict.Clear();
//             this.PanelTypeToInfoDict.Clear();
//         }
//         
//         public string GetPackageNameById(string id)
//         {
//             if (this.PackageIdToNameDict.TryGetValue(id, out string packageName))
//             {
//                 return packageName;
//             }
//             
//             Log.Error($"panelId : {id} does not have any packageName");
//             return null;
//         }
// 		
//         public bool TryGetPanelInfo<T>(out PanelInfo panelInfo)
//         {
//             Type type = typeof(T);
//             if (this.PanelTypeToInfoDict.TryGetValue(type, out panelInfo))
//             {
//                 return true;
//             }
//             
//             Log.Error($"panelId : {type.FullName} does not have any panelInfo");
//             return false;
//         }
//     }
// }