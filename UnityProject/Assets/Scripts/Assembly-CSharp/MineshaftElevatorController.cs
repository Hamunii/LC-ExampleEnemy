using Unity.Netcode;
using UnityEngine;

public class MineshaftElevatorController : NetworkBehaviour
{
	public Animator elevatorAnimator;

	public Transform elevatorPoint;

	public bool elevatorFinishedMoving;

	public float elevatorFinishTimer;

	public bool elevatorIsAtBottom;

	public bool elevatorCalled;

	public bool elevatorMovingDown;

	private bool movingDownLastFrame;

	public bool calledDown;

	public float callCooldown;

	public AudioSource elevatorAudio;

	public AudioClip elevatorStartUpSFX;

	public AudioClip elevatorStartDownSFX;

	public AudioClip elevatorTravelSFX;

	public AudioClip elevatorFinishUpSFX;

	public AudioClip elevatorFinishDownSFX;

	public GameObject elevatorCalledBottomButton;

	public GameObject elevatorCalledTopButton;

	public Transform elevatorTopPoint;

	public Transform elevatorBottomPoint;

	public Transform elevatorInsidePoint;

	public bool elevatorDoorOpen;

	public AudioSource elevatorJingleMusic;

	private bool playMusic;

	private bool startedMusic;

	private float stopPlayingMusicTimer;

	[ServerRpc]
	public void SetElevatorMusicServerRpc(bool setOn)
	{
	}

	[ClientRpc]
	public void SetElevatorMusicClientRpc(bool setOn)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Update()
	{
	}

	private void SwitchElevatorDirection()
	{
	}

	[ClientRpc]
	public void SetElevatorFinishedMovingClientRpc(bool finished)
	{
	}

	public void AnimationEvent_ElevatorFinishTop()
	{
	}

	public void AnimationEvent_ElevatorStartFromBottom()
	{
	}

	public void AnimationEvent_ElevatorHitBottom()
	{
	}

	public void AnimationEvent_ElevatorTravel()
	{
	}

	public void AnimationEvent_ElevatorFinishBottom()
	{
	}

	private void ShakePlayerCamera(bool shakeHard)
	{
	}

	[ServerRpc]
	public void ElevatorFinishServerRpc(bool atTop)
	{
	}

	[ClientRpc]
	public void ElevatorFinishClientRpc(bool atTop)
	{
	}

	private void PlayFinishAudio(bool atTop)
	{
	}

	[ServerRpc]
	public void SetElevatorMovingServerRpc(bool movingDown)
	{
	}

	[ClientRpc]
	public void SetElevatorMovingClientRpc(bool movingDown)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void CallElevatorServerRpc(bool callDown)
	{
	}

	public void CallElevatorOnServer(bool callDown)
	{
	}

	public void SetElevatorDoorOpen()
	{
	}

	public void SetElevatorDoorClosed()
	{
	}

	[ClientRpc]
	public void SetElevatorCalledClientRpc(bool setCalled, bool elevatorDown)
	{
	}

	public void CallElevator(bool callDown)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void PressElevatorButtonServerRpc()
	{
	}

	public void PressElevatorButtonOnServer(bool requireFinishedMoving = false)
	{
	}

	public void PressElevatorButton()
	{
	}
}
