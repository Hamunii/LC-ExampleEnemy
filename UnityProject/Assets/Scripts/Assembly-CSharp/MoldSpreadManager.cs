using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MoldSpreadManager : NetworkBehaviour
{
	private bool finishedGeneratingMold;

	public PlanetMoldState[] planetMoldStates;

	public List<GameObject> generatedMold;

	public GameObject moldPrefab;

	public Transform moldContainer;

	public int moldBranchCount;

	public int maxSporesInSingleIteration;

	public int maxIterations;

	public int moldDistance;

	private Collider[] weedColliders;

	public GameObject destroyParticle;

	public AudioSource destroyAudio;

	public int iterationsThisDay;

	private void Start()
	{
	}

	public void ResetMoldData()
	{
	}

	public void SyncDestroyedMoldPositions(int[] destroyedMoldSpots)
	{
	}

	public void DestroyMoldAtIndex(int index, float radius = 1.5f, bool playEffect = false)
	{
	}

	public void DestroyMoldAtPosition(Vector3 pos, bool playEffect = false)
	{
	}

	private void CheckIfAllSporesDestroyed()
	{
	}

	private Vector3 ChooseMoldSpawnPosition(Vector3 pos, int xOffset, int zOffset)
	{
		return default(Vector3);
	}

	public void GenerateMold(Vector3 startingPosition, int iterations)
	{
	}

	public void RemoveAllMold()
	{
	}
}
