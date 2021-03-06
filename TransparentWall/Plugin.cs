﻿using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TransparentWall
{
    class Plugin : IEnhancedPlugin, IPlugin
    {
        public static string PluginName = "TransparentWall";
        public const string VersionNum = "0.1.1";

        public string Name => PluginName;
        public string Version => VersionNum;
        public string[] Filter { get; }

        private static AsyncScenesLoader loader;

        public const string KeyTranparentWall = "TransparentWall";
        public const string KeyHMD = "HMD";
        public const string KeyCameraPlus = "CameraPlus";
        public const string KeyMutiView = "MutiViewFirstPerson";
        public const string KeyDynamicCamera = "DynamicCamera";
        public const string KeyLIV = "LIVCamera";

        public static bool IsTranparentWall
        {
            get
            {
                return ModPrefs.GetBool(Plugin.PluginName, KeyTranparentWall, false);
            }
            set
            {
                ModPrefs.SetBool(Plugin.PluginName, KeyTranparentWall, value);
            }
        }

        public static bool IsHMDOn
        {
            get
            {
                return ModPrefs.GetBool(Plugin.PluginName, KeyHMD, true);
            }
            set
            {
                ModPrefs.SetBool(Plugin.PluginName, KeyHMD, value);
            }
        }

        public static bool IsCameraPlusOn
        {
            get
            {
                return ModPrefs.GetBool(Plugin.PluginName, KeyCameraPlus, true);
            }
            set
            {
                ModPrefs.SetBool(Plugin.PluginName, KeyCameraPlus, value);
            }
        }

        public static bool IsMutiViewFirstPersonOn
        {
            get
            {
                return ModPrefs.GetBool(Plugin.PluginName, KeyMutiView, true);
            }
            set
            {
                ModPrefs.SetBool(Plugin.PluginName, KeyMutiView, value);
            }
        }

        public static bool IsDynamicCameraOn
        {
            get
            {
                return ModPrefs.GetBool(Plugin.PluginName, KeyDynamicCamera, true);
            }
            set
            {
                ModPrefs.SetBool(Plugin.PluginName, KeyDynamicCamera, value);
            }
        }

        public static bool IsLIVCameraOn
        {
            get
            {
                return ModPrefs.GetBool(Plugin.PluginName, KeyLIV, true);
            }
            set
            {
                ModPrefs.SetBool(Plugin.PluginName, KeyLIV, value);
            }
        }


        public void OnApplicationStart()
        {
            CheckForUserDataFolder();
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene scene)
        {
            if (scene.name == "StandardLevelLoader")
            {
                if (!loader)
                    loader = Resources.FindObjectsOfTypeAll<AsyncScenesLoader>().FirstOrDefault();
                loader.loadingDidFinishEvent += OnLoadingDidFinish;
            }
        }
        public void OnLoadingDidFinish()
        {
            new GameObject("TransparentWall").AddComponent<TransparentWall>();
        }

    public void OnLateUpdate()
        {
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }

        private void CheckForUserDataFolder()
        {
            string userDataPath = Environment.CurrentDirectory + "/UserData";
            if (!Directory.Exists(userDataPath))
            {
                Directory.CreateDirectory(userDataPath);
            }
            if ("".Equals(ModPrefs.GetString(Plugin.PluginName, Plugin.KeyTranparentWall, "")))
            {
                ModPrefs.SetBool(Plugin.PluginName, Plugin.KeyTranparentWall, true);
            }
            if ("".Equals(ModPrefs.GetString(Plugin.PluginName, Plugin.KeyHMD, "")))
            {
                ModPrefs.SetBool(Plugin.PluginName, Plugin.KeyHMD, true);
            }
            if ("".Equals(ModPrefs.GetString(Plugin.PluginName, Plugin.KeyCameraPlus, "")))
            {
                ModPrefs.SetBool(Plugin.PluginName, Plugin.KeyCameraPlus, true);
            }
            if ("".Equals(ModPrefs.GetString(Plugin.PluginName, Plugin.KeyMutiView, "")))
            {
                ModPrefs.SetBool(Plugin.PluginName, Plugin.KeyMutiView, true);
            }
            if ("".Equals(ModPrefs.GetString(Plugin.PluginName, Plugin.KeyDynamicCamera, "")))
            {
                ModPrefs.SetBool(Plugin.PluginName, Plugin.KeyDynamicCamera, true);
            }
            if ("".Equals(ModPrefs.GetString(Plugin.PluginName, Plugin.KeyLIV, "")))
            {
                ModPrefs.SetBool(Plugin.PluginName, Plugin.KeyLIV, true);
            }
        }
    }
}
