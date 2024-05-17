using UnityEngine;
using UnityEngine.AI;

namespace ExampleEnemy;

static class AddEnemyScript
{
    internal static void ExampleEnemyAI(GameObject g, AssetBundle a)
    {
        var ai = g.AddComponent<ExampleEnemyAI>();

        ai.enemyType = Plugin.ExampleEnemyET;

        ai.creatureAnimator = g.GetComponentInChildren<Animator>();
        ai.creatureVoice = g.transform.Find("CreatureVoice").GetComponent<AudioSource>();
        ai.creatureSFX = g.transform.Find("CreatureSFX").GetComponent<AudioSource>();
        ai.eye = g.transform.Find("Eye");
        ai.dieSFX = a.LoadAsset<AudioClip>("SkibidiDeath");

        ai.enemyBehaviourStates = new EnemyBehaviourState[50]; // These just need to exist to avoid index out of range

        // AI Calculation / Netcode
        ai.AIIntervalTime = 0.2f;
        ai.agent = g.GetComponent<NavMeshAgent>();
        ai.updatePositionThreshold = 0.1f;
        ai.syncMovementSpeed = 0.22f;
        ai.enemyHP = 4;

        ai.turnCompass = g.transform.Find("TurnCompass").GetComponent<Transform>();
        ai.attackArea = g.transform.Find("AttackArea").GetComponent<Transform>();

        // Other
        g.GetComponentInChildren<EnemyAICollisionDetect>().mainScript = ai;
    }
}