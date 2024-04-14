using Unity.Netcode;
using UnityEngine;

public class BridgeTriggerType2 : NetworkBehaviour
{
	private int timesTriggered;

	public AnimatedObjectTrigger animatedObjectTrigger;

	private bool bridgeFell;

	private void OnTriggerEnter(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void AddToBridgeInstabilityServerRpc()
	{
	}
}
