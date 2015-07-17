using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class ChooseWordDirector : MonoBehaviour {


		void Start () {

			CreateLevelSwitch (GameDirector.currentLevel);

			GameObject arrow = GameObject.FindGameObjectWithTag ("Arrow");
			arrow.AddComponent<GestureManager> ().AddAndSubscribeToGestures (arrow);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos)
				go.GetComponent<PulseBehavior>().StartPulsing(go);

		}
		

		void CreateLevelSwitch(string level)
		{
			switch(level)
			{
				
			case "Fruits":

				LevelCreation.CreateLevel ("Fruits",new string[] {"Apple","Banana","Grape","Orange","Peach"},new float[] {.7f, 1f, 1f, 1f, 1.4f}, 5);
				break;

			case "Animals":
				
				LevelCreation.CreateLevel ("Animals",new string[] {"Bird","Camel","Fish","Goat","Horse"},new float[] {.6f, .7f, 1.1f, .05f, .8f}, 5);
				break;

				
			}
		}

	}
}
