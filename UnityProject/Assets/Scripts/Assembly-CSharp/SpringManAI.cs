using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class SpringManAI : EnemyAI
{
	[CompilerGenerated]
	private sealed class _003CParabola_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NavMeshAgent agent;

		public SpringManAI _003C_003E4__this;

		public float height;

		public float duration;

		private OffMeshLinkData _003Cdata_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CendPos_003E5__4;

		private float _003CnormalizedTime_003E5__5;

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
		public _003CParabola_003Ed__28(int _003C_003E1__state)
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

	public AISearchRoutine searchForPlayers;

	private float checkLineOfSightInterval;

	private bool hasEnteredChaseMode;

	private bool stoppingMovement;

	private bool hasStopped;

	public AnimationStopPoints animStopPoints;

	private float currentChaseSpeed;

	private float currentAnimSpeed;

	private PlayerControllerB previousTarget;

	private bool wasOwnerLastFrame;

	private float stopAndGoMinimumInterval;

	private float hitPlayerTimer;

	public AudioClip[] springNoises;

	public AudioClip enterCooldownSFX;

	public Collider mainCollider;

	private float loseAggroTimer;

	private float timeSinceHittingPlayer;

	private bool movingOnOffMeshLink;

	private Coroutine offMeshLinkCoroutine;

	private float stopMovementTimer;

	public float timeSpentMoving;

	public float onCooldownPhase;

	private bool setOnCooldown;

	public float timeAtLastCooldown;

	private bool inCooldownAnimation;

	[ServerRpc(RequireOwnership = false)]
	public void SetCoilheadOnCooldownServerRpc(bool setTrue)
	{
	}

	[ClientRpc]
	public void SetCoilheadOnCooldownClientRpc(bool setTrue)
	{
	}

	public override void DoAIInterval()
	{
	}

	[IteratorStateMachine(typeof(_003CParabola_003Ed__28))]
	private IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
	{
		return null;
	}

	private void StopOffMeshLinkMovement()
	{
	}

	private void DoSpringAnimation(bool springPopUp = false)
	{
	}

	public override void Update()
	{
	}

	[ServerRpc]
	public void SetAnimationStopServerRpc()
	{
	}

	[ClientRpc]
	public void SetAnimationStopClientRpc()
	{
	}

	[ServerRpc]
	public void SetAnimationGoServerRpc()
	{
	}

	[ClientRpc]
	public void SetAnimationGoClientRpc()
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}
}
