using System.Collections;
using System.Diagnostics;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

namespace ExampleContent.Enemies;

// You may be wondering, how does the Example Enemy know it is from class ExampleEnemyAI?
// Well, we give it a reference to to this class in the Unity project where we make the asset bundle.
// Asset bundles cannot contain scripts, only references to the script, so our script lives here. It is important to get the
// reference right, or else it will not find this file. See the guide for more information.

// This script also makes use of `nullable`, read more about it here: https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references
public class ExampleEnemyAI : EnemyAI
{
    // `public` fields are set in the UnityProject.
    public Transform turnCompass = null!;
    public Transform attackArea = null!;

    private float timeSinceHittingLocalPlayer = 0;
    private float timeSinceNewRandPos = 0;
    private Vector3 positionRandomness = Vector3.zero;
    private Vector3 StalkPos = Vector3.zero;
    private System.Random enemyRandom = null!;
    // Setting the Hashes for the animator instead of using string's, saves the Animator from doing a step and miniscule performance.
    private static readonly int swingAttackHash = Animator.StringToHash("swingAttack");
    private static readonly int startWalkHash = Animator.StringToHash("startWalk");

    private enum State
    {
        SearchingForPlayer,
        StickingInFrontOfPlayer,
        HeadSwingAttackInProgress,
    }

    [Conditional("DEBUG")]
    private void LogIfDebugBuild(string text)
    {
        Plugin.Logger.LogInfo(text);
    }

    public override void Start()
    {
        base.Start();
        LogIfDebugBuild("Example Enemy Spawned");
        // Use the animator hash for the startWalk animation.
        creatureAnimator.SetTrigger(startWalkHash);
        enemyRandom = new System.Random(StartOfRound.Instance.randomMapSeed + thisEnemyIndex);
        // Make sure it starts with the following state.
        SwitchToBehaviourStateOnLocalClient((int)State.SearchingForPlayer);
        // We make the enemy start searching. This will make it start wandering around.
        StartSearch(transform.position);
    }

