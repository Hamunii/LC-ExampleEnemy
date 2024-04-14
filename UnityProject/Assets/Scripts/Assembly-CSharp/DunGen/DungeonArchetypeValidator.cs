using DunGen.Graph;

namespace DunGen
{
	public sealed class DungeonArchetypeValidator
	{
		public DungeonFlow Flow { get; private set; }

		public DungeonArchetypeValidator(DungeonFlow flow)
		{
		}

		public bool IsValid()
		{
			return false;
		}

		private void LogError(string format, params object[] args)
		{
		}

		private void LogWarning(string format, params object[] args)
		{
		}
	}
}
