using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.ThunderAndLightning
{
	public class LightningCustomTransformStateInfo
	{
		public Vector3 BoltStartPosition;

		public Vector3 BoltEndPosition;

		public Transform Transform;

		public Transform StartTransform;

		public Transform EndTransform;

		public object UserInfo;

		private static readonly List<LightningCustomTransformStateInfo> cache;

		public LightningCustomTransformState State { get; set; }

		public LightningBoltParameters Parameters { get; set; }

		public static LightningCustomTransformStateInfo GetOrCreateStateInfo()
		{
			return null;
		}

		public static void ReturnStateInfoToCache(LightningCustomTransformStateInfo info)
		{
		}
	}
}
