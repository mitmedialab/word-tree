using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("LevelIcon");
			foreach (GameObject go in gos) {
				go.AddComponent<GestureManager> ().AddAndSubscribeToGestures (go);

				if (!IsLevelCompleted(go.name)) {
					go.AddComponent<PulseBehavior> ().StartPulsing (go);
				}

				if (IsLevelCompleted(go.name)){
					Debug.Log ("Level Completed: " + go.name);
					Debug.Log ("Dimmed " + go.name);
					go.GetComponent<SpriteRenderer>().color = Color.gray;
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
