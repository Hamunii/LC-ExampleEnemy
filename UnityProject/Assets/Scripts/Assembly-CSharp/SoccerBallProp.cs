using Unity.Netcode;
using UnityEngine;

public class SoccerBallProp : GrabbableObject
{
	[Space(5f)]
	public float ballHitUpwardAmount;

	public AnimationCurve grenadeFallCurve;

	public AnimationCurve grenadeVerticalFallCurve;

	public AnimationCurve soccerBallVerticalOffset;

	public AnimationCurve grenadeVerticalFallCurveNoBounce;

	private Ray soccerRay;

	private RaycastHit soccerHit;

	private int soccerBallMask;

	private int previousPlayerHit;

	private float hitTimer;

	public AudioClip[] hitBallSFX;

	public AudioClip[] ballHitFloorSFX;

	public AudioSource soccerBallAudio;

	public override void ActivatePhysicsTrigger(Collider other)
	{
	}

	public Vector3 GetSoccerKickDestination(Vector3 hitFromPosition)
	{
		return default(Vector3);
	}

	public void BeginKickBall(Vector3 hitFromPosition, bool hitByEnemy)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void KickBallServerRpc(Vector3 dest, int playerWhoKicked, bool setInElevator, bool setInShipRoom)
	{
	}

	[ClientRpc]
	public void KickBallClientRpc(Vector3 dest, int playerWhoKicked, bool setInElevator, bool setInShipRoom)
	{
	}

	private void KickBallLocalClient(Vector3 destinationPos, bool setInElevator, bool setInShipRoom)
	{
	}

	public override void FallWithCurve()
	{
	}

	public override void PlayDropSFX()
	{
	}
}
