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

				LevelCreation.CreateLevel ("Fruits",new string[] {"Apple","Banana","Orange","Grape"},new float[,]{{.7f,.7f},{1,1},{1,1},{1,1}},4);
				break;

				
			}
		}

	}
}
