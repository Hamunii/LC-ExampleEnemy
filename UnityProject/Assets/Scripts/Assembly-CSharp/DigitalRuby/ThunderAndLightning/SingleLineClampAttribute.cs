namespace DigitalRuby.ThunderAndLightning
{
	public class SingleLineClampAttribute : SingleLineAttribute
	{
		public double MinValue { get; private set; }

		public double MaxValue { get; private set; }

		public SingleLineClampAttribute(string tooltip, double minValue, double maxValue)
			: base(null)
		{
		}
	}
}
