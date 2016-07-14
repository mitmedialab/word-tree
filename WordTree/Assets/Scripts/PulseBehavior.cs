using UnityEngine;
using System.Collections;

//<summary>
// The object this behavior is attached to will "pulse", enlarging
// a little and shrinking back to the original size repeatedly
//</summary>
namespace WordTree
{
	public class PulseBehavior : MonoBehaviour
	{
		//<summary>
		// Starts pulsing an object
		// Indicates that the object can be interacted with
		//</summary>
		public void StartPulsing(GameObject go, float delayTime = 0)
		{
			// how much to scale up object by
			float scaleUpBy = 1.2f;
			// time to complete one pulse, randomized so each object is pulsing at different rate (looks better)
			float time = Random.Range(.8f, 1.0f); 
			LeanTween.scale(go, new Vector3(go.transform.localScale.x * scaleUpBy,
				go.transform.localScale.y * scaleUpBy, go.transform.localScale.z * scaleUpBy), time)
				.setEase(LeanTweenType.easeOutSine).setLoopPingPong().setDelay(delayTime);
		}
	
		// Stops pulsing the object
		public void StopPulsing(GameObject go)
		{
			LeanTween.cancel(go);
		}

	}
}
