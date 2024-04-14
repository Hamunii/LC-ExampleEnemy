namespace DunGen
{
	public sealed class DungeonGraphConnection : DungeonGraphObject
	{
		public DungeonGraphNode A { get; private set; }

		public DungeonGraphNode B { get; private set; }

		public Doorway DoorwayA { get; private set; }

		public Doorway DoorwayB { get; private set; }

		public DungeonGraphConnection(DungeonGraphNode a, DungeonGraphNode b, Doorway doorwayA, Doorway doorwayB)
		{
		}
	}
}
