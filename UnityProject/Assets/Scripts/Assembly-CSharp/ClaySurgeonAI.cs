using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ClaySurgeonAI : EnemyAI
{
	public float minDistance;

	public float maxDistance;

	[Space(5f)]
	public float jumpSpeed;

	public float jumpTime;

	public float startingInterval;

	public float endingInterval;

	public int snareBeatAmount;

	[Space(3f)]
	public float currentInterval;

	private float beatTimer;

	[Space(5f)]
	public ClaySurgeonAI master;

	private bool isMaster;

	[Space(5f)]
	public bool isJumping;

	private float jumpTimer;

	private bool jumpingLastFrame;

	private int beatsSinceSeeingPlayer;

	private bool hasLOS;

	public SimpleEvent SendDanceBeat;

	private int currentHour;

	private bool jumpCycle;

	public AISearchRoutine searchRoutine;

	private float timeSinceSnip;

	private float snareIntervalTimer;

	public AudioSource musicAudio;

	public AudioSource musicAudio2;

	public AudioClip snareDrum;

	public AudioClip[] paradeClips;

	public AudioClip snipScissors;

	private int previousParadeClip;

	public List<ClaySurgeonAI> allClaySurgeons;

	private int snareNum;

	public float snareOffset;

	public MeshRenderer[] scissorBlades;

	public SkinnedMeshRenderer skin;

	public Material scissorGuyMat;

	private Material thisMaterial;

	private RaycastHit hit;

	private bool listeningToMasterSurgeon;

	private bool choseMasterSurgeon;

	private void Awake()
	{
	}

	[ClientRpc]
	public void SyncMasterClaySurgeonClientRpc()
	{
	}

	public void ListenToMasterSurgeon()
	{
	}

	public override void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void ChooseMasterSurgeon()
	{
	}

	public override void OnDestroy()
	{
	}

	public override void DoAIInterval()
	{
	}

	private void PlayMusic()
	{
	}

	private void SetMusicVolume()
	{
	}

	private void SetVisibility()
	{
	}

	public override void Update()
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	[ServerRpc(RequireOwnership = false)]
	public void KillPlayerServerRpc()
	{
	}

	[ClientRpc]
	public void KillPlayerClientRpc()
	{
	}

	private void DoBeatOnOwnerClient()
	{
	}

	[ServerRpc]
	public void DoBeatServerRpc()
	{
	}

	[ClientRpc]
	public void DoBeatClientRpc()
	{
	}

	private void HourChanged()
	{
	}

	private void DanceBeat()
	{
	}

	public override void AnimationEventA()
	{
	}

	private void SetDanceClock()
	{
	}
}
