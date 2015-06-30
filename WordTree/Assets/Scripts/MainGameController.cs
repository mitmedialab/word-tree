using UnityEngine;
using System.Collections;

namespace WordTree
{

	public class MainGameController : MonoBehaviour {

		private GestureManager gestureManager = null;

		void Awake () {
			FindGestureManager();
		}

		void Start () {
		
		}

		void Update () {
		
		}

		private void FindGestureManager ()
		{
			this.gestureManager = (GestureManager)GameObject.FindGameObjectWithTag
				("GestureMan").GetComponent<GestureManager>();
			if(this.gestureManager == null) {
				Debug.Log("ERROR: Could not find gesture manager!");
			} else {
				Debug.Log("Got gesture manager");
			}
		}
	}
}