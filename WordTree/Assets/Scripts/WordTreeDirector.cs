using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("LevelIcon");
			foreach (GameObject go in gos) {
				go.AddComponent<GestureManager> ().AddAndSubscribeToGestures (go);

				go.AddComponent<PulseBehavior> ().StartPulsing (go,1.0f);


				if (!IsLevelCompleted(go.name))
					//go.GetComponent<SpriteRenderer>().color = Color.grey;

				if (IsLevelCompleted(go.name)){
					Debug.Log ("Level Completed: " + go.name);
					Debug.Log ("Brightened " + go.name);
					go.GetComponent<SpriteRenderer>().color = Color.white;
				}

			}
		
		}

		bool IsLevelCompleted(string level)
		{
			if (GameDirector.completedLevels.Contains (level))
				return true;
			return false;
			
		}
		

	}
}
