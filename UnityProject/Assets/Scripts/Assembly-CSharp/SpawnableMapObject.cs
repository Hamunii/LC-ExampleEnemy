using System;
using UnityEngine;

[Serializable]
public class SpawnableMapObject
{
	public GameObject prefabToSpawn;

	public bool spawnFacingAwayFromWall;

	public bool spawnFacingWall;

	[Space(3f)]
	public bool spawnWithBackToWall;

	public bool spawnWithBackFlushAgainstWall;

	[Space(2f)]
	public bool requireDistanceBetweenSpawns;

	public bool disallowSpawningNearEntrances;

	[Tooltip("Y Axis is the amount to be spawned; X axis should be from 0 to 1 and is randomly picked from.")]
	public AnimationCurve numberToSpawn;
}
