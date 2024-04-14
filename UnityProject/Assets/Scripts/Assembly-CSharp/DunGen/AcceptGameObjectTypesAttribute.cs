using System;
using UnityEngine;

namespace DunGen
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class AcceptGameObjectTypesAttribute : PropertyAttribute
	{
		public GameObjectFilter Filter { get; private set; }

		public AcceptGameObjectTypesAttribute(GameObjectFilter filter)
		{
		}
	}
}
