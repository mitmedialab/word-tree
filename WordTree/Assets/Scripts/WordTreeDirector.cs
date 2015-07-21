using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("LevelIcon");
			foreach (GameObject go in gos) {

				go.AddComponent<GestureManager>().AddAndSubscribeToGestures(go);

				go.AddComponent<PulseBehavior> ().StartPulsing (go);


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

		public static void CreateModeChoices()
		{
			int z = -2;

			ObjectProperties learn = ObjectProperties.CreateInstance ("Learn", "Button", new Vector3 (-1.6f, 0, z-1), new Vector3 (2.0f, 2.0f, 1), "Learn", null);
			GameDirector.InstantiateObject (learn);

			ObjectProperties play = ObjectProperties.CreateInstance ("Play", "Button", new Vector3 (1.7f, 0, z-1), new Vector3 (2.0f, 2.0f, 1), "Play", null);
			GameDirector.InstantiateObject (play);

			ObjectProperties exit = ObjectProperties.CreateInstance ("Exit", "Button", new Vector3 (-3.5f, 3.5f, z-2), new Vector3 (.5f, .5f, 1), "Exit", null);
			GameDirector.InstantiateObject (exit);

			ObjectProperties border = ObjectProperties.CreateInstance ("Border", "Untagged", new Vector3 (0, 0, z), new Vector3 (1.84f, 2.45f, 1), "Border", null);
			GameDirector.InstantiateObject (border);

			GameObject background = GameObject.Find ("Background");
			background.GetComponent<SpriteRenderer> ().color = Color.grey;

			GameObject.Find ("Learn").GetComponent<PulseBehavior> ().StartPulsing (GameObject.Find ("Learn"));
			GameObject.Find ("Play").GetComponent<PulseBehavior> ().StartPulsing (GameObject.Find ("Play"));
		}

		

	}
}
