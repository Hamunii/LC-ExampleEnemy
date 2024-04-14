using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

public class RadMechAI : EnemyAI, IVisibleThreat
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_0
	{
		public RadMechAI _003C_003E4__this;

		public float startTime;

		internal bool _003CTorchPlayerAnimation_003Eb__0()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CTorchPlayerAnimation_003Ed__154 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RadMechAI _003C_003E4__this;

		private _003C_003Ec__DisplayClass154_0 _003C_003E8__1;

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
		public _003CTorchPlayerAnimation_003Ed__154(int _003C_003E1__state)
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
	private sealed class _003CflickerSpotlightAnim_003Ed__177 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RadMechAI _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CflickerSpotlightAnim_003Ed__177(int _003C_003E1__state)
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

	public Vector3 lookVector;

	private int previousBehaviour;

	public AISearchRoutine searchForPlayers;

	[Header("Sight variables")]
	public float fov;

	[Header("Movement Variables")]
	public float timeBetweenSteps;

	public float timeToTakeStep;

	public float stepMovementSpeed;

	private float walkStepTimer;

	private bool takingStep;

	private bool leftFoot;

	private bool disableWalking;

	public Transform torsoContainer;

	public Threat targetedThreat;

	public Transform focusedThreatTransform;

	private Collider targetedThreatCollider;

	private Coroutine spotlightCoroutine;

	public Material defaultMat;

	public Material spotlightMat;

	public GameObject spotlight;

	public AudioClip spotlightOff;

	public AudioClip spotlightFlicker;

	public Collider ownCollider;

	public Transform leftFootPoint;

	public Transform rightFootPoint;

	public ParticleSystem rightFootParticle;

	public ParticleSystem leftFootParticle;

	public ParticleSystem bothFeetParticle;

	private int visibleThreatsMask;

	private bool lostCreatureInChase;

	private bool lostCreatureInChaseDebounce;

	private float losTimer;

	private bool hasLOS;

	private float syncLOSInterval;

	private bool SyncedLOSState;

	private int checkForPathInterval;

	public bool isAlerted;

	public float alertTimer;

	public AudioSource LocalLRADAudio;

	public AudioSource LocalLRADAudio2;

	private float LRADAudio2BroadcastTimer;

	public GameObject lradAudioPrefab;

	public GameObject lradAudio2Prefab;

	public Transform torsoDefaultRotation;

	public GameObject missilePrefab;

	private float explodeMissileTimer;

	private float currentMissileSpeed;

	public GameObject explosionPrefab;

	public GameObject blastMarkPrefab;

	public ParticleSystem gunArmParticle;

	public bool aimingGun;

	private bool waitingForNextShot;

	private float shootTimer;

	public Coroutine aimGunCoroutine;

	public Transform gunPoint;

	public Transform gunArm;

	public AudioClip[] shootGunSFX;

	public AudioClip[] largeExplosionSFX;

	public AudioSource explosionAudio;

	public float forwardAngleCompensation;

	private bool hadLOSDuringLastShot;

	public Transform defaultArmRotation;

	private float shootCooldown;

	private bool inFlyingMode;

	private bool inSky;

	private Vector3 flightDestination;

	private Coroutine flyingCoroutine;

	private Vector3 landingPosition;

	private bool finishingFlight;

	private bool changedDirectionInFlight;

	private float flyTimer;

	public Transform flyingModeEye;

	public ParticleSystem smokeRightLeg;

	public ParticleSystem smokeLeftLeg;

	public static List<GameObject> PooledBlastMarks;

	private Vector3 previousExplosionPosition;

	[Header("Grab and torch players")]
	public ParticleSystem blowtorchParticle;

	public AudioSource blowtorchAudio;

	public bool attemptingGrab;

	private bool waitingToAttemptGrab;

	public bool inTorchPlayerAnimation;

	public Coroutine torchPlayerCoroutine;

	public Transform AttemptGrabPoint;

	private float attemptGrabTimer;

	private float timeSinceGrabbingPlayer;

	public Transform centerPosition;

	public Transform holdPlayerPoint;

	private bool blowtorchActivated;

	private bool startedUpdatePlayerPosCoroutine;

	public AudioSource flyingDistantAudio;

	public AudioSource spotlightOnAudio;

	[Header("Firing variables")]
	public int missilesFired;

	public float missileWarbleLevel;

	public float fireRate;

	public float fireRateVariance;

	public float missileSpeed;

	public float gunArmSpeed;

	[Space(3f)]
	public float shootUptime;

	public float shootDowntime;

	[Space(5f)]
	public bool chargingForward;

	public float chargeForwardSpeed;

	public GameObject startChargingEffectContainer;

	private bool startedChargeEffect;

	private float beginChargingTimer;

	public AudioSource chargeForwardAudio;

	public AudioSource engineSFX;

	public ParticleSystem chargeParticle;

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

	public override void Start()
	{
	}

	private void SpawnBlastMark(Vector3 pos, Quaternion rot)
	{
	}

	private void LateUpdate()
	{
	}

	[ClientRpc]
	public void ChangeBroadcastClipClientRpc(int clipIndex)
	{
	}

	public void ChangeFlightLandingPosition(Vector3 newLandingPosition)
	{
	}

	[ClientRpc]
	public void ChangeFlightLandingPositionClientRpc(Vector3 newLandingPosition)
	{
	}

	public void EndFlight()
	{
	}

	[ClientRpc]
	public void EndFlightClientRpc()
	{
	}

	public void SetChargingForward(bool setCharging)
	{
	}

	[ClientRpc]
	public void SetChargingForwardClientRpc(bool charging)
	{
	}

	public void SetChargingForwardOnLocalClient(bool charging)
	{
	}

	public void StartFlying()
	{
	}

	private void EnterFlight(Vector3 newLandingPosition)
	{
	}

	private Vector3 ChooseLandingPosition()
	{
		return default(Vector3);
	}

	[ClientRpc]
	public void EnterFlightClientRpc(Vector3 newLandingPosition)
	{
	}

	public void SetMechAlertedToThreat()
	{
	}

	[ClientRpc]
	public void SetMechAlertedClientRpc()
	{
	}

	public void SetAimingGun(bool setAiming)
	{
	}

	[ClientRpc]
	public void SetAimingClientRpc(bool aiming)
	{
	}

	public void StartShootGun()
	{
	}

	[ClientRpc]
	public void ShootGunClientRpc(Vector3 startPos, Vector3 startRot)
	{
	}

	public void ShootGun(Vector3 startPos, Vector3 startRot)
	{
	}

	public void StartExplosion(Vector3 explosionPosition, Vector3 forwardRotation, bool calledByClient = false)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetExplosionServerRpc(Vector3 explosionPosition, Vector3 forwardRotation)
	{
	}

	[ClientRpc]
	public void SetExplosionClientRpc(Vector3 explosionPosition, Vector3 forwardRotation, bool calledByClient = false)
	{
	}

	public void SetExplosion(Vector3 explosionPosition, Vector3 forwardRotation)
	{
	}

	public void AimGunArmTowardsTarget()
	{
	}

	public void CancelSpecialAnimations()
	{
	}

	public override void FinishedCurrentSearchRoutine()
	{
	}

	public override void DoAIInterval()
	{
	}

	private void LookForPlayersInFlight()
	{
	}

	public void MoveTowardsThreat()
	{
	}

	[ClientRpc]
	public void SetHasLineOfSightClientRpc(bool hasLineOfSight)
	{
	}

	[ClientRpc]
	public void SetLostCreatureInChaseClientRpc(bool lostInChase)
	{
	}

	public override void Update()
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void GrabPlayerServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void GrabPlayerClientRpc(int playerId, Vector3 enemyPosition, int enemyYRot)
	{
	}

	private void BeginTorchPlayer(PlayerControllerB playerBeingTorched, Vector3 enemyPosition, int enemyYRot)
	{
	}

	[IteratorStateMachine(typeof(_003CTorchPlayerAnimation_003Ed__154))]
	private IEnumerator TorchPlayerAnimation(Vector3 enemyPosition, int enemyYRot)
	{
		return null;
	}

	public void CancelTorchPlayerAnimation()
	{
	}

	public void StartGrabAttempt()
	{
	}

	[ClientRpc]
	public void StartGrabAttemptClientRpc()
	{
	}

	public void FinishAttemptGrab()
	{
	}

	[ClientRpc]
	public void FinishAttemptingGrabClientRpc()
	{
	}

	public void AttemptGrabIfClose()
	{
	}

	public void AimAndShootCycle()
	{
	}

	public void TurnTorsoToTarget()
	{
	}

	public bool CheckSightForThreat()
	{
		return false;
	}

	[ClientRpc]
	public void SetTargetToThreatClientRpc(NetworkObjectReference netObject, Vector3 lastSeenPos)
	{
	}

	public void SetTargetedThreat(IVisibleThreat newThreat, Vector3 lastSeenPos, float dist)
	{
	}

	private void DoFootstepCycle()
	{
	}

	private void TakeStepForwardAnimation(bool leftFootForward)
	{
	}

	[ClientRpc]
	public void TakeLeftStepForwardClientRpc()
	{
	}

	[ClientRpc]
	public void TakeRightStepForwardClientRpc()
	{
	}

	public void EnableBlowtorch()
	{
	}

	public void DisableBlowtorch()
	{
	}

	public void DisableThrusterSmoke()
	{
	}

	public void EnableThrusterSmoke()
	{
	}

	public void HasEnteredSky()
	{
	}

	public void FinishFlyingAnimation()
	{
	}

	public void FlickerFace()
	{
	}

	[IteratorStateMachine(typeof(_003CflickerSpotlightAnim_003Ed__177))]
	private IEnumerator flickerSpotlightAnim()
	{
		return null;
	}

	public void EnableSpotlight()
	{
	}

	public void DisableSpotlight()
	{
	}

	public void StompLeftFoot()
	{
	}

	public void StompRightFoot()
	{
	}

	public void StompBothFeet()
	{
	}

	private void Stomp(Transform stompTransform, ParticleSystem particle, ParticleSystem particle2 = null, float radius = 5f)
	{
	}
}
