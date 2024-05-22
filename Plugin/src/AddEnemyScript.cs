using UnityEngine;
using UnityEngine.AI;

namespace ExampleEnemy;

static class AddEnemyScript
{
    internal static void ExampleEnemyAI(EnemyType enemyType, AssetBundle assets)
    {
        var pref = enemyType.enemyPrefab;
        var ai = pref.AddComponent<ExampleEnemyAI>();

        ai.enemyType = enemyType;

        ai.creatureAnimator = pref.GetComponentInChildren<Animator>();
        ai.creatureVoice = pref.transform.Find("CreatureVoice").GetComponent<AudioSource>();
        ai.creatureSFX = pref.transform.Find("CreatureSFX").GetComponent<AudioSource>();
        ai.eye = pref.transform.Find("Eye");
        ai.dieSFX = assets.LoadAsset<AudioClip>("SkibidiDeath");

        ai.enemyBehaviourStates = new EnemyBehaviourState[20]; // These just need to exist to avoid index out of range

        // AI Calculation / Netcode
        ai.AIIntervalTime = 0.2f;
        ai.agent = pref.GetComponent<NavMeshAgent>();
        ai.updatePositionThreshold = 0.1f;
        ai.syncMovementSpeed = 0.22f;
        ai.enemyHP = 4;

        ai.turnCompass = pref.transform.Find("TurnCompass").GetComponent<Transform>();
        ai.attackArea = pref.transform.Find("AttackArea").GetComponent<Transform>();

        // Other
        pref.GetComponentInChildren<EnemyAICollisionDetect>().mainScript = ai;
    }

    internal static void ClearScript<T>(GameObject gameObject) where T : Component
    {
        var ai = gameObject.GetComponent<T>();
        Object.Destroy(ai);
    }
}