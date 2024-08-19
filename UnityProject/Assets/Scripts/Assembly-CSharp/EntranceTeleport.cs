using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class EntranceTeleport : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CplayMusicOnDelay_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CplayMusicOnDelay_003Ed__18(int _003C_003E1__state)
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

	public bool isEntranceToBuilding;

	public Transform entrancePoint;

	public Transform exitPoint;

	public int entranceId;

	public StartOfRound playersManager;

	public int audioReverbPreset;

	public AudioSource entrancePointAudio;

	private AudioSource exitPointAudio;

	public AudioClip[] doorAudios;

	private InteractTrigger triggerScript;

	private float checkForEnemiesInterval;

	private bool enemyNearLastCheck;

	private bool gotExitPoint;

	private bool checkedForFirstTime;

	public float timeAtLastUse;

	private void Awake()
	{
	}

	public bool FindExitPoint()
	{
		return false;
	}

	public void TeleportPlayer()
	{
	}

	[IteratorStateMachine(typeof(_003CplayMusicOnDelay_003Ed__18))]
	private IEnumerator playMusicOnDelay()
	{
		return null;
	}

	[ServerRpc(RequireOwnership = false)]
	public void TeleportPlayerServerRpc(int playerObj)
	{
	}

	[ClientRpc]
	public void TeleportPlayerClientRpc(int playerObj)
	{
	}

	private void SetAudioPreset(int playerObj)
	{
	}

	public void PlayAudioAtTeleportPositions()
	{
	}

	private void Update()
	{
	}
}
