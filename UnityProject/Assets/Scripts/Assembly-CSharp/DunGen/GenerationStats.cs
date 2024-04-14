using System.Diagnostics;

namespace DunGen
{
	public sealed class GenerationStats
	{
		private Stopwatch stopwatch;

		private GenerationStatus generationStatus;

		public int MainPathRoomCount { get; private set; }

		public int BranchPathRoomCount { get; private set; }

		public int TotalRoomCount { get; private set; }

		public int MaxBranchDepth { get; private set; }

		public int TotalRetries { get; private set; }

		public int PrunedBranchTileCount { get; internal set; }

		public float PreProcessTime { get; private set; }

		public float MainPathGenerationTime { get; private set; }

		public float BranchPathGenerationTime { get; private set; }

		public float PostProcessTime { get; private set; }

		public float TotalTime { get; private set; }

		internal void Clear()
		{
		}

		internal void IncrementRetryCount()
		{
		}

		internal void SetRoomStatistics(int mainPathRoomCount, int branchPathRoomCount, int maxBranchDepth)
		{
		}

		internal void BeginTime(GenerationStatus status)
		{
		}

		internal void EndTime()
		{
		}

		public GenerationStats Clone()
		{
			return null;
		}
	}
}
