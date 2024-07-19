using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ItemDropship : NetworkBehaviour
{
	public bool deliveringOrder;

	public bool shipLanded;

	public bool shipDoorsOpened;

	public Animator shipAnimator;

	public float shipTimer;

	public bool playersFirstOrder;

	private StartOfRound playersManager;

	private Terminal terminalScript;

	private List<int> itemsToDeliver;

	public Transform[] itemSpawnPositions;

	private float noiseInterval;

	private int timesPlayedWithoutTurningOff;

	public InteractTrigger triggerScript;

	public LineRenderer[] ropes;

	public Transform[] ropeDestinations;

	public Transform deliverVehiclePoint;

	public bool deliveringVehicle;

	public bool untetheredVehicle;

	private void Start()
	{
	}

	public void UntetherVehicle()
	{
	}

	[ServerRpc]
	public void UntetherVehicleServerRpc()
	{
	}

	[ClientRpc]
	public void UntetherVehicleClientRpc()
	{
	}

	private void FinishDeliveringVehicleOnServer()
	{
	}

	[ServerRpc]
	public void FinishDeliveringVehicleServerRpc()
	{
	}

	[ClientRpc]
	public void FinishDeliveringVehicleClientRpc()
	{
	}

	private void Update()
	{
	}

	public void TryOpeningShip()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void OpenShipServerRpc()
	{
	}

	private void OpenShipDoorsOnServer()
	{
	}

	[ClientRpc]
	public void OpenShipClientRpc()
	{
	}

	public void ShipLandedAnimationEvent()
	{
	}

	private void DeliverVehicleOnServer()
	{
	}

	[ClientRpc]
	public void DeliverVehicleClientRpc()
	{
	}

	private void LandShipOnServer()
	{
	}

	[ClientRpc]
	public void LandShipClientRpc()
	{
	}

	[ClientRpc]
	public void ShipLeaveClientRpc()
	{
	}

	public void ShipLeave()
	{
	}

	public void ShipLandedInAnimation()
	{
	}
}
