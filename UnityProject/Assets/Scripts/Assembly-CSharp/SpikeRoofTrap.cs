using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class SpikeRoofTrap : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSlamSpikeTrapSequence_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpikeRoofTrap _003C_003E4__this;

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
		public _003CSlamSpikeTrapSequence_003Ed__25(int _003C_003E1__state)
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

	public bool slammingDown;

	public float timeSinceMovingUp;

	public bool trapActive;

	public Animator spikeTrapAnimator;

	private Coroutine slamCoroutine;

	private List<DeadBodyInfo> deadBodiesSlammed;

	private List<GameObject> slammedBodyStickingPoints;

	public GameObject deadBodyStickingPointPrefab;

	public Transform stickingPointsContainer;

	public Transform laserEye;

	private RaycastHit hit;

	private bool slamOnIntervals;

	private float slamInterval;

	private Light laserLight;

	public AudioSource spikeTrapAudio;

	private EntranceTeleport nearEntrance;

	public void ToggleSpikesEnabled(bool enabled)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void ToggleSpikesServerRpc(bool enabled)
	{
	}

	[ClientRpc]
	public void ToggleSpikesClientRpc(bool enabled)
	{
	}

	private void ToggleSpikesEnabledLocalClient(bool enabled)
	{
	}

	public void Start()
	{
	}

	public void OnTriggerStay(Collider other)
	{
	}

	private void StickBodyToSpikes(DeadBodyInfo body)
	{
	}

	public void Update()
	{
	}

	public void SpikeTrapSlam()
	{
	}

	[IteratorStateMachine(typeof(_003CSlamSpikeTrapSequence_003Ed__25))]
	private IEnumerator SlamSpikeTrapSequence()
	{
		return null;
	}

	private void SetRandomSpikeTrapAudioPitch()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void SpikeTrapSlamServerRpc(int playerWhoTriggered)
	{
	}

	[ClientRpc]
	public void SpikeTrapSlamClientRpc(int playerWhoTriggered)
	{
	}
}