    public override void Update()
    {
        base.Update();
        
        if (isEnemyDead)
        {
            return;
        }
        
        timeSinceHittingLocalPlayer += Time.deltaTime;
        timeSinceNewRandPos += Time.deltaTime;
        
        
        if (targetPlayer != null && currentBehaviourStateIndex != (int)State.HeadSwingAttackInProgress)
        {
            turnCompass.LookAt(targetPlayer.gameplayCamera.transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, turnCompass.eulerAngles.y, 0f)), 4f * Time.deltaTime);
        }

        if (stunNormalizedTimer > 0f)
        {
            agent.speed = 0f;
        }
    }

    public override void DoAIInterval()
    {
        base.DoAIInterval();
        if (isEnemyDead || StartOfRound.Instance.allPlayersDead)
        {
            return;
        }

        switch (currentBehaviourStateIndex)
        {
            case (int)State.SearchingForPlayer:
                agent.speed = 3f;
                if (FoundClosestPlayerInRange(25f, 3f))
                {
                    LogIfDebugBuild("Start Target Player");
                    StopSearch(currentSearch);
                    SwitchToBehaviourServerRpc((int)State.StickingInFrontOfPlayer);
                }
                break;
            case (int)State.StickingInFrontOfPlayer:
                agent.speed = 5f;
                // Keep targeting closest player, unless they are over 20 units away and we can't see them.
                if (Vector3.Distance(transform.position, targetPlayer.transform.position) >= 20 && !CheckLineOfSightForPosition(targetPlayer.transform.position))
                {
                    LogIfDebugBuild("Stop Target Player");
                    StartSearch(transform.position);
                    SwitchToBehaviourServerRpc((int)State.SearchingForPlayer);
                    return;
                }
                StickingInFrontOfPlayer();
                break;
            case (int)State.HeadSwingAttackInProgress:
                // We don't care about doing anything here
                break;
        }
    }

    private bool FoundClosestPlayerInRange(float range, float senseRange)
    {
        TargetClosestPlayer(bufferDistance: 1.5f, requireLineOfSight: true);
        if (targetPlayer == null)
        {
            // Couldn't see a player, so we check if a player is in sensing distance instead
            TargetClosestPlayer(bufferDistance: 1.5f, requireLineOfSight: false);
            range = senseRange;
        }
        return targetPlayer != null && Vector3.Distance(transform.position, targetPlayer.transform.position) < range;
    }

    private void StickingInFrontOfPlayer()
    {
        // We only run this method for the host because I'm paranoid about randomness not syncing I guess
        // This is fine because the game does sync the position of the enemy.
        // Also the attack is a ClientRpc so it should always sync
        if (targetPlayer == null || !IsOwner)
        {
            return;
        }

        if (timeSinceNewRandPos > 0.7f)
        {
            timeSinceNewRandPos = 0;
            if (enemyRandom.Next(0, 5) == 0)
            {
                // Attack
                StartCoroutine(SwingAttack());
            }
            else
            {
                // Go in front of player
                positionRandomness = new Vector3(enemyRandom.Next(-2, 2), 0, enemyRandom.Next(-2, 2));
                StalkPos = targetPlayer.transform.position - Vector3.Scale(new Vector3(-5, 0, -5), targetPlayer.transform.forward) + positionRandomness;
            }
            SetDestinationToPosition(StalkPos, checkForPath: false);
        }
    }

    private IEnumerator SwingAttack()
    {
        SwitchToBehaviourServerRpc((int)State.HeadSwingAttackInProgress);
        StalkPos = targetPlayer.transform.position;
        SetDestinationToPosition(StalkPos);
        yield return new WaitForSeconds(0.5f);
        if (isEnemyDead)
        {
            yield break;
        }
        DoAnimationServerRpc(swingAttackHash);
        yield return new WaitForSeconds(0.35f);
        SwingAttackHitServerRpc();
        // In case the player has already gone away, we just yield break (basically same as return, but for IEnumerator)
        if (currentBehaviourStateIndex != (int)State.HeadSwingAttackInProgress)
        {
            yield break;
        }
        SwitchToBehaviourServerRpc((int)State.StickingInFrontOfPlayer);
    }

    public override void OnCollideWithPlayer(Collider other) 
    {
        if (timeSinceHittingLocalPlayer < 1f)
        {
            return;
        }

        PlayerControllerB playerControllerB = other.GetComponent<PlayerControllerB>();
        if (playerControllerB != null && GameNetworkManager.Instance.localPlayerController == playerControllerB)
        {
            LogIfDebugBuild("Example Enemy Collision with Player!");
            timeSinceHittingLocalPlayer = 0f;
            playerControllerB.DamagePlayer(20, callRPC: true);
        }
    }

    public override void HitEnemy(int force = 1, PlayerControllerB? playerWhoHit = null, bool playHitSFX = false, int hitID = -1)
    {
        base.HitEnemy(force, playerWhoHit, playHitSFX, hitID);
        if (isEnemyDead)
        {
            return;
        }

        enemyHP -= force;
        if (IsOwner && enemyHP <= 0)
        {
            // Our death sound will be played through creatureVoice when KillEnemy() is called.
            // KillEnemy() will also attempt to call creatureAnimator.SetTrigger("KillEnemy"),
            // so we don't need to call a death animation ourselves.
            // We need to stop our search coroutine, because the game does not do that by default.
            StopAllCoroutines();
            KillEnemyOnOwnerClient();
        }
    }

    public override void KillEnemy(bool destroy = false)
    {
        base.KillEnemy(destroy);
        creatureVoice.Stop();
        creatureVoice.PlayOneShot(dieSFX);
    }

    [ServerRpc(RequireOwnership = false)]
    private void DoAnimationServerRpc(int animationHash)
    {
        DoAnimationClientRpc(animationHash);
    }

    [ClientRpc]
    private void DoAnimationClientRpc(int animationHash)
    {
        creatureAnimator.SetTrigger(animationHash);
    }

    [ServerRpc(RequireOwnership = false)]
    private void SwingAttackHitServerRpc()
    {
        SwingAttackHitClientRpc();
    }

    [ClientRpc]
    private void SwingAttackHitClientRpc()
    {
        LogIfDebugBuild("SwingAttackHitClientRPC");
        Collider[] hitColliders = Physics.OverlapBox(attackArea.position, attackArea.localScale, attackArea.rotation, StartOfRound.Instance.playersMask);
        if (hitColliders.Length > 0)
        {
            foreach (var player in hitColliders)
            {
                PlayerControllerB playerControllerB = player.GetComponent<PlayerControllerB>();
                if (playerControllerB != null && GameNetworkManager.Instance.localPlayerController == playerControllerB)
                {
                    LogIfDebugBuild("Swing attack hit player!");
                    timeSinceHittingLocalPlayer = 0f;
                    playerControllerB.DamagePlayer(40, callRPC: true);
                }
            }
        }
    }
}