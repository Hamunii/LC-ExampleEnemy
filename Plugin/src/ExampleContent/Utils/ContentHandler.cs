using System.Collections.Generic;
using System.Linq;
using LethalLib.Modules;

namespace ExampleContent.Utils;
public class ContentHandler
{
    public static ContentHandler Instance = new();
    internal void RegisterEnemyWithConfig(string configMoonRarity, EnemyType enemy, TerminalNode terminalNode, TerminalKeyword terminalKeyword, float powerLevel, int spawnCount)
    {
        enemy.MaxCount = spawnCount;
        enemy.PowerLevel = powerLevel;
        (Dictionary<Levels.LevelTypes, int> spawnRateByLevelType, Dictionary<string, int> spawnRateByCustomLevelType) = ConfigParsing(configMoonRarity);
        LethalLib.Modules.Enemies.RegisterEnemy(enemy, spawnRateByLevelType, spawnRateByCustomLevelType, terminalNode, terminalKeyword);
    }

    internal void RegisterScrapWithConfig(string configMoonRarity, Item scrap)
    {
        (Dictionary<Levels.LevelTypes, int> spawnRateByLevelType, Dictionary<string, int> spawnRateByCustomLevelType) = ConfigParsing(configMoonRarity);
        LethalLib.Modules.Items.RegisterScrap(scrap, spawnRateByLevelType, spawnRateByCustomLevelType);
    }

    internal void RegisterShopItemWithConfig(bool enabledScrap, Item item, TerminalNode terminalNode, int itemCost, string configMoonRarity)
    {
        LethalLib.Modules.Items.RegisterShopItem(item, null!, null!, terminalNode, itemCost);
        if (enabledScrap)
        {
            RegisterScrapWithConfig(configMoonRarity, item);
        }
    }

    // Optionally, we can list which levels we want to add our enemy to, while also specifying the spawn weight for each.
    /*
    var ExampleEnemyLevelRarities = new Dictionary<Levels.LevelTypes, int> {
        {Levels.LevelTypes.ExperimentationLevel, 10},
        {Levels.LevelTypes.AssuranceLevel, 40},
        {Levels.LevelTypes.VowLevel, 20},
        {Levels.LevelTypes.OffenseLevel, 30},
        {Levels.LevelTypes.MarchLevel, 20},
        {Levels.LevelTypes.RendLevel, 50},
        {Levels.LevelTypes.DineLevel, 25},
        // {Levels.LevelTypes.TitanLevel, 33},
        // {Levels.LevelTypes.All, 30},     // Affects unset values, with lowest priority (gets overridden by Levels.LevelTypes.Modded)
        {Levels.LevelTypes.Modded, 60},     // Affects values for modded moons that weren't specified
    };
    // We can also specify custom level rarities
    var ExampleEnemyCustomLevelRarities = new Dictionary<string, int> {
        {"EGyptLevel", 50},
        {"46 Infernis", 69},
    };
    Below is a config parser that follows this logic but simplifies it into a parser.
    */
    internal (Dictionary<Levels.LevelTypes, int> spawnRateByLevelType, Dictionary<string, int> spawnRateByCustomLevelType) ConfigParsing(string configMoonRarity)
    {
        Dictionary<Levels.LevelTypes, int> spawnRateByLevelType = new();
        Dictionary<string, int> spawnRateByCustomLevelType = new();
        
        foreach (string entry in configMoonRarity.Split(',').Select(s => s.Trim()))
        {
            // Splits the config by the key separator ":".
            string[] entryParts = entry.Split(':');

            if (entryParts.Length != 2) continue;

            // Splits the entry into the name and spawnrate.
            // turns the name lowercase and the spawnrate an int.
            string name = entryParts[0].ToLowerInvariant();
            if (!int.TryParse(entryParts[1], out int spawnrate)) continue;

            // Incase user is more familiar with LLL's "custom" then change that to allow for LL's "modded".
            if (name == "custom")
            {
                name = "modded";
            }

            // Try parsing the name as an LL LevelType
            // If it fails, try appending "Level" to the name and re-attempt parsing
            // If that fails, add the name to the list of custom levels
            if (System.Enum.TryParse(name, true, out Levels.LevelTypes levelType))
            {
                spawnRateByLevelType[levelType] = spawnrate;
            }
            else
            {
                // Try appending "Level" to the name and re-attempt parsing
                string modifiedName = name + "Level";
                if (System.Enum.TryParse(modifiedName, true, out levelType))
                {
                    spawnRateByLevelType[levelType] = spawnrate;
                }
                else
                {
                    spawnRateByCustomLevelType[name] = spawnrate;
                }
            }
        }
        return (spawnRateByLevelType, spawnRateByCustomLevelType);
    }
}