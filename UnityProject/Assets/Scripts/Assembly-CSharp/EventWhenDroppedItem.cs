using System;
using UnityEngine;

public class EventWhenDroppedItem : GrabbableObject
{
	public float noiseLoudness;

	public float noiseRange;

	[Space(3f)]
	private int timesPlayedInSameSpot;

	private Vector3 lastPositionDropped;

	public float lastPositionDroppedThresholdDistance;

	public int effectWearOffMultiplier;

	public AudioSource itemAudio;

	private System.Random bellPitchRandom;

	public override void Start()
	{
	}

	public override void PlayDropSFX()
	{
	}
}
