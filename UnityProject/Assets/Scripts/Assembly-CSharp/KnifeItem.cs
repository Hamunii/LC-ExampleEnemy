using System.Collections.Generic;
using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

public class KnifeItem : GrabbableObject
{
	public AudioSource knifeAudio;

	private List<RaycastHit> objectsHitByKnifeList;

	public PlayerControllerB previousPlayerHeldBy;

	private RaycastHit[] objectsHitByKnife;

	public int knifeHitForce;

	public AudioClip[] hitSFX;

	public AudioClip[] swingSFX;

	private int knifeMask;

	private float timeAtLastDamageDealt;

	public ParticleSystem bloodParticle;

	public override void ItemActivate(bool used, bool buttonDown = true)
	{
	}

	public override void PocketItem()
	{
	}

	public override void DiscardItem()
	{
	}

	public override void EquipItem()
	{
	}

	public void HitKnife(bool cancel = false)
	{
	}

	[ServerRpc]
	public void HitShovelServerRpc(int hitSurfaceID)
	{
	}

	[ClientRpc]
	public void HitShovelClientRpc(int hitSurfaceID)
	{
	}

	private void HitSurfaceWithKnife(int hitSurfaceID)
	{
	}
}
