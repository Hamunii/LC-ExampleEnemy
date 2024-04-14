using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

public class StunGrenadeItem : GrabbableObject
{
	[CompilerGenerated]
	private sealed class _003CpullPinAnimation_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StunGrenadeItem _003C_003E4__this;

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
		public _003CpullPinAnimation_003Ed__35(int _003C_003E1__state)
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

	[Header("Stun grenade settings")]
	public float TimeToExplode;

	public bool DestroyGrenade;

	public string playerAnimation;

	[Space(5f)]
	public bool explodeOnCollision;

	public bool dontRequirePullingPin;

	public float chanceToExplode;

	public bool spawnDamagingShockwave;

	private bool explodeOnThrow;

	private bool gotExplodeOnThrowRPC;

	private bool hasCollided;

	[Space(3f)]
	public bool pinPulled;

	public bool inPullingPinAnimation;

	public string throwString;

	private Coroutine pullPinCoroutine;

	public Animator itemAnimator;

	public AudioSource itemAudio;

	public AudioClip pullPinSFX;

	public AudioClip explodeSFX;

	public AnimationCurve grenadeFallCurve;

	public AnimationCurve grenadeVerticalFallCurve;

	public AnimationCurve grenadeVerticalFallCurveNoBounce;

	public RaycastHit grenadeHit;

	public Ray grenadeThrowRay;

	private int stunGrenadeMask;

	public float explodeTimer;

	public bool hasExploded;

	public GameObject stunGrenadeExplosion;

	private PlayerControllerB playerThrownBy;

	public override void ItemActivate(bool used, bool buttonDown = true)
	{
	}

	public override void DiscardItem()
	{
	}

	public override void EquipItem()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SetExplodeOnThrowServerRpc()
	{
	}

	[ClientRpc]
	public void SetExplodeOnThrowClientRpc(bool explode)
	{
	}

	private void SetControlTipForGrenade()
	{
	}

	public override void FallWithCurve()
	{
	}

	[IteratorStateMachine(typeof(_003CpullPinAnimation_003Ed__35))]
	private IEnumerator pullPinAnimation()
	{
		return null;
	}

	public override void Update()
	{
	}

	public override void Start()
	{
	}

	public override void OnHitGround()
	{
	}

	private void ExplodeStunGrenade(bool destroy = false)
	{
	}

	public static void StunExplosion(Vector3 explosionPosition, bool affectAudio, float flashSeverityMultiplier, float enemyStunTime, float flashSeverityDistanceRolloff = 1f, bool isHeldItem = false, PlayerControllerB playerHeldBy = null, PlayerControllerB playerThrownBy = null, float addToFlashSeverity = 0f)
	{
	}

	public Vector3 GetGrenadeThrowDestination()
	{
		return default(Vector3);
	}
}
