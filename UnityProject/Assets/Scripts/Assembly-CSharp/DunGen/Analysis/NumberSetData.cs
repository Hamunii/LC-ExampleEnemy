using System.Collections.Generic;

namespace DunGen.Analysis
{
	public sealed class NumberSetData
	{
		public float Min { get; private set; }

		public float Max { get; private set; }

		public float Average { get; private set; }

		public float StandardDeviation { get; private set; }

		public NumberSetData(IEnumerable<float> values)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
