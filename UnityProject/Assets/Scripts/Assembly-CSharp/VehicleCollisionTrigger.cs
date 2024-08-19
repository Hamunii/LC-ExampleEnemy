using UnityEngine;

public class VehicleCollisionTrigger : MonoBehaviour
{
	public VehicleController mainScript;

	private float timeSinceHittingPlayer;

	private float timeSinceHittingEnemy;

	public BoxCollider insideTruckNavMeshBounds;

	public EnemyAI[] enemiesLastHit;

	private int enemyIndex;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
