using UnityEngine;

public class ButlerBeesEnemyAI : EnemyAI
{
	private float timeAtLastHurtingPlayer;

	public AISearchRoutine searchForPlayers;

	private float chasePlayerTimer;

	private float timeAtSpawning;

	public AudioSource buzzing;

	public override void Start()
	{
	}

	public override void OnCollideWithPlayer(Collider other)
	{
	}

	public override void DoAIInterval()
	{
	}
}
