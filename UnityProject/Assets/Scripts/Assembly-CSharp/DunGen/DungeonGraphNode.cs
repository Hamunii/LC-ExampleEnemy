using System.Collections.Generic;

namespace DunGen
{
	public sealed class DungeonGraphNode : DungeonGraphObject
	{
		public List<DungeonGraphConnection> Connections;

		public Tile Tile { get; private set; }

		public DungeonGraphNode(Tile tile)
		{
		}

		internal void AddConnection(DungeonGraphConnection connection)
		{
		}
	}
}
