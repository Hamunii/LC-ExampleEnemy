using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimatedObjectFloatSetter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CwaitForNavMeshBake_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AnimatedObjectFloatSetter _003C_003E4__this;

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
		public _003CwaitForNavMeshBake_003Ed__19(int _003C_003E1__state)
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

	public AnimatedObjectTrigger animatedObjectTrigger;

	public string animatorFloatName;

	private float animatorFloatValue;

	public float valueChangeSpeed;

	public GameObject[] conditionalObjects;

	private int currentFifth;

	private bool boolWasTrue;

	private bool completed;

	public AudioSource thisAudio;

	public AudioClip trueAudio;

	public AudioClip falseAudio;

	public AudioClip completionTrueAudio;

	public AudioClip completionFalseAudio;

	public Transform killPlayerPoint;

	public bool ignoreVerticalDistance;

	public float killRange;

	private bool deactivated;

	private void KillPlayerAtPoint()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CwaitForNavMeshBake_003Ed__19))]
	private IEnumerator waitForNavMeshBake()
	{
		return null;
	}

	private void Update()
	{
	}

	public void SetObjectBasedOnAnimatorFloat()
	{
	}
}
