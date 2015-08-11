using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class IntroDirector : MonoBehaviour {


		void Start () {

			GameObject[] kids = GameObject.FindGameObjectsWithTag ("Kid");
			foreach (GameObject kid in kids) {
				kid.AddComponent<PulseBehavior> ().StartPulsing (kid);
				kid.AddComponent<GestureManager> ().AddAndSubscribeToGestures (kid);
			}
	
		}
	

	}
}
