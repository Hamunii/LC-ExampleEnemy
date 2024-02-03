using System.Reflection;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using static LethalLib.Modules.Levels;
using static LethalLib.Modules.Enemies;
using BepInEx.Logging;
using System.IO;

namespace ExampleEnemy {
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(LethalLib.Plugin.ModGUID)] 
    [BepInDependency(TestingLib.Plugin.ModGUID, BepInDependency.DependencyFlags.SoftDependency)] 
    public class Plugin : BaseUnityPlugin {
        public static Harmony _harmony;
        public static EnemyType ExampleEnemy;
        internal static new ManualLogSource Logger;

        private void Awake() {
            Logger = base.Logger;
            Assets.PopulateAssets();

            ExampleEnemy = Assets.MainAssetBundle.LoadAsset<EnemyType>("ExampleEnemy");
            var tlTerminalNode = Assets.MainAssetBundle.LoadAsset<TerminalNode>("ExampleEnemyTN");
            var tlTerminalKeyword = Assets.MainAssetBundle.LoadAsset<TerminalKeyword>("ExampleEnemyTK");
            
            // Network Prefabs need to be registered first. See https://docs-multiplayer.unity3d.com/netcode/current/basics/object-spawning/
            NetworkPrefabs.RegisterNetworkPrefab(ExampleEnemy.enemyPrefab);
			RegisterEnemy(ExampleEnemy, 100, LevelTypes.All, SpawnType.Outside, tlTerminalNode, tlTerminalKeyword);
            
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // Required by https://github.com/EvaisaDev/UnityNetcodePatcher maybe?
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

            #if DEBUG
            TestingLib.Patch.All();
            TestingLib.OnEvent.PlayerSpawn += OnEvent_PlayerSpawn;
            #endif
        }
        #if DEBUG
        private void OnEvent_PlayerSpawn()
        {
            TestingLib.Tools.GiveItemToSelf(TestingLib.Lookup.Item.Shovel);
            TestingLib.Tools.GiveItemToSelf(TestingLib.Lookup.Item.Shotgun);
            TestingLib.Tools.TeleportSelf(TestingLib.Tools.TeleportLocation.Outside);
            TestingLib.Tools.SpawnEnemyInFrontOfSelf(ExampleEnemy.enemyName);
        }
        #endif
    }

    public static class Assets {
        public static AssetBundle MainAssetBundle = null;
        public static void PopulateAssets() {
            string sAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            MainAssetBundle = AssetBundle.LoadFromFile(Path.Combine(sAssemblyLocation, "modassets"));
            if (MainAssetBundle == null) {
                Plugin.Logger.LogError("Failed to load custom assets.");
                return;
            }
        }
    }
}