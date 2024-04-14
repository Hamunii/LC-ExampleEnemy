using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace DunGen
{
	public sealed class TileProxy
	{
		private List<DoorwayProxy> doorways;

		public GameObject Prefab { get; private set; }

		public Tile PrefabTile { get; private set; }

		public TilePlacementData Placement { get; internal set; }

		public DoorwayProxy Entrance { get; private set; }

		public DoorwayProxy Exit { get; private set; }

		public ReadOnlyCollection<DoorwayProxy> Doorways { get; private set; }

		public IEnumerable<DoorwayProxy> UsedDoorways => null;

		public IEnumerable<DoorwayProxy> UnusedDoorways => null;

		public TileProxy(TileProxy existingTile)
		{
		}

		public TileProxy(GameObject prefab, bool ignoreSpriteRendererBounds, Vector3 upVector)
		{
		}

		public void PositionBySocket(DoorwayProxy myDoorway, DoorwayProxy otherDoorway)
		{
		}

		private Vector3 CalculateOverlap(TileProxy other)
		{
			return default(Vector3);
		}

		public bool IsOverlapping(TileProxy other, float maxOverlap)
		{
			return false;
		}

		public bool IsOverlappingOrOverhanging(TileProxy other, AxisDirection upDirection, float maxOverlap)
		{
			return false;
		}
	}
}
