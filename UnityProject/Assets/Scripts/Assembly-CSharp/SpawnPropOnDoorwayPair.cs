using DunGen;
using DunGen.Tags;
using UnityEngine;

public class SpawnPropOnDoorwayPair : MonoBehaviour
{
	public Tag CaveTag;

	private TileConnectionRule rule;

	public GameObject caveEntranceProp;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private TileConnectionRule.ConnectionResult CanTilesConnect(Tile tileA, Tile tileB, Doorway doorwayA, Doorway doorwayB)
	{
		return default(TileConnectionRule.ConnectionResult);
	}
}
