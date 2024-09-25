using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ExampleContent.Items;
public class ExampleBigPresent : GrabbableObject
{
    private List<Item> items = new();
    private System.Random presentRandom = new();
    
    public override void Start()
    {
        base.Start();
        presentRandom = new System.Random(StartOfRound.Instance.randomMapSeed);
        foreach (SpawnableItemWithRarity spawnableItemWithRarity in RoundManager.Instance.currentLevel.spawnableScrap)
        {
            items.Add(spawnableItemWithRarity.spawnableItem);
        }
    }

    public override void ItemActivate(bool used, bool buttonDown = true)
    {
        base.ItemActivate(used, buttonDown);
        if (playerHeldBy == null || playerHeldBy != GameNetworkManager.Instance.localPlayerController) return;
        SpawnItemServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SpawnItemServerRpc()
    {
        // spawn 10 to 20 different scraps from the level it spawned from.
        int randomIterateNumber = presentRandom.Next(10, 21);
        for (int i = 0; i < randomIterateNumber; i++)
        {
            Item item = items[presentRandom.Next(0, items.Count)];
            var obj = GameObject.Instantiate(item.spawnPrefab, RoundManager.Instance.GetRandomNavMeshPositionInRadiusSpherical(this.transform.position, 5f, default), Quaternion.Euler(item.restingRotation), StartOfRound.Instance.propsContainer);
            obj.GetComponent<NetworkObject>().Spawn();
        }
    }
}