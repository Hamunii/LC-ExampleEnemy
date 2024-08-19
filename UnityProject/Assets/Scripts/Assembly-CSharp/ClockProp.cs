using UnityEngine;

public class ClockProp : GrabbableObject
{
	public Transform hourHand;

	public Transform minuteHand;

	public Transform secondHand;

	private float timeOfLastSecond;

	private int secondsPassed;

	private int minutesPassed;

	public AudioSource tickAudio;

	public AudioClip tickSFX;

	public AudioClip tockSFX;

	private bool tickOrTock;

	public override void Update()
	{
	}
}
