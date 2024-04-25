using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;

namespace ExampleEnemy.Configuration {
    public class PluginConfig
    {
        // For more info on custom configs, see https://lethal.wiki/dev/intermediate/custom-configs
        public ConfigEntry<int> VanillaSpawnWeight;
        public ConfigEntry<int> CustomSpawnWeight;
        public PluginConfig(ConfigFile cfg)
        {
            VanillaSpawnWeight = cfg.Bind("General", "Spawn weight", 20,
                "The spawn chance weight for ExampleEnemy in vanilla moons, relative to other existing enemies.\n" +
                "Goes up from 0, lower is more rare, 100 and up is very common.");
            CustomSpawnWeight = cfg.Bind("General", "Spawn weight", 20,
                "The spawn chance weight for ExampleEnemy in custom moons, relative to other existing enemies.\n" +
                "Goes up from 0, lower is more rare, 100 and up is very common.");
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
}