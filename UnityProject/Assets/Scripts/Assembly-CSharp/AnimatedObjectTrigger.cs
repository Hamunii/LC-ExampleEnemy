using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

public class AnimatedObjectTrigger : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CwaitForNavMeshBake_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AnimatedObjectTrigger _003C_003E4__this;

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
		public _003CwaitForNavMeshBake_003Ed__28(int _003C_003E1__state)
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

	public Animator triggerAnimator;

	public Animator triggerAnimatorB;

	public bool isBool;

	public string animationString;

	public bool boolValue;

	public bool setInitialState;

	public bool initialBoolState;

	[Space(5f)]
	public AudioSource thisAudioSource;

	public AudioClip[] boolFalseAudios;

	public AudioClip[] boolTrueAudios;

	public AudioClip[] secondaryAudios;

	[Space(4f)]
	public AudioClip playWhileTrue;

	public bool resetAudioWhenFalse;

	public bool makeAudibleNoise;

	public float noiseLoudness;

	[Space(3f)]
	public ParticleSystem playParticle;

	public int playParticleOnTimesTriggered;

	[Space(4f)]
	private StartOfRound playersManager;

	private bool localPlayerTriggered;

	public BooleanEvent onTriggerBool;

	[Space(5f)]
	public bool playAudiosInSequence;

	private int timesTriggered;

	public bool triggerByChance;

	public float chancePercent;

	private bool hasInitializedRandomSeed;

	public System.Random triggerRandom;

	private float audioTime;

	public void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CwaitForNavMeshBake_003Ed__28))]
	private IEnumerator waitForNavMeshBake()
	{
		return null;
	}

	public void SetInitialState()
	{
	}

	public void TriggerAnimation(PlayerControllerB playerWhoTriggered)
	{
	}

	public void TriggerAnimationNonPlayer(bool playSecondaryAudios = false, bool overrideBool = false, bool setBoolFalse = false)
	{
	}

	public void InitializeRandomSeed()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	private void UpdateAnimServerRpc(bool setBool, bool playSecondaryAudios = false, int playerWhoTriggered = -1)
	{
	}

	[ClientRpc]
	private void UpdateAnimClientRpc(bool setBool, bool playSecondaryAudios = false, int playerWhoTriggered = -1)
	{
	}

	public void SetBoolOnClientOnly(bool setTo)
	{
	}

	public void SetBoolOnClientOnlyInverted(bool setTo)
	{
	}

	private void SetParticleBasedOnBoolean()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	private void UpdateAnimTriggerServerRpc()
	{
	}

	[ClientRpc]
	private void UpdateAnimTriggerClientRpc()
	{
	}

	private void PlayAudio(bool boolVal, bool playSecondaryAudios = false)
	{
	}
}
