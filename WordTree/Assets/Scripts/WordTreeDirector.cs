using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			ProgressManager.InitiateLevelList ();
			ProgressManager.UnlockNextLevel (null);

			ProgressManager.AddUnlockedLevel ("Transportation1");
			ProgressManager.AddUnlockedLevel ("Bathroom1");
			ProgressManager.AddUnlockedLevel ("Kitchen1");
			ProgressManager.AddUnlockedLevel ("Picnic1");
			ProgressManager.AddUnlockedLevel ("Forest1");
			ProgressManager.AddUnlockedLevel ("Bedroom1");
			ProgressManager.AddUnlockedLevel ("School1");
			ProgressManager.AddUnlockedLevel ("Playground1");
			ProgressManager.AddUnlockedLevel ("Clothing1");
			ProgressManager.AddUnlockedLevel ("Garden1");
			ProgressManager.AddUnlockedLevel ("Camping1");

			ProgressManager.AddUnlockedLevel ("Animals2");
			ProgressManager.AddUnlockedLevel ("Transportation2");
			ProgressManager.AddUnlockedLevel ("Bathroom2");
			ProgressManager.AddUnlockedLevel ("Kitchen2");
			ProgressManager.AddUnlockedLevel ("Picnic2");
			ProgressManager.AddUnlockedLevel ("Forest2");
			ProgressManager.AddUnlockedLevel ("Bedroom2");
			ProgressManager.AddUnlockedLevel ("School2");
			ProgressManager.AddUnlockedLevel ("Playground2");
			ProgressManager.AddUnlockedLevel ("Clothing2");
			ProgressManager.AddUnlockedLevel ("Garden2");
			ProgressManager.AddUnlockedLevel ("Camping2");

			ProgressManager.AddUnlockedLevel ("Animals3");
			ProgressManager.AddUnlockedLevel ("Transportation3");
			ProgressManager.AddUnlockedLevel ("Bathroom3");
			ProgressManager.AddUnlockedLevel ("Kitchen3");
			ProgressManager.AddUnlockedLevel ("Picnic3");
			ProgressManager.AddUnlockedLevel ("Forest3");
			ProgressManager.AddUnlockedLevel ("Bedroom3");
			ProgressManager.AddUnlockedLevel ("School3");
			ProgressManager.AddUnlockedLevel ("Playground3");
			ProgressManager.AddUnlockedLevel ("Clothing3");
			ProgressManager.AddUnlockedLevel ("Garden3");
			ProgressManager.AddUnlockedLevel ("Camping3");


			GameObject[] gos = GameObject.FindGameObjectsWithTag ("LevelIcon");
			foreach (GameObject go in gos) {

				if (!ProgressManager.IsLevelUnlocked(go.name)){
					Color color = go.renderer.material.color;
					color.a = 0f;
					go.renderer.material.color = color;
				}

				if (ProgressManager.IsLevelUnlocked(go.name))
				{
					go.AddComponent<GestureManager>().AddAndSubscribeToGestures(go);
					
					go.AddComponent<PulseBehavior> ().StartPulsing (go);

					if (!ProgressManager.IsLevelCompleted(go.name))
						go.GetComponent<SpriteRenderer>().color = Color.grey;

					if (ProgressManager.IsLevelCompleted(go.name)){
						go.GetComponent<SpriteRenderer>().color = Color.white;
					}
				}


			}
		
		}





		

	}
}
