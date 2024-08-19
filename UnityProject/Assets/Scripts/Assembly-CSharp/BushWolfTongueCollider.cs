using GameNetcodeStuff;
using UnityEngine;

public class BushWolfTongueCollider : MonoBehaviour, IHittable
{
	public BushWolfEnemy bushWolfScript;

	bool IHittable.Hit(int force, Vector3 hitDirection, PlayerControllerB playerWhoHit, bool playHitSFX, int hitID)
	{
		return false;
	}
}
