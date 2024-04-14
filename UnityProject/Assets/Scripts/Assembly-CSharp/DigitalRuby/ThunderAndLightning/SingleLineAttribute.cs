using UnityEngine;

namespace DigitalRuby.ThunderAndLightning
{
	public class SingleLineAttribute : PropertyAttribute
	{
		public string Tooltip { get; private set; }

		public SingleLineAttribute(string tooltip)
		{
		}
	}
}
