using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

public class CaveDwellerPhysicsProp : GrabbableObject
{
	public CaveDwellerAI caveDwellerScript;

	public PlayerControllerB previousPlayerHeldBy;

	private float timeSinceRockingBaby;

	public override void ItemActivate(bool used, bool buttonDown = true)
	{
	}

	[ServerRpc]
	public void SetRockingBabyServerRpc(bool rockHard)
	{
	}

	[ClientRpc]
	public void SetRockingBabyClientRpc(bool rockHard)
	{
	}

	[ServerRpc]
	public void StopRockingBabyServerRpc()
	{
	}

	[ClientRpc]
	public void StopRockingBabyClientRpc()
	{
	}

	public override void EquipItem()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void DropBabyServerRpc(int playerId)
	{
	}

	[ClientRpc]
	public void DropBabyClientRpc(int playerId)
	{
	}

	public override void FallWithCurve()
	{
	}

	public override void Start()
	{
	}

	public override void Update()
	{
	}

	public override void LateUpdate()
	{
	}

	public override void EnableItemMeshes(bool enable)
	{
	}

	public override void DiscardItem()
	{
	}
}
