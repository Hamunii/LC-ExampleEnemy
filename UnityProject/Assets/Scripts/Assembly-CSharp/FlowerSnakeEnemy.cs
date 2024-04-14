using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

public class FlowerSnakeEnemy : EnemyAI
{
	[CompilerGenerated]
	private sealed class _003CflyAwayThenDespawn_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FlowerSnakeEnemy _003C_003E4__this;

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
		public _003CflyAwayThenDespawn_003Ed__56(int _003C_003E1__state)
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

	public AISearchRoutine snakeRoam;

	private float timeSinceSeeingTarget;

	private bool leaping;

	private Vector3 leapDirection;

	public AnimationCurve leapVerticalCurve;

	public Transform meshContainer;

	private Vector3 startLeapPosition;

	private float leapTime;

	public float leapTimeMultiplier;

	public float leapSpeedMultiplier;

	public float leapVerticalMultiplier;

	public PlayerControllerB clingingToPlayer;

	private bool waitingForHitPlayerRPC;

	public int clingPosition;

	private float collideWithPlayerInterval;

	private Vector3 previousPosition;

	public float spinePositionUpOffset;

	public float spinePositionRightOffset;

	private float timeOfLastCling;

	private bool choseFarawayNode;

	private float clingingPlayerFlapInterval;

	public static FlowerSnakeEnemy[] mainSnakes;

	private bool flapping;

	private float flapIntervalTimeOffset;

	private RaycastHit hit;

	private float leapVerticalPosition;

	private bool hitWallInLeap;

	private float fallFromLeapTimer;

	private bool fallingFromLeap;

	public Vector3 landingPoint;

	private Vector3 vel;

	public Material[] randomSkinColor;

	public int snakesOnPlayer;

	public bool activatedFlight;

	public float flightPower;

	private Vector3 forces;

	public float chuckleInterval;

	public AudioSource flappingAudio;

	public float clingToPlayerTimer;

	public float timeOfLastLeap;

	public override void Start()
	{
	}

	[ClientRpc]
	public void StartLeapClientRpc(Vector3 setLeapDir)
	{
	}

	public void StartLeapOnLocalClient(Vector3 leapDir)
	{
	}

	public void StopLeapOnLocalClient(bool landOnGround = false, Vector3 overrideLandingPosition = default(Vector3))
	{
	}

	public void StopClingingOnLocalClient(bool isMainSnake = false)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void StopClingingServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void StopClingingClientRpc(int playerId)
	{
	}

	[ClientRpc]
	public void StopLeapClientRpc(Vector3 landingPoint)
	{
	}

	[ClientRpc]
	public void SetFlappingClientRpc(bool setFlapping)
	{
	}

	private void SetFlappingLocalClient(bool setFlapping, bool isMainSnake = false)
	{
	}

	public override void DoAIInterval()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public override void HitEnemy(int force = 1, PlayerControllerB playerWhoHit = null, bool playHitSFX = false, int hitID = -1)
	{
	}

	public override void KillEnemy(bool destroy = false)
	{
	}

	public override void DaytimeEnemyLeave()
	{
	}

	[IteratorStateMachine(typeof(_003CflyAwayThenDespawn_003Ed__56))]
	private IEnumerator flyAwayThenDespawn()
	{
		return null;
	}

	[ClientRpc]
	public void SetEnemyLeavingClientRpc()
	{
	}

	private void LocalPlayerDamaged()
	{
	}

	[ServerRpc]
	public void StartFlyingServerRpc()
	{
	}

	[ClientRpc]
	public void StartFlyingClientRpc()
	{
	}

	private void StartLiftingClungPlayer()
	{
	}

	[ClientRpc]
	public void MakeChuckleClientRpc()
	{
	}

	private void MainSnakeActAsConductor()
	{
	}

	private void DoChuckleOnInterval()
	{
	}

	private void DoLeapAndDropPhysics()
	{
	}

	public override void Update()
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void FSHitPlayerServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void FSHitPlayerCancelClientRpc(int playerId)
	{
	}

	[ClientRpc]
	public void ClingToPlayerClientRpc(int playerId, int setClingPosition, float clingTime)
	{
	}

	private void SetClingToPlayer(PlayerControllerB playerToCling, int setClingPosition, float clingTime)
	{
	}

	public override void EnableEnemyMesh(bool enable, bool overrideDoNotSet = false)
	{
	}

	private void LateUpdate()
	{
	}

	private void CalculateAnimationSpeed(float maxSpeed = 1f)
	{
	}

	private void SetClingingAnimationPosition()
	{
	}
}
