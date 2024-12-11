﻿using System.Collections.Generic;
using System.IO;
using ET.Client;
using FairyGUI;
using FairyGUIEditor;
using FUIEditor;
using UnityEditor;
using UnityEngine;
using YooAsset;

namespace ET
{
    public enum PlatformType
    {
        None,
        Android,
        IOS,
        Windows,
        MacOS,
        Linux
    }

    public enum ConfigFolder
    {
        Localhost,
        Release,
        RouterTest,
        Benchmark
    }

    /// <summary>
    /// ET菜单顺序
    /// </summary>
    public static class ETMenuItemPriority
    {
        public const int BuildTool = 1001;
        public const int ChangeDefine = 1002;
        public const int Compile = 1003;
        public const int Reload = 1004;
        public const int NavMesh = 1005;
        public const int ServerTools = 1006;
    }

    public class BuildEditor : EditorWindow
    {
        private PlatformType activePlatform;
        private PlatformType platformType;
        private ConfigFolder configFolder;
        private BuildOptions buildOptions;

        private GlobalConfig globalConfig;

        private bool loaded = false;
        private List<string> packageNameList = new();
        private string[] packageNames = { };
        private int packageIndex = 0;

        [MenuItem("ET/Build Tool", false, ETMenuItemPriority.BuildTool)]
        public static void ShowWindow()
        {
            GetWindow<BuildEditor>(DockDefine.Types);
        }

        private void LoadPackages()
        {
            if (Application.isPlaying || loaded)
            {
                return;
            }

            loaded = true;

            EditorToolSet.ReloadPackages();

            packageNameList.Clear();
            packageNameList.Add("全部导出");
            List<UIPackage> pkgs = UIPackage.GetPackages();
            int cnt = pkgs.Count;
            for (int i = 0; i < cnt; i++)
            {
                packageNameList.Add(pkgs[i].name);
            }

            packageNames = packageNameList.ToArray();
        }

        private void ReloadPackages()
        {
            if (!Application.isPlaying)
            {
                loaded = false;
                LoadPackages();
            }
            else
                EditorUtility.DisplayDialog("FairyGUI", "Cannot run in play mode.", "OK");
        }

        private void OnEnable()
        {
            globalConfig = AssetDatabase.LoadAssetAtPath<GlobalConfig>("Assets/Resources/GlobalConfig.asset");

#if UNITY_ANDROID
            activePlatform = PlatformType.Android;
#elif UNITY_IOS
            activePlatform = PlatformType.IOS;
#elif UNITY_STANDALONE_WIN
            activePlatform = PlatformType.Windows;
#elif UNITY_STANDALONE_OSX
            activePlatform = PlatformType.MacOS;
#elif UNITY_STANDALONE_LINUX
            activePlatform = PlatformType.Linux;
#else
            activePlatform = PlatformType.None;
#endif
            platformType = activePlatform;
        }

        private void OnGUI()
        {
            LoadPackages();

            EditorGUILayout.LabelField("PlatformType ");
            this.platformType = (PlatformType)EditorGUILayout.EnumPopup(platformType);

            EditorGUILayout.LabelField("BuildOptions ");
            this.buildOptions = (BuildOptions)EditorGUILayout.EnumFlagsField(this.buildOptions);

            GUILayout.Space(5);

            if (GUILayout.Button("BuildPackage"))
            {
                if (this.platformType == PlatformType.None)
                {
                    Log.Error("please select platform!");
                    return;
                }

                if (this.globalConfig.CodeMode != CodeMode.Client)
                {
                    Log.Error("build package CodeMode must be CodeMode.Client, please select Client");
                    return;
                }

                if (this.globalConfig.EPlayMode == EPlayMode.EditorSimulateMode)
                {
                    Log.Error("build package EPlayMode must not be EPlayMode.EditorSimulateMode, please select HostPlayMode");
                    return;
                }

                if (platformType != activePlatform)
                {
                    switch (EditorUtility.DisplayDialogComplex("Warning!",
                                $"current platform is {activePlatform}, if change to {platformType}, may be take a long time", "change", "cancel",
                                "no change"))
                    {
                        case 0:
                            activePlatform = platformType;
                            break;
                        case 1:
                            return;
                        case 2:
                            platformType = activePlatform;
                            break;
                    }
                }

                BuildHelper.Build(this.platformType, this.buildOptions);
                return;
            }

            if (GUILayout.Button("Proto2CS"))
            {
                ToolsEditor.Proto2CS();
                return;
            }

            EditorGUILayout.BeginHorizontal();
            {
                this.configFolder = (ConfigFolder)EditorGUILayout.EnumPopup(this.configFolder, GUILayout.Width(200f));

                if (GUILayout.Button("ExcelExporter"))
                {
                    ToolsEditor.ExcelExporter(globalConfig.CodeMode, this.configFolder);

                    const string clientProtoDir = "../Unity/Assets/Bundles/Config/GameConfig";
                    if (Directory.Exists(clientProtoDir))
                    {
                        Directory.Delete(clientProtoDir, true);
                    }

                    FileHelper.CopyDirectory("../Config/Excel/c/GameConfig", clientProtoDir);

                    AssetDatabase.Refresh();
                }
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(5);

            // FairyGUI
            GUILayout.Label("");
            GUILayout.Label("FairyGUI");

            GUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            {
                packageIndex = EditorGUILayout.Popup("选择要导出的包名", packageIndex, packageNames, GUILayout.Width(300f));

                if (GUILayout.Button("FUI代码生成"))
                {
                    if (packageIndex == 0)
                    {
                        FUICodeSpawner.FUICodeSpawn(packageNames);
                    }
                    else
                    {
                        FUICodeSpawner.FUICodeSpawn(packageNames[packageIndex], packageNames);
                    }

                    ShowNotification(new GUIContent("FUI代码生成成功！"));
                }

                // 导出新包后，刷新包名。
                if (GUILayout.Button("刷新"))
                {
                    ReloadPackages();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}