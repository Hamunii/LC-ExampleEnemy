using UnityEngine;

public class PlayerPhysicsRegion : MonoBehaviour
{
	public Transform physicsTransform;

	public bool allowDroppingItems;

	private float checkInterval;

	private bool hasLocalPlayer;

	public int priority;

	public bool disablePhysicsRegion;

	public Collider physicsCollider;

	public Collider itemDropCollider;

	public float maxTippingAngle;

	private bool removePlayerNextFrame;

	private void OnDisable()
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private bool IsPhysicsRegionActive()
	{
		return false;
	}

	private void Update()
	{
	}
}
