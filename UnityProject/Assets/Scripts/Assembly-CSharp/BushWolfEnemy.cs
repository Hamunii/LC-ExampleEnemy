using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BushWolfEnemy : EnemyAI, IVisibleThreat
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass141_0
	{
		public float time;

		public PlayerControllerB player;

		internal bool _003CKillAnimationOnPlayer_003Eb__0()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CKillAnimationOnPlayer_003Ed__141 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerControllerB player;

		private _003C_003Ec__DisplayClass141_0 _003C_003E8__1;

		public BushWolfEnemy _003C_003E4__this;

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
		public _003CKillAnimationOnPlayer_003Ed__141(int _003C_003E1__state)
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

	[Header("Bush Wolf Variables")]
	public float changeNestRangeSpeed;

	public float dragForce;

	public float nestRange;

	private float baseNestRange;

	public float attackDistance;

	private float baseAttackDistance;

	public float speedMultiplier;

	[Space(5f)]
	public Transform[] proceduralBodyTargets;

	public Transform[] IKTargetContainers;

	private float resetIKOffsetsInterval;

	private RaycastHit hit;

	public bool hideBodyOnTerrain;

	private int previousState;

	private Collider[] nearbyColliders;

	private Vector3 aggressivePosition;

	private Vector3 mostHiddenPosition;

	private bool foundSpawningPoint;

	private bool inKillAnimation;

	private float velX;

	private float velZ;

	private Vector3 previousPosition;

	private Vector3 agentLocalVelocity;

	public Transform animationContainer;

	private float timeSpentHiding;

	private float timeSinceAdjustingPosition;

	private Vector3 currentHidingSpot;

	public bool isHiding;

	public PlayerControllerB staringAtPlayer;

	public PlayerControllerB lastPlayerStaredAt;

	private bool backedUpFromWatchingPlayer;

	private float staringAtPlayerTimer;

	public float spottedMeter;

	private int checkForPlayerDistanceInterval;

	private int checkPlayer;

	public Vector3 rotAxis;

	public Transform turnCompass;

	private float maxAnimSpeed;

	private bool looking;

	private bool dragging;

	private bool startedShootingTongue;

	private float shootTongueTimer;

	public Transform tongue;

	public Transform tongueStartPoint;

	private float tongueLengthNormalized;

	private bool failedTongueShoot;

	private float randomForceInterval;

	private PlayerControllerB lastHitByPlayer;

	private float timeSinceTakingDamage;

	private float timeSinceKillingPlayer;

	private Coroutine killPlayerCoroutine;

	private DeadBodyInfo body;

	public Transform playerBodyHeadPoint;

	private float timeSinceChangingState;

	private Transform tongueTarget;

	private float tongueScale;

	public AudioClip snarlSFX;

	public AudioClip[] growlSFX;

	public AudioSource growlAudio;

	public AudioClip shootTongueSFX;

	private float timeAtLastGrowl;

	private bool playedTongueAudio;

	public AudioSource tongueAudio;

	public AudioClip tongueShootSFX;

	private bool changedHidingSpot;

	public ParticleSystem spitParticle;

	public Transform playerAnimationHeadPoint;

	public PlayerControllerB draggingPlayer;

	private float timeSinceCheckHomeBase;

	private int timesFailingTongueShoot;

	public Rig bendHeadBack;

	private float timeSinceLOSBlocked;

	public AudioClip killSFX;

	private float timeSinceCall;

	public AudioSource callClose;

	public AudioSource callFar;

	private float matingCallTimer;

	public AudioClip[] callsClose;

	public AudioClip[] callsFar;

	public AudioClip hitBushWolfSFX;

	private float timeSinceHitting;

	private float noTargetTimer;

	private float waitOutsideShipTimer;

	private Vector3 hiddenPos;

	ThreatType IVisibleThreat.type => default(ThreatType);

	int IVisibleThreat.SendSpecialBehaviour(int id)
	{
		return 0;
	}

	int IVisibleThreat.GetThreatLevel(Vector3 seenByPosition)
	{
		return 0;
	}

	int IVisibleThreat.GetInterestLevel()
	{
		return 0;
	}

	Transform IVisibleThreat.GetThreatLookTransform()
	{
		return null;
	}

	Transform IVisibleThreat.GetThreatTransform()
	{
		return null;
	}

	Vector3 IVisibleThreat.GetThreatVelocity()
	{
		return default(Vector3);
	}

	float IVisibleThreat.GetVisibility()
	{
		return 0f;
	}

	public override void AnimationEventA()
	{
	}

	public override void Start()
	{
	}

	private void CalculateNestRange(bool useCurrentHidingSpot)
	{
	}

	public override void OnDrawGizmos()
	{
	}

	[ServerRpc]
	public void SyncWeedPositionsServerRpc(Vector3 hiddenPosition, Vector3 aggressivePosition, float nest)
	{
	}

	[ClientRpc]
	public void SyncWeedPositionsClientRpc(Vector3 hiddenPosition, Vector3 agg, float nest)
	{
	}

	private bool GetBiggestWeedPatch()
	{
		return false;
	}

	public PlayerControllerB GetClosestPlayerToNest()
	{
		return null;
	}

	public override void DoAIInterval()
	{
	}

	[ServerRpc]
	public void SyncTargetPlayerAndAttackServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void SyncTargetPlayerAndAttackClientRpc(int playerId)
	{
	}

	[ServerRpc]
	public void SyncNewHidingSpotServerRpc(Vector3 newHidingSpot, float nest)
	{
	}

	[ClientRpc]
	public void SyncNewHidingSpotClientRpc(Vector3 newHidingSpot, float nest)
	{
	}

	public Transform ChooseClosestHiddenNode(Vector3 pos)
	{
		return null;
	}

	public void ChooseClosestNodeToPlayer()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetAnimationSpeedServerRpc(float animSpeed)
	{
	}

	[ClientRpc]
	public void SetAnimationSpeedClientRpc(float animSpeed)
	{
	}

	public override void SetEnemyStunned(bool setToStunned, float setToStunTime = 1f, PlayerControllerB setStunnedByPlayer = null)
	{
	}

	public override void HitEnemy(int force = 1, PlayerControllerB playerWhoHit = null, bool playHitSFX = false, int hitID = -1)
	{
	}

	private void CancelReelingPlayerIn()
	{
	}

	private void DoGrowlLocalClient()
	{
	}

	[ServerRpc]
	public void DoGrowlServerRpc()
	{
	}

	[ClientRpc]
	public void DoGrowlClientRpc()
	{
	}

	[ServerRpc]
	public void SeeBushWolfServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void SeeBushWolfClientRpc(int playerId)
	{
	}

	private void SetFearLevelFromBushWolf()
	{
	}

	public override void OnDestroy()
	{
	}

	public override void KillEnemy(bool destroy = false)
	{
	}

	public void HitTongue(PlayerControllerB playerWhoHit, int hitID)
	{
	}

	private void HitTongueLocalClient()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void HitTongueServerRpc(int playerWhoHit)
	{
	}

	[ClientRpc]
	public void HitTongueClientRpc(int playerWhoHit)
	{
	}

	private void CheckHomeBase(bool overrideInterval = false)
	{
	}

	private void DoMatingCall()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void MatingCallServerRpc()
	{
	}

	[ClientRpc]
	public void MatingCallClientRpc()
	{
	}

	public override void Update()
	{
	}

	private void TongueShootWasUnsuccessful()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void HitByEnemyServerRpc()
	{
	}

	[ClientRpc]
	public void HitByEnemyClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void DodgedEnemyHitServerRpc()
	{
	}

	[ClientRpc]
	public void DodgedEnemyHitClientRpc()
	{
	}

	private void LookAtPosition(Vector3 pos)
	{
	}

	public override void OnCollideWithEnemy(Collider other, EnemyAI collidedEnemy = null)
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void DoKillPlayerAnimationServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void DoKillPlayerAnimationClientRpc(int playerId)
	{
	}

	private void CancelKillAnimation()
	{
	}

	private void DropBody()
	{
	}

	[IteratorStateMachine(typeof(_003CKillAnimationOnPlayer_003Ed__141))]
	private IEnumerator KillAnimationOnPlayer(PlayerControllerB player)
	{
		return null;
	}

	private void LateUpdate()
	{
	}

	private void CalculateAnimationDirection(float maxSpeed = 1f)
	{
	}

	private void AddProceduralOffsetToLimbsOverTerrain()
	{
	}
}
