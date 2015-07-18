﻿using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class PulseBehavior : MonoBehaviour {

		public void StartPulsing (GameObject go)
		{
			float scaleUpBy = 1.1f; 
			
			LeanTween.scale(go, new Vector3(go.transform.localScale.x * scaleUpBy, go.transform.localScale.y * scaleUpBy, 
			                                go.transform.localScale.z * scaleUpBy), 1.0f)
				.setEase(LeanTweenType.easeOutSine).setLoopPingPong();
		}
		
		public void StopPulsing (GameObject go)
		{
			LeanTween.cancel (go);
		}

	}
}