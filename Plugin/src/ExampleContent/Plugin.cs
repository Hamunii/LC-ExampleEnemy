using System.Reflection;
using UnityEngine;
using BepInEx;
using LethalLib.Modules;
using BepInEx.Logging;
using System.IO;
using ExampleContent.Utils;

namespace ExampleContent;
[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency(LethalLib.Plugin.ModGUID)] 
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger = null!;
    internal static PluginConfig BoundConfig { get; private set; } = null!;

    private void Awake()
    {
        Logger = base.Logger;

        // If you don't want your mod to use a configuration file, you can remove this line, Configuration.cs, and other references.
        BoundConfig = new PluginConfig(base.Config);

        // This should be ran before Network Prefabs are registered.
        InitializeNetworkBehaviours();

        // We load the asset bundle that should be next to our DLL file, with the specified name.
        // You may want to rename your asset bundle from the AssetBundle Browser in order to avoid an issue with
        // asset bundle identifiers being the same between multiple bundles, allowing the loading of only one bundle from one mod.
        // In that case also remember to change the asset bundle copying code in the csproj.user file.
        string enemyBundleName = "enemyassets";
        var EnemyAssets = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Info.Location), "Assets", enemyBundleName));
        if (EnemyAssets == null) {
            Logger.LogError($"Failed to load custom assets.");
            return;
        }

        string itemBundleName = "itemassets";
        var ItemAssets = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Info.Location), "Assets", itemBundleName));
        if (ItemAssets == null) {
            Logger.LogError($"Failed to load custom assets.");
            return;
        }

        RegisterExampleEnemies(EnemyAssets);
        RegisterExampleItems(ItemAssets);

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void RegisterExampleEnemies(AssetBundle ModAssets)
    {
        // We load our assets from our asset bundle. Remember to rename them both here and in our Unity project.
        var ExampleEnemy = ModAssets.LoadAsset<EnemyType>("ExampleEnemyDef");
        var ExampleEnemyTN = ModAssets.LoadAsset<TerminalNode>("ExampleEnemyTN");
        var ExampleEnemyTK = ModAssets.LoadAsset<TerminalKeyword>("ExampleEnemyTK");

        // Network Prefabs need to be registered. See https://docs-multiplayer.unity3d.com/netcode/current/basics/object-spawning/
        // LethalLib registers prefabs on GameNetworkManager.Start.
        NetworkPrefabs.RegisterNetworkPrefab(ExampleEnemy.enemyPrefab);

        // For different ways of registering your enemy, see https://github.com/Hamunii/LC-ExampleEnemy/tree/ExampleContent/Plugin/src/Utils/ContentLoader.cs
        ContentHandler.Instance.RegisterEnemyWithConfig(BoundConfig.ConfigExampleEnemySpawnWeight.Value, ExampleEnemy, ExampleEnemyTN, ExampleEnemyTK, BoundConfig.ConfigPowerLevel.Value, BoundConfig.ConfigMaxSpawnCount.Value);
    }

    private void RegisterExampleItems(AssetBundle ModAssets)
    {
        // We load our assets from our asset bundle. Remember to rename them both here and in our Unity project.
        var ExampleScrap = ModAssets.LoadAsset<Item>("ExampleScrapDef");
        ContentHandler.Instance.RegisterScrapWithConfig(BoundConfig.ConfigExampleScrapSpawnWeight.Value, ExampleScrap);

        var ExampleBigPresent = ModAssets.LoadAsset<Item>("ExampleBigPresentDef");
        ContentHandler.Instance.RegisterScrapWithConfig(BoundConfig.ConfigExampleBigPresentSpawnWeight.Value, ExampleBigPresent);

        var ExampleShovel = ModAssets.LoadAsset<Item>("ExampleShovelDef");
        ContentHandler.Instance.RegisterShopItemWithConfig(BoundConfig.ConfigEnableExampleShovelScrap.Value, ExampleShovel, null!, BoundConfig.ConfigExampleShovelCost.Value, BoundConfig.ConfigExampleShovelSpawnWeight.Value);
    }

    private static void InitializeNetworkBehaviours()
    {
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