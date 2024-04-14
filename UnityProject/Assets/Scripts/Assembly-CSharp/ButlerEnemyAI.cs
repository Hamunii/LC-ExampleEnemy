using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ButlerEnemyAI : EnemyAI
{
	[CompilerGenerated]
	private sealed class _003CButlerBlowUpAndPop_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ButlerEnemyAI _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CButlerBlowUpAndPop_003Ed__76(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCheckForPlayersAnim_003Ed__106 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ButlerEnemyAI _003C_003E4__this;

		public int yRot;

		public float timeToCheck;

		public float timeToCheckB;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCheckForPlayersAnim_003Ed__106(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private Vector3[] lastSeenPlayerPositions;

	private bool[] seenPlayers;

	private float[] timeOfLastSeenPlayers;

	private float timeSinceSeeingMultiplePlayers;

	private float timeSinceCheckingForMultiplePlayers;

	private float timeUntilNextCheck;

	private int playersInVicinity;

	private int currentSpecialAnimation;

	private float timeSinceLastSpecialAnimation;

	private bool doingKillAnimation;

	private int previousBehaviourState;

	private int playersInView;

	private Vector3 agentLocalVelocity;

	public Transform animationContainer;

	private float velX;

	private float velZ;

	private Vector3 previousPosition;

	private PlayerControllerB watchingPlayer;

	public Transform lookTarget;

	public MultiAimConstraint headLookRig;

	public Transform turnCompass;

	public Transform headLookTarget;

	private float sweepFloorTimer;

	private bool isSweeping;

	public AISearchRoutine roamAndSweepFloor;

	public AISearchRoutine hoverAroundTargetPlayer;

	public float idleMovementSpeedBase;

	public float timeSinceChangingItem;

	private float timeSinceHittingPlayer;

	public AudioSource ambience1;

	public AudioSource buzzingAmbience;

	public AudioSource sweepingAudio;

	public AudioClip[] footsteps;

	public AudioClip[] broomSweepSFX;

	private float timeAtLastFootstep;

	private float pingAttentionTimer;

	private int focusLevel;

	private Vector3 pingAttentionPosition;

	private float timeSincePingingAttention;

	private Coroutine checkForPlayersCoroutine;

	private bool hasPlayerInSight;

	private float timeSinceNoticingFirstPlayer;

	private bool lostPlayerInChase;

	private float loseInChaseTimer;

	private bool startedMurderMusic;

	private PlayerControllerB targetedPlayerAlonePreviously;

	private bool checkedForTargetedPlayerPosition;

	private float timeAtLastTargetPlayerSync;

	private PlayerControllerB syncedTargetPlayer;

	private bool trackingTargetPlayerDownToMurder;

	private float premeditationTimeMultiplier;

	private float timeSpentWaitingForPlayer;

	[Space(3f)]
	[Header("Death sequence")]
	private bool startedButlerDeathAnimation;

	public ParticleSystem popParticle;

	public AudioSource popAudio;

	public AudioSource popAudioFar;

	public EnemyType butlerBeesEnemyType;

	private float timeAtLastButlerDamage;

	public ParticleSystem stabBloodParticle;

	private float timeAtLastHeardNoise;

	private bool killedLastTarget;

	private bool startedCrimeSceneTimer;

	private float leaveCrimeSceneTimer;

	private PlayerControllerB lastMurderedTarget;

	public GameObject knifePrefab;

	public AudioSource ambience2;

	public static AudioSource murderMusicAudio;

	public static bool increaseMurderMusicVolume;

	public static float murderMusicVolume;

	public bool madlySearchingForPlayers;

	private float ambushSpeedMeter;

	private float timeSinceStealthStab;

	private float berserkModeTimer;

	private void LateUpdate()
	{
	}

	public override void Start()
	{
	}

	public override void KillEnemy(bool destroy = false)
	{
	}

	[IteratorStateMachine(typeof(_003CButlerBlowUpAndPop_003Ed__76))]
	private IEnumerator ButlerBlowUpAndPop()
	{
		return null;
	}

	public override void HitEnemy(int force = 1, PlayerControllerB playerWhoHit = null, bool playHitSFX = false, int hitID = -1)
	{
	}

	public override void DoAIInterval()
	{
	}

	public void LookForChanceToMurder(float waitForTime = 5f)
	{
	}

	private void ForgetSeenPlayers()
	{
	}

	public override void DetectNoise(Vector3 noisePosition, float noiseLoudness, int timesPlayedInOneSpot = 0, int noiseID = 0)
	{
	}

	public override void Update()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SyncSearchingMadlyServerRpc(bool isSearching)
	{
	}

	[ClientRpc]
	public void SyncSearchingMadlyClientRpc(bool isSearching)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SyncKilledLastTargetServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void SyncKilledLastTargetClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SyncKilledLastTargetFalseServerRpc()
	{
	}

	[ClientRpc]
	public void SyncKilledLastTargetFalseClientRpc()
	{
	}

	[ServerRpc]
	public void SwitchOwnershipAndSetToStateServerRpc(int state, ulong newOwner, float berserkTimer = -1f)
	{
	}

	[ClientRpc]
	public void SwitchOwnershipAndSetToStateClientRpc(int playerVal, int state, float berserkTimer)
	{
	}

	public void SetButlerWalkSpeed()
	{
	}

	private void StartCheckForPlayers()
	{
	}

	[ServerRpc]
	public void SetButlerRunningServerRpc(bool isRunning)
	{
	}

	[ClientRpc]
	public void SetButlerRunningClientRpc(bool isRunning)
	{
	}

	[ServerRpc]
	public void SetSweepingAnimServerRpc(bool sweeping)
	{
	}

	[ClientRpc]
	public void SetSweepingAnimClientRpc(bool sweeping)
	{
	}

	private void CalculateAnimationDirection(float maxSpeed = 1f)
	{
	}

	public void PingAttention(int newFocusLevel, float timeToLook, Vector3 attentionPosition, bool sync = true)
	{
	}

	[ServerRpc]
	public void PingButlerAttentionServerRpc(float timeToLook, Vector3 attentionPosition)
	{
	}

	[ClientRpc]
	public void PingButlerAttentionClientRpc(float timeToLook, Vector3 attentionPosition)
	{
	}

	[ServerRpc]
	public void ButlerNoticePlayerServerRpc()
	{
	}

	[ClientRpc]
	public void ButlerNoticePlayerClientRpc()
	{
	}

	public void TurnAndCheckForPlayers()
	{
	}

	[ServerRpc]
	public void CheckForPlayersServerRpc(float timeToCheck, float timeToCheckB, int yRot)
	{
	}

	[ClientRpc]
	public void CheckForPlayersClientRpc(float timeToCheck, float timeToCheckB, int yRot)
	{
	}

	[IteratorStateMachine(typeof(_003CCheckForPlayersAnim_003Ed__106))]
	private IEnumerator CheckForPlayersAnim(float timeToCheck, float timeToCheckB, int yRot)
	{
		return null;
	}

	private void AnimateLooking()
	{
	}

	private void StartAnimation(int anim)
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void StabPlayerServerRpc(int playerId, bool setBerserkMode)
	{
	}

	[ClientRpc]
	public void StabPlayerClientRpc(int playerId, bool setBerserkMode)
	{
	}

	[ServerRpc]
	public void StartAnimationServerRpc(int animationId)
	{
	}

	[ClientRpc]
	public void StartAnimationClientRpc(int animationId)
	{
	}

	public void CheckLOS()
	{
	}

	[ServerRpc]
	public void SyncTargetServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void SyncTargetClientRpc(int playerId)
	{
	}

	public override void AnimationEventA()
	{
	}

	public override void AnimationEventB()
	{
	}
}
