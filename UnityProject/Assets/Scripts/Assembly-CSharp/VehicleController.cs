using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition;

public class VehicleController : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRemoveKey_003Ed__233 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VehicleController _003C_003E4__this;

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
		public _003CRemoveKey_003Ed__233(int _003C_003E1__state)
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
	private sealed class _003CTryIgnition_003Ed__236 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VehicleController _003C_003E4__this;

		public bool isLocalDriver;

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
		public _003CTryIgnition_003Ed__236(int _003C_003E1__state)
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
	private sealed class _003CjerkCarUpward_003Ed__295 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VehicleController _003C_003E4__this;

		public Vector3 dir;

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
		public _003CjerkCarUpward_003Ed__295(int _003C_003E1__state)
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

	public int vehicleID;

	[Header("Vehicle Physics")]
	public WheelCollider FrontLeftWheel;

	public WheelCollider FrontRightWheel;

	public WheelCollider BackLeftWheel;

	public WheelCollider BackRightWheel;

	public WheelCollider[] otherWheels;

	public Rigidbody mainRigidbody;

	public Transform[] driverSideExitPoints;

	public Transform[] passengerSideExitPoints;

	public InteractTrigger driverSeatTrigger;

	public InteractTrigger passengerSeatTrigger;

	public float EngineTorque;

	public float MaxEngineRPM;

	public float MinEngineRPM;

	public float EngineRPM;

	[Header("Vehicle Control")]
	public bool ignitionStarted;

	public Vector2 moveInputVector;

	public float steeringInput;

	public float steeringWheelTurnSpeed;

	public float carAcceleration;

	public float carMaxSpeed;

	public float brakeSpeed;

	public float idleSpeed;

	[Space(5f)]
	[Header("Car Damage")]
	public float carFragility;

	public float minimalBumpForce;

	public float mediumBumpForce;

	public float maximumBumpForce;

	public int baseCarHP;

	public int carHP;

	private float timeAtLastDamage;

	public bool carDestroyed;

	[Space(5f)]
	[Header("Effects")]
	public MeshRenderer leftWheelMesh;

	public MeshRenderer rightWheelMesh;

	public MeshRenderer backLeftWheelMesh;

	public MeshRenderer backRightWheelMesh;

	public Animator steeringWheelAnimator;

	public Animator gearStickAnimator;

	public AudioSource engineAudio1;

	public AudioSource engineAudio2;

	public AudioSource rollingAudio;

	public AudioSource turbulenceAudio;

	private float turbulenceAmount;

	public bool carEngine1AudioActive;

	public bool carEngine2AudioActive;

	public bool carRollingAudioActive;

	public AudioClip revEngineStart;

	public AudioClip engineStartSuccessful;

	public AudioClip engineRun;

	public AudioClip engineRev;

	public AudioClip engineRun2;

	public AudioClip insertKey;

	public AudioClip twistKey;

	public AudioClip removeKey;

	public AudioClip sitDown;

	public AudioSource tireAudio;

	public AudioSource vehicleEngineAudio;

	public AudioSource steeringWheelAudio;

	public AudioSource skiddingAudio;

	public AudioSource gearStickAudio;

	public AudioClip[] gearStickAudios;

	public AnimatedObjectTrigger driverSideDoor;

	public AnimatedObjectTrigger passengerSideDoor;

	public InteractTrigger driverSideDoorTrigger;

	public InteractTrigger passengerSideDoorTrigger;

	public PlayerInput input;

	public bool localPlayerInControl;

	public bool localPlayerInPassengerSeat;

	public bool drivePedalPressed;

	public bool brakePedalPressed;

	public CarGearShift gear;

	public float gearStickAnimValue;

	public float steeringAnimValue;

	private float steeringWheelAnimFloat;

	public float carStress;

	public float carStressChange;

	public PlayerControllerB currentDriver;

	public PlayerControllerB currentPassenger;

	public bool testingVehicleInEditor;

	public float engineIntensityPercentage;

	public Vector3 syncedPosition;

	public Quaternion syncedRotation;

	public float syncSpeedMultiplier;

	public float syncRotationSpeed;

	public float syncCarPositionInterval;

	private bool enabledCollisionForAllPlayers;

	public ContactPoint[] contacts;

	public PlayerPhysicsRegion physicsRegion;

	private int exitCarLayerMask;

	private Coroutine keyIgnitionCoroutine;

	public MeshRenderer keyObject;

	public Transform ignitionTurnedPosition;

	public Transform ignitionNotTurnedPosition;

	private bool keyIsInDriverHand;

	private bool keyIsInIgnition;

	public Vector3 positionOffset;

	public Vector3 rotationOffset;

	public GameObject startKeyIgnitionTrigger;

	public GameObject removeKeyIgnitionTrigger;

	private float chanceToStartIgnition;

	private float timeAtLastGearShift;

	private RaycastHit hit;

	public AudioSource hoodAudio;

	public AudioSource pushAudio;

	public AudioSource collisionAudio1;

	public AudioSource collisionAudio2;

	public AudioClip[] maxCollisions;

	public AudioClip[] medCollisions;

	public AudioClip[] minCollisions;

	public AudioClip[] obstacleCollisions;

	public AudioClip windshieldBreak;

	public AudioSource miscAudio;

	private float audio1Time;

	private float audio2Time;

	private int audio1Type;

	private int audio2Type;

	public MeshRenderer mainBodyMesh;

	public MeshRenderer lod1Mesh;

	public MeshRenderer lod2Mesh;

	public Material windshieldBrokenMat;

	public ParticleSystem glassParticle;

	private bool windshieldBroken;

	private Vector3 truckVelocityLastFrame;

	public bool useVel;

	[Header("Radio")]
	public AudioClip[] radioClips;

	public AudioSource radioAudio;

	public AudioSource radioInterference;

	private float radioSignalQuality;

	private float radioSignalDecreaseThreshold;

	public float radioSignalTurbulence;

	private float changeRadioSignalTime;

	private bool radioOn;

	private int currentRadioClip;

	private float currentSongTime;

	private bool radioTurnedOnBefore;

	public float carHitPlayerForceFraction;

	public float carReactToPlayerHitMultiplier;

	public ParticleSystem carExhaustParticle;

	public Vector3 averageVelocity;

	public int movingAverageLength;

	public int averageCount;

	private DecalProjector[] decals;

	private int decalIndex;

	public ParticleSystem hoodFireParticle;

	public AudioSource hoodFireAudio;

	private bool isHoodOnFire;

	private bool carHoodOpen;

	public Animator carHoodAnimator;

	private AudioClip carHoodOpenSFX;

	private AudioClip carHoodCloseSFX;

	public GameObject backDoorContainer;

	public GameObject destroyedTruckMesh;

	public GameObject truckDestroyedExplosion;

	private bool hoodPoppedUp;

	public float pushForceMultiplier;

	public float pushVerticalOffsetAmount;

	public GameObject headlightsContainer;

	public Material headlightsOnMat;

	public Material headlightsOffMat;

	public AudioClip headlightsToggleSFX;

	public bool magnetedToShip;

	private Vector3 magnetTargetPosition;

	private Quaternion magnetTargetRotation;

	private Quaternion magnetStartRotation;

	private Vector3 magnetStartPosition;

	public float magnetTime;

	private bool finishedMagneting;

	private bool loadedVehicleFromSave;

	private float magnetRotationTime;

	public BoxCollider boundsCollider;

	private Vector3 averageVelocityAtMagnetStart;

	public AnimationCurve magnetPositionCurve;

	public AnimationCurve magnetRotationCurve;

	private bool destroyNextFrame;

	private string lastStressType;

	private string lastDamageType;

	private float stressPerSecond;

	public Rigidbody ragdollPhysicsBody;

	public Rigidbody windwiperPhysicsBody1;

	public Rigidbody windwiperPhysicsBody2;

	public Transform windwiper1;

	public Transform windwiper2;

	public BoxCollider windshieldPhysicsCollider;

	public Animator driverSeatSpringAnimator;

	public float timeSinceSpringingDriverSeat;

	public AudioSource springAudio;

	public float springForce;

	public GameObject backLightsContainer;

	public GameObject frontCabinLightContainer;

	public MeshRenderer backLightsMesh;

	public MeshRenderer frontCabinLightMesh;

	public Material backLightOnMat;

	public bool backLightsOn;

	public AudioSource hornAudio;

	public bool honkingHorn;

	private float timeAtLastHornPing;

	private float timeAtLastEngineAudioPing;

	public float torqueForce;

	public bool backDoorOpen;

	public bool hasBeenSpawned;

	public bool inDropshipAnimation;

	private ItemDropship itemShip;

	public ParticleSystem tireSparks;

	public AudioSource extremeStressAudio;

	private bool underExtremeStress;

	private bool syncedExtremeStress;

	public Transform healthMeter;

	public Transform turboMeter;

	public Transform clipboardPosition;

	private float limitTruckVelocityTimer;

	[Header("Boost ability")]
	private int turboBoosts;

	private bool pressedTurbo;

	public float turboBoostForce;

	public float turboBoostUpwardForce;

	public ParticleSystem turboBoostParticle;

	public AudioSource turboBoostAudio;

	public AudioClip turboBoostSFX;

	public AudioClip turboBoostSFX2;

	public Transform oilPipePoint;

	private bool jumpingInCar;

	public float jumpForce;

	public AudioClip jumpInCarSFX;

	private string[] carTooltips;

	public AudioClip pourOil;

	public AudioClip pourTurbo;

	private bool setControlTips;

	public void SetBackDoorOpen(bool open)
	{
	}

	private void SetFrontCabinLightOn(bool setOn)
	{
	}

	private void SetWheelFriction()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void RemoveKeyFromIgnition()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void RemoveKeyFromIgnitionServerRpc(int driverId)
	{
	}

	[ClientRpc]
	public void RemoveKeyFromIgnitionClientRpc(int driverId)
	{
	}

	[IteratorStateMachine(typeof(_003CRemoveKey_003Ed__233))]
	private IEnumerator RemoveKey()
	{
		return null;
	}

	public void CancelTryCarIgnition()
	{
	}

	public void StartTryCarIgnition()
	{
	}

	[IteratorStateMachine(typeof(_003CTryIgnition_003Ed__236))]
	private IEnumerator TryIgnition(bool isLocalDriver)
	{
		return null;
	}

	[ServerRpc(RequireOwnership = false)]
	public void RevCarServerRpc(int driverId)
	{
	}

	[ClientRpc]
	public void RevCarClientRpc(int driverId)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void StartIgnitionServerRpc(int driverId)
	{
	}

	[ClientRpc]
	public void StartIgnitionClientRpc(int driverId)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void TryIgnitionServerRpc(int driverId, bool keyIsIn)
	{
	}

	[ClientRpc]
	public void TryIgnitionClientRpc(int driverId, bool keyIsIn)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void CancelTryIgnitionServerRpc(int driverId, bool setKeyInSlot)
	{
	}

	[ClientRpc]
	public void CancelTryIgnitionClientRpc(int driverId, bool setKeyInSlot)
	{
	}

	public void CancelIgnitionAnimation()
	{
	}

	public void SetIgnition(bool started)
	{
	}

	public void ExitDriverSideSeat()
	{
	}

	public void OnPassengerExit()
	{
	}

	public void ExitPassengerSideSeat()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void PassengerLeaveVehicleServerRpc(int playerId, Vector3 exitPoint)
	{
	}

	[ClientRpc]
	public void PassengerLeaveVehicleClientRpc(int playerId, Vector3 exitPoint)
	{
	}

	public void SetPlayerInCar(PlayerControllerB player)
	{
	}

	public void SetPassengerInCar(PlayerControllerB player)
	{
	}

	private int CanExitCar(bool passengerSide)
	{
		return 0;
	}

	public void TakeControlOfVehicle()
	{
	}

	public void LoseControlOfVehicle()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetPlayerInControlOfVehicleServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void CancelPlayerInControlOfVehicleClientRpc(int playerId)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void RemovePlayerControlOfVehicleServerRpc(int playerId, Vector3 carLocation, Quaternion carRotation, bool setKeyInIgnition)
	{
	}

	[ClientRpc]
	public void SetPlayerInControlOfVehicleClientRpc(int playerId)
	{
	}

	[ClientRpc]
	public void RemovePlayerControlOfVehicleClientRpc(int playerId, bool setIgnitionStarted)
	{
	}

	public void DisableVehicleCollisionForAllPlayers()
	{
	}

	public void EnableVehicleCollisionForAllPlayers()
	{
	}

	public void SetVehicleCollisionForPlayer(bool setEnabled, PlayerControllerB player)
	{
	}

	private void ActivateControl()
	{
	}

	private void DisableControl()
	{
	}

	public void ShiftGearForward()
	{
	}

	private void ShiftGearForwardInput(InputAction.CallbackContext context)
	{
	}

	private void ShiftGearBack()
	{
	}

	private void ShiftToGear(int setGear)
	{
	}

	public void ShiftToGearAndSync(int setGear)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void ShiftToGearServerRpc(int setGear, int playerId)
	{
	}

	[ClientRpc]
	public void ShiftToGearClientRpc(int setGear, int playerId)
	{
	}

	private void ShiftGearBackInput(InputAction.CallbackContext context)
	{
	}

	private void GetVehicleInput()
	{
	}

	[ServerRpc]
	public void SyncCarPositionServerRpc(Vector3 carPosition, Vector3 carRotation, float steeringInput, float EngineRPM)
	{
	}

	[ClientRpc]
	public void SyncCarPositionClientRpc(Vector3 carPosition, Vector3 carRotation, float steeringInput, float engineSpeed)
	{
	}

	[ServerRpc]
	public void MagnetCarServerRpc(Vector3 targetPosition, Vector3 targetRotation, int playerWhoSent)
	{
	}

	[ClientRpc]
	public void MagnetCarClientRpc(Vector3 targetPosition, Vector3 targetRotation, int playerWhoSent)
	{
	}

	public void SetHonkingLocalClient(bool honk)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetHonkServerRpc(bool honk, int playerId)
	{
	}

	[ClientRpc]
	public void SetHonkClientRpc(bool honk, int playerId)
	{
	}

	private void CollectItemsInTruck()
	{
	}

	public void StartMagneting()
	{
	}

	public void AddTurboBoost()
	{
	}

	public void AddTurboBoostOnLocalClient(int setTurboBoosts)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void AddTurboBoostServerRpc(int playerId, int setTurboBoosts)
	{
	}

	[ClientRpc]
	public void AddTurboBoostClientRpc(int playerId, int setTurboBoosts)
	{
	}

	public void AddEngineOil()
	{
	}

	public void AddEngineOilOnLocalClient(int setCarHP)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void AddEngineOilServerRpc(int playerId, int setHP)
	{
	}

	[ClientRpc]
	public void AddEngineOilClientRpc(int playerId, int setHP)
	{
	}

	private void DoTurboBoost(InputAction.CallbackContext context)
	{
	}

	public void UseTurboBoostLocalClient(Vector2 dir = default(Vector2))
	{
	}

	[IteratorStateMachine(typeof(_003CjerkCarUpward_003Ed__295))]
	private IEnumerator jerkCarUpward(Vector3 dir)
	{
		return null;
	}

	[ServerRpc(RequireOwnership = false)]
	public void UseTurboBoostServerRpc()
	{
	}

	[ClientRpc]
	public void UseTurboBoostClientRpc()
	{
	}

	public void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void ChangeRadioStation()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetRadioStationServerRpc(int radioStation, int signalQuality)
	{
	}

	[ClientRpc]
	public void SetRadioStationClientRpc(int radioStation, int signalQuality)
	{
	}

	public void SwitchRadio()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetRadioOnServerRpc(bool on)
	{
	}

	[ClientRpc]
	public void SetRadioOnClientRpc(bool on)
	{
	}

	private void SetRadioOnLocalClient(bool on, bool setClip = true)
	{
	}

	public void SetRadioValues()
	{
	}

	[ServerRpc]
	public void SetRadioSignalQualityServerRpc(int signalQuality)
	{
	}

	[ClientRpc]
	public void SetRadioSignalQualityClientRpc(int signalQuality)
	{
	}

	private void MatchWheelMeshToCollider(MeshRenderer wheelMesh, WheelCollider wheelCollider)
	{
	}

	[ServerRpc]
	public void SyncExtremeStressServerRpc(bool underStress)
	{
	}

	[ClientRpc]
	public void SyncExtremeStressClientRpc(bool underStress)
	{
	}

	private void SetCarEffects(float setSteering)
	{
	}

	private void SetVehicleAudioProperties(AudioSource audio, bool audioActive, float lowest, float highest, float lerpSpeed, bool useVolumeInsteadOfPitch = false, float onVolume = 1f)
	{
	}

	private void FixedUpdate()
	{
	}

	private void SyncCarPhysicsToOtherClients()
	{
	}

	public bool CarReactToObstacle(Vector3 vel, Vector3 position, Vector3 impulse, CarObstacleType type, float obstacleSize = 1f, EnemyAI enemyScript = null, bool dealDamage = true)
	{
		return false;
	}

	private void LateUpdate()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void CarBumpServerRpc(Vector3 vel)
	{
	}

	[ClientRpc]
	public void CarBumpClientRpc(Vector3 vel)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void CarCollisionServerRpc(Vector3 vel, float magn)
	{
	}

	[ClientRpc]
	public void CarCollisionClientRpc(Vector3 vel, float magn)
	{
	}

	private void DamagePlayerInVehicle(Vector3 vel, float magnitude)
	{
	}

	private void BreakWindshield()
	{
	}

	public void PlayCollisionAudio(Vector3 setPosition, int audioType, float setVolume)
	{
	}

	[ServerRpc]
	public void CarCollisionSFXServerRpc(Vector3 audioPosition, int audio, int audioType, float vol)
	{
	}

	[ClientRpc]
	public void CarCollisionSFXClientRpc(Vector3 audioPosition, int audio, int audioType, float vol)
	{
	}

	private void PlayRandomClipAndPropertiesFromAudio(AudioSource audio, float setVolume, bool audioFinished, int audioType)
	{
	}

	private void SetInternalStress(float carStressIncrease = 0f)
	{
	}

	private void DealPermanentDamage(int damageAmount, Vector3 damagePosition = default(Vector3))
	{
	}

	[ServerRpc]
	public void DealDamageServerRpc(int amount, int sentByClient)
	{
	}

	[ClientRpc]
	public void DealDamageClientRpc(int amount, int sentByClient)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void DestroyCarServerRpc(int sentByClient)
	{
	}

	[ClientRpc]
	public void DestroyCarClientRpc(int sentByClient)
	{
	}

	private void DestroyCar()
	{
	}

	private void ReactToDamage()
	{
	}

	public void PushTruckWithArms()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void PushTruckServerRpc(Vector3 pos, Vector3 dir)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void PushTruckFromOwnerServerRpc(Vector3 pos)
	{
	}

	[ClientRpc]
	public void PushTruckClientRpc(Vector3 pushPosition, Vector3 dir)
	{
	}

	[ClientRpc]
	public void PushTruckFromOwnerClientRpc(Vector3 pos)
	{
	}

	public void ToggleHoodOpenLocalClient()
	{
	}

	public void SetHoodOpenLocalClient(bool setOpen)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetHoodOpenServerRpc(bool open)
	{
	}

	[ClientRpc]
	public void SetHoodOpenClientRpc(bool open)
	{
	}

	public void ToggleHeadlightsLocalClient()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void ToggleHeadlightsServerRpc(bool setLightsOn)
	{
	}

	[ClientRpc]
	public void ToggleHeadlightsClientRpc(bool setLightsOn)
	{
	}

	private void SetHeadlightMaterial(bool on)
	{
	}

	public void SpringDriverSeatLocalClient()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SpringDriverSeatServerRpc()
	{
	}

	[ClientRpc]
	public void SpringDriverSeatClientRpc()
	{
	}
}
