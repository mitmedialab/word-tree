using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("LevelIcon");
			foreach (GameObject go in gos) {
				go.AddComponent<GestureManager> ().AddAndSubscribeToGestures (go);
				go.AddComponent<PulseBehavior> ().StartPulsing (go);
			}
		
		}
		

	}
}
