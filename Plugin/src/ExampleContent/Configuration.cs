using System.Collections.Generic;
using System.Reflection;
using BepInEx.Configuration;

namespace ExampleContent;
public class PluginConfig
{
    // For more info on custom configs, see https://lethal.wiki/dev/intermediate/custom-configs
    public ConfigEntry<string> ConfigExampleScrapSpawnWeight;
    public ConfigEntry<string> ConfigExampleBigPresentSpawnWeight;
    public ConfigEntry<bool> ConfigEnableExampleShovelScrap;
    public ConfigEntry<int> ConfigExampleShovelCost;
    public ConfigEntry<string> ConfigExampleShovelSpawnWeight;
    public ConfigEntry<string> ConfigExampleEnemySpawnWeight;
    public ConfigEntry<float> ConfigPowerLevel;
    public ConfigEntry<int> ConfigMaxSpawnCount;

    public PluginConfig(ConfigFile cfg)
    {
        ConfigEnableExampleShovelScrap = cfg.Bind("ExampleShovel",
                                "Example Shovel | EnableScrap",
                                false,
                                "If true, the Example Shovel will be able to spawn as scrap.");
        ConfigExampleShovelCost = cfg.Bind("ExampleShovel",
                                "Example Shovel | Cost",
                                20,
                                "The cost of the Example Shovel.");
        ConfigExampleShovelSpawnWeight = cfg.Bind("ExampleShovel",
                                "Example Shovel | SpawnWeight",
                                "Modded:69,Vanilla:69",
                                "The spawn chance weight for ExampleItem, relative to other existing items.\n" +
                                "Goes up from 0, lower is more rare, 100 and up is very common. \n" +
                                "Allows the use of Moon names in the config.");
        ConfigExampleScrapSpawnWeight = cfg.Bind("ExampleScrap",
                                "Example Scrap | SpawnWeight",
                                "Modded:69,Vanilla:69",
                                "The spawn chance weight for ExampleItem, relative to other existing items.\n" +
                                "Goes up from 0, lower is more rare, 100 and up is very common. \n" +
                                "Allows the use of Moon names in the config.");
        ConfigExampleBigPresentSpawnWeight = cfg.Bind("ExampleScrap",
                                "Example Scrap | SpawnWeight",
                                "Modded:69,Vanilla:69",
                                "The spawn chance weight for ExampleItem, relative to other existing items.\n" +
                                "Goes up from 0, lower is more rare, 100 and up is very common. \n" +
                                "Allows the use of Moon names in the config.");
        ConfigExampleEnemySpawnWeight = cfg.Bind("ExampleEnemy",
                                "Example Enemy | SpawnWeight",
                                "Modded:69,Vanilla:69",
                                "The spawn chance weight for ExampleEnemy, relative to other existing enemies.\n" +
                                "Goes up from 0, lower is more rare, 100 and up is very common. \n" +
                                "Allows the use of Moon names in the config.");
        ConfigPowerLevel = cfg.Bind("ExampleEnemy",
                                "Example Enemy | PowerLevel",
                                1.0f,
                                "The power level of the ExampleEnemy.");
        ConfigMaxSpawnCount = cfg.Bind("ExampleEnemy",
                                "Example Enemy | Max SpawnCount",
                                3,
                                "The max spawn count of the ExampleEnemy.");
        ClearUnusedEntries(cfg);
    }

    private void ClearUnusedEntries(ConfigFile cfg) {
        // Normally, old unused config entries don't get removed, so we do it with this piece of code. Credit to Kittenji.
        PropertyInfo orphanedEntriesProp = cfg.GetType().GetProperty("OrphanedEntries", BindingFlags.NonPublic | BindingFlags.Instance);
        var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(cfg, null);
        orphanedEntries.Clear(); // Clear orphaned entries (Unbinded/Abandoned entries)
        cfg.Save(); // Save the config file to save these changes
    }
}