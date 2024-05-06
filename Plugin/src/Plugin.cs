using System.Reflection;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using System.IO;
using ExampleEnemy.Configuration;
using LethalLevelLoader;
using System;
using System.Collections.Generic;

namespace ExampleEnemy {
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(LethalLevelLoader.Plugin.ModGUID, BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin {
        internal static new ManualLogSource Logger = null!;
        internal static PluginConfig BoundConfig { get; private set; } = null!;
        public static StringWithRarity DriftwoodGiantTitan = new("Titan", 9999);
        public static int vanillaSpawnWeight = 0;
        public static int customSpawnWeight = 0;

        public static AssetBundle? ModAssets;

        private void Awake() {
            Logger = base.Logger;

            // If you don't want your mod to use a configuration file, you can remove this line, Configuration.cs, and other references.
            BoundConfig = new PluginConfig(base.Config);
            vanillaSpawnWeight = BoundConfig.VanillaSpawnWeight.Value;
            customSpawnWeight = BoundConfig.CustomSpawnWeight.Value;
            AssetBundleLoader.AddOnExtendedModLoadedListener(OnExtendedModRegistered, "Hamunii");
            AssetBundleLoader.AddOnLethalBundleLoadedListener(OnLethalBundleLoaded, "modassets.lethalbundle");
 
            // This should be ran before Network Prefabs are registered.
            InitializeNetworkBehaviours();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        internal static void OnExtendedModRegistered(ExtendedMod extendedMod) {
            if (extendedMod == null) return;
            List<StringWithRarity> ExampleEnemyLevelTag = extendedMod.ExtendedEnemyTypes[0].OutsideLevelMatchingProperties.levelTags;
            ExampleEnemyLevelTag.Add(new StringWithRarity("Vanilla", vanillaSpawnWeight));
            ExampleEnemyLevelTag.Add(new StringWithRarity("Custom", customSpawnWeight));
        }
        internal static void OnLethalBundleLoaded(AssetBundle assetBundle) {
            if (assetBundle == null) return;
        }

        private static void InitializeNetworkBehaviours() {
            // See https://github.com/EvaisaDev/UnityNetcodePatcher?tab=readme-ov-file#preparing-mods-for-patching
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
        } 
    }
}