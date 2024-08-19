using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CaveDwellerAI : EnemyAI
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass188_0
	{
		public float timeAtStart;

		public PlayerControllerB killingPlayer;

		internal bool _003CkillAnimation_003Eb__0()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CDropBabyAnimation_003Ed__144 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CaveDwellerAI _003C_003E4__this;

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
		public _003CDropBabyAnimation_003Ed__144(int _003C_003E1__state)
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
	private sealed class _003CbecomeAdultAnimation_003Ed__199 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CaveDwellerAI _003C_003E4__this;

		public Vector3 setToPos;

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
		public _003CbecomeAdultAnimation_003Ed__199(int _003C_003E1__state)
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
	private sealed class _003CkillAnimation_003Ed__188 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerControllerB killingPlayer;

		private _003C_003Ec__DisplayClass188_0 _003C_003E8__1;

		public CaveDwellerAI _003C_003E4__this;

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
		public _003CkillAnimation_003Ed__188(int _003C_003E1__state)
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

	public AudioSource walkingAudio;

	public AudioClip fakeCrySFX;

	public AudioClip growlSFX;

	public AudioSource clickingAudio1;

	public AudioSource clickingAudio2;

	public AudioSource screamAudio;

	public AudioSource screamAudioNonDiagetic;

	private bool isFakingBabyVoice;

	[Header("Maneater Variables")]
	public float sneakSpeed;

	public float attackDistance;

	public float leapSpeed;

	public float leapTime;

	public float screamTime;

	public float cooldownTime;

	public float chaseSpeed;

	public float baseSearchWidth;

	private float currentSearchWidth;

	[Space(3f)]
	public static float CaveDwellerDeafenAmount;

	private float caveDwellerDeafenAmountSmoothed;

	public float deafeningMaxDistance;

	public float deafeningMinDistance;

	public float maxDeafenAmount;

	public AISearchRoutine searchRoutine;

	private bool inKillAnimation;

	public List<Transform> ignoredNodes;

	private Vector3 caveHidingSpot;

	private bool screaming;

	private bool leaping;

	private float screamTimer;

	private float leapTimer;

	private bool chasingAfterLeap;

	private int previousBehaviourState;

	private bool startingKillAnimationLocalClient;

	private Coroutine killAnimationCoroutine;

	private DeadBodyInfo bodyBeingCarried;

	public Transform bodyRagdollPoint;

	public ParticleSystem killPlayerParticle1;

	public ParticleSystem killPlayerParticle2;

	private bool startedLeapingThisFrame;

	private Vector3 agentLocalVelocity;

	private Vector3 previousPosition;

	public Transform animationContainer;

	private bool movedSinceLastCheck;

	public DampedTransform headRig;

	public Transform[] bodyPoints;

	public bool controlsDiageticVolume;

	private float noPlayersTimer;

	private bool wasOutsideLastFrame;

	private bool beganCooldown;

	public AudioClip cooldownSFX;

	[Header("Baby AI")]
	public AudioSource babyCryingAudio;

	public AudioSource babyVoice;

	public AudioClip squirmingSFX;

	public AudioClip transformationSFX;

	public AudioClip[] scaredBabyVoiceSFX;

	public AudioClip biteSFX;

	public ParticleSystem babyTearsParticle;

	public ParticleSystem babyFoamAtMouthParticle;

	public BabyState babyState;

	private int previousBabyState;

	[Space(5f)]
	public float lonelinessMeter;

	public float stressMeter;

	public float growthMeter;

	public float growthSpeedMultiplier;

	public float moodinessMultiplier;

	[Space(3f)]
	public float decreaseLonelinessMultiplier;

	public float increaseLonelinessMultiplier;

	[Space(5f)]
	public List<BabyPlayerMemory> playerMemory;

	private int playersSeen;

	private float currentActivityTimer;

	private float activityTimerOffset;

	public GameObject observingObject;

	public bool sittingDown;

	public bool babyRunning;

	public bool babyCrying;

	private bool stopCryingWhenReleased;

	public int rockingBaby;

	public bool holdingBaby;

	public float rockBabyTimer;

	public PlayerControllerB playerHolding;

	private Coroutine dropBabyCoroutine;

	public CaveDwellerPhysicsProp propScript;

	public bool hasPlayerFoundBaby;

	private bool pathingTowardsNearestPlayer;

	public AISearchRoutine babySearchRoutine;

	public MultiAimConstraint babyLookRig;

	public Transform babyLookTarget;

	private float pingAttentionTimer;

	private int focusLevel;

	public Vector3 pingAttentionPosition;

	private float timeAtLastPingAttention;

	private float fallOverWhileSittingChanceInterval;

	private float cantFindObservedObjectTimer;

	private float timeSpentObservingTimer;

	private Vector3 runningFromPosition;

	public bool eatingScrap;

	public GrabbableObject observingScrap;

	private float timeSinceEatingScrap;

	private float eatScrapRandomCheckInterval;

	private PlayerControllerB observingPlayer;

	private bool gettingFarthestNodeFromSpotAsync;

	private Transform farthestNodeFromRunningSpot;

	public Transform BabyEye;

	public Animator babyCreatureAnimator;

	public float lookVerticalOffset;

	private float timeAtLastHeardNoise;

	private float babyCryLonelyThreshold;

	private float babyFollowPlayersThreshold;

	private float babyRoamFromPlayersThreshold;

	private float babyCrySquirmingThreshold;

	private float timeSinceCheckingForScrap;

	private int scrapEaten;

	public Transform spine2;

	public float rollOverTimer;

	public bool rolledOver;

	public bool babySquirming;

	private int[] ignoreItemIds;

	private List<GameObject> seenScrap;

	public GameObject babyContainer;

	public GameObject adultContainer;

	private float timeSinceCryingFromScarySight;

	private RaycastHit hit;

	private float fakeCryTimer;

	private bool clickingMandibles;

	private float timeSinceBiting;

	private bool wasBodyVisible;

	private Vector3 positionAtLeavingLOS;

	private float shakeCameraInterval;

	private float checkMovingInterval;

	private bool pursuingPlayerInSneakMode;

	private float changeOwnershipInterval;

	private float scareBabyWhileHoldingCooldown;

	public AudioClip pukeSFX;

	private bool nearTransforming;

	private bool babyPuked;

	public override void HitEnemy(int force = 1, PlayerControllerB playerWhoHit = null, bool playHitSFX = false, int hitID = -1)
	{
	}

	private bool IsBodyVisibleToTarget()
	{
		return false;
	}

	private void InitializeBabyValues()
	{
	}

	private BabyPlayerMemory GetBabyMemoryOfPlayer(PlayerControllerB player)
	{
		return null;
	}

	private void IncreaseBabyGrowthMeter()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyNearTransformingServerRpc()
	{
	}

	[ClientRpc]
	public void SetBabyNearTransformingClientRpc()
	{
	}

	public void PickUpBabyLocalClient()
	{
	}

	public void DropBabyLocalClient()
	{
	}

	[IteratorStateMachine(typeof(_003CDropBabyAnimation_003Ed__144))]
	private IEnumerator DropBabyAnimation()
	{
		return null;
	}

	public void PingAttention(int newFocusLevel, float timeToLook, Vector3 attentionPosition, bool sync = true)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void PingAttentionServerRpc(float timeToLook, Vector3 attentionPosition)
	{
	}

	[ClientRpc]
	public void PingAttentionClientRpc(float timeToLook, Vector3 attentionPosition)
	{
	}

	public PlayerControllerB[] GetAllPlayerBodiesInLineOfSight(float width = 45f, int range = 60, Transform eyeObject = null, float proximityCheck = -1f, int layerMask = -1)
	{
		return null;
	}

	private void DoBabyAIInterval()
	{
	}

	private void ScareBaby(Vector3 runFromPosition)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void ScareBabyServerRpc()
	{
	}

	[ClientRpc]
	public void ScareBabyClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabySittingServerRpc(bool sit)
	{
	}

	[ClientRpc]
	public void SetBabySittingClientRpc(bool sit)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyRolledOverServerRpc(bool rolledOver, bool scared)
	{
	}

	[ClientRpc]
	public void SetBabyRolledOverClientRpc(bool setRolled, bool scared)
	{
	}

	private void PlayBabyScaredAudio()
	{
	}

	private void SetRolledOverLocalClient(bool setRolled, bool scared)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyCryingServerRpc(bool setCry)
	{
	}

	[ClientRpc]
	public void SetBabyCryingClientRpc(bool setCry)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyBServerRpc()
	{
	}

	[ClientRpc]
	public void SetBabyBClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyRunningServerRpc(bool setRunning)
	{
	}

	[ClientRpc]
	public void SetBabyRunningClientRpc(bool setRunning)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabySquirmingServerRpc(bool setSquirm)
	{
	}

	[ClientRpc]
	public void SetBabySquirmingClientRpc(bool setSquirm)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void ClearBabyObservingServerRpc(bool eatScrap)
	{
	}

	[ClientRpc]
	public void ClearBabyObservingClientRpc(bool eatScrap)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyObservingPlayerServerRpc(int playerId, int setFocusLevel)
	{
	}

	[ClientRpc]
	public void SetBabyObservingPlayerClientRpc(int playerId, int setFocusLevel)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetBabyObservingObjectServerRpc(NetworkObjectReference netObject)
	{
	}

	[ClientRpc]
	public void SetBabyObservingObjectClientRpc(NetworkObjectReference netObject)
	{
	}

	public override void DetectNoise(Vector3 noisePosition, float noiseLoudness, int timesPlayedInOneSpot = 0, int noiseID = 0)
	{
	}

	private void BabyObserveAnimation()
	{
	}

	private void SitCycle()
	{
	}

	private void StopObserving(bool eatScrap)
	{
	}

	private void SetCryingLocalClient(bool setCrying)
	{
	}

	private void BabyUpdate()
	{
	}

	private Vector3 GetCavePosition(System.Random randomSeed)
	{
		return default(Vector3);
	}

	[ServerRpc(RequireOwnership = false)]
	public void SyncCaveHidingSpotServerRpc(Vector3 setHidingSpot)
	{
	}

	[ClientRpc]
	public void SyncCaveHidingSpotClientRpc(Vector3 setHidingSpot)
	{
	}

	public override void Start()
	{
	}

	public override void KillEnemy(bool destroy = false)
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void KillPlayerAnimationServerRpc(int playerObjectId)
	{
	}

	[ClientRpc]
	public void CancelKillAnimationClientRpc(int playerObjectId)
	{
	}

	[ClientRpc]
	public void KillPlayerAnimationClientRpc(int playerObjectId)
	{
	}

	[IteratorStateMachine(typeof(_003CkillAnimation_003Ed__188))]
	private IEnumerator killAnimation(PlayerControllerB killingPlayer)
	{
		return null;
	}

	private void GrabBody(DeadBodyInfo body)
	{
	}

	private void DropBody()
	{
	}

	public void FinishKillAnimation(bool completed)
	{
	}

	private void CalculateAnimationDirection(float maxSpeed = 1f)
	{
	}

	public override void Update()
	{
	}

	public override void DoAIInterval()
	{
	}

	private void TransformIntoAdult()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void TurnIntoAdultServerRpc()
	{
	}

	[ClientRpc]
	public void TurnIntoAdultClientRpc()
	{
	}

	private void StartTransformationAnim()
	{
	}

	[IteratorStateMachine(typeof(_003CbecomeAdultAnimation_003Ed__199))]
	private IEnumerator becomeAdultAnimation(Vector3 setToPos)
	{
		return null;
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetFakingBabyVoiceServerRpc(bool fakingBabyVoice)
	{
	}

	[ClientRpc]
	public void SetFakingBabyVoiceClientRpc(bool faking)
	{
	}

	private void DoNonBabyUpdateLogic()
	{
	}

	private void LookAtTargetPlayer()
	{
	}

	private void DoAIIntervalChaseLogic()
	{
	}

	private void DoFakeCryLocalClient()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void MakeFakeCryServerRpc()
	{
	}

	[ClientRpc]
	public void MakeFakeCryClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetClickingMandiblesServerRpc()
	{
	}

	[ClientRpc]
	public void SetClickingMandiblesClientRpc()
	{
	}

	private void RoamAroundCaveSpot(bool gotTarget, float distToTarget = -1f)
	{
	}

	public void ChooseClosestNodeToPlayer()
	{
	}

	public Transform ChooseClosestNodeToPositionNoLOS(Vector3 pos, bool avoidLineOfSight = false, int offset = 0)
	{
		return null;
	}

	[ServerRpc(RequireOwnership = false)]
	public void FinishLeapServerRpc()
	{
	}

	[ClientRpc]
	public void FinishLeapClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void DoLeapServerRpc()
	{
	}

	[ClientRpc]
	public void DoLeapClientRpc()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void DoScreamServerRpc()
	{
	}

	[ClientRpc]
	public void DoScreamClientRpc()
	{
	}

	public override void OnDestroy()
	{
	}

	private void LateUpdate()
	{
	}

	private void SetClickingAudioVolume()
	{
	}
}
