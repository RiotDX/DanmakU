// Copyright (c) 2015 James Liu
//	
// See the LISCENSE file for copying permission.

using UnityEngine;

namespace DanmakU.DanmakuControllers {

	[System.Serializable]
	public class ColorFadeController : IDanmakuController {

		[SerializeField]
		private Color endColor;

		[SerializeField]
		private float startTime;

		[SerializeField]
		private float endTime;

		public void Update (Danmaku projectile, float dt) {
			float bulletTime = projectile.Time;
			Color startColor = projectile.Prefab.Color;
//			Debug.Log (bulletTime);
			if (bulletTime < startTime)
				projectile.Color = startColor;
			else if (bulletTime > endTime)
				projectile.Color = endColor;
			else {
				if(endTime <= startTime)
					projectile.Color = endColor;
				else
					projectile.Color = Color.Lerp (startColor, endColor, (bulletTime - startTime) / (endTime - startTime));
			}
		}
	}
}