using UnityEngine;

public class ClipboardItem : GrabbableObject
{
	public bool truckManual;

	private bool parentedToTruck;

	public int currentPage;

	public Animator clipboardAnimator;

	public AudioClip[] turnPageSFX;

	public AudioSource thisAudio;

	public override void Update()
	{
	}

	public override void PocketItem()
	{
	}

	public override void ItemInteractLeftRight(bool right)
	{
	}

	public override void DiscardItem()
	{
	}

	public override void EquipItem()
	{
	}
}
