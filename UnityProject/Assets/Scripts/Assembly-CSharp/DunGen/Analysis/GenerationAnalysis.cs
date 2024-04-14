using System.Collections.Generic;

namespace DunGen.Analysis
{
	public class GenerationAnalysis
	{
		private readonly List<GenerationStats> statsSet;

		public int TargetIterationCount { get; private set; }

		public int IterationCount { get; private set; }

		public NumberSetData MainPathRoomCount { get; private set; }

		public NumberSetData BranchPathRoomCount { get; private set; }

		public NumberSetData TotalRoomCount { get; private set; }

		public NumberSetData MaxBranchDepth { get; private set; }

		public NumberSetData TotalRetries { get; private set; }

		public NumberSetData PreProcessTime { get; private set; }

		public NumberSetData MainPathGenerationTime { get; private set; }

		public NumberSetData BranchPathGenerationTime { get; private set; }

		public NumberSetData PostProcessTime { get; private set; }

		public NumberSetData TotalTime { get; private set; }

		public float AnalysisTime { get; private set; }

		public int SuccessCount { get; private set; }

		public float SuccessPercentage => 0f;

		public GenerationAnalysis(int targetIterationCount)
		{
		}

		public void Clear()
		{
		}

		public void Add(GenerationStats stats)
		{
		}

		public void IncrementSuccessCount()
		{
		}

		public void Analyze()
		{
		}
	}
}
