using System;

[Serializable]
public class BabyPlayerMemory
{
	public ulong playerId;

	public float likeMeter;

	public float timeSpentSoothing;

	public int orderSeen;

	public float timeAtLastNoticing;

	public float timeAtLastSighting;

	public bool isPlayerDead;

	public BabyPlayerMemory(ulong player)
	{
	}
}
