using UnityEngine;

namespace DunGen
{
	public sealed class DoorwayProxy
	{
		public bool Used => false;

		public TileProxy TileProxy { get; private set; }

		public int Index { get; private set; }

		public DoorwaySocket Socket { get; private set; }

		public Doorway DoorwayComponent { get; private set; }

		public Vector3 LocalPosition { get; private set; }

		public Quaternion LocalRotation { get; private set; }

		public DoorwayProxy ConnectedDoorway { get; private set; }

		public Vector3 Forward => default(Vector3);

		public Vector3 Up => default(Vector3);

		public Vector3 Position => default(Vector3);

		public DoorwayProxy(TileProxy tileProxy, DoorwayProxy other)
		{
		}

		public DoorwayProxy(TileProxy tileProxy, int index, Doorway doorwayComponent, Vector3 localPosition, Quaternion localRotation)
		{
		}

		public static void Connect(DoorwayProxy a, DoorwayProxy b)
		{
		}

		public void Disconnect()
		{
		}
	}
}
