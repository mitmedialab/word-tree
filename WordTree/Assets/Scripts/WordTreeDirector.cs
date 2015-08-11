using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			ProgressManager.InitiateLevelList ();
			ProgressManager.unlockedLevels.Add(ProgressManager.levelList[0]);
			ProgressManager.unlockedLevels.Add (ProgressManager.levelList[3]);

			ProgressManager.unlockedLevels.Add ("Animals1");
			ProgressManager.unlockedLevels.Add ("Transportation1");
			ProgressManager.unlockedLevels.Add ("Bathroom1");
			ProgressManager.unlockedLevels.Add ("Kitchen1");
			ProgressManager.unlockedLevels.Add ("Picnic1");
			ProgressManager.unlockedLevels.Add ("Pond1");
			ProgressManager.unlockedLevels.Add ("Bedroom1");
			ProgressManager.unlockedLevels.Add ("School1");
			ProgressManager.unlockedLevels.Add ("Playground1");
			ProgressManager.unlockedLevels.Add ("Clothing1");
			ProgressManager.unlockedLevels.Add ("Garden1");
			ProgressManager.unlockedLevels.Add ("Camping1");

			ProgressManager.unlockedLevels.Add ("Animals2");
			ProgressManager.unlockedLevels.Add ("Transportation2");
			ProgressManager.unlockedLevels.Add ("Bathroom2");
			ProgressManager.unlockedLevels.Add ("Kitchen2");
			ProgressManager.unlockedLevels.Add ("Picnic2");
			ProgressManager.unlockedLevels.Add ("Pond2");
			ProgressManager.unlockedLevels.Add ("Bedroom2");
			ProgressManager.unlockedLevels.Add ("School2");
			ProgressManager.unlockedLevels.Add ("Playground2");
			ProgressManager.unlockedLevels.Add ("Clothing2");
			ProgressManager.unlockedLevels.Add ("Garden2");
			ProgressManager.unlockedLevels.Add ("Camping2");

			ProgressManager.unlockedLevels.Add ("Animals3");
			ProgressManager.unlockedLevels.Add ("Transportation3");
			ProgressManager.unlockedLevels.Add ("Bathroom3");
			ProgressManager.unlockedLevels.Add ("Kitchen3");
			ProgressManager.unlockedLevels.Add ("Picnic3");
			ProgressManager.unlockedLevels.Add ("Pond3");
			ProgressManager.unlockedLevels.Add ("Bedroom3");
			ProgressManager.unlockedLevels.Add ("School3");
			ProgressManager.unlockedLevels.Add ("Playground3");
			ProgressManager.unlockedLevels.Add ("Clothing3");
			ProgressManager.unlockedLevels.Add ("Garden3");
			ProgressManager.unlockedLevels.Add ("Camping3");


			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			kid.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Graphics/" + ProgressManager.chosenKid);
			GrowKid ();

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

		void GrowKid()
		{
			float scale = .5f;
			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			LeanTween.scale (kid, new Vector3 (scale, scale, 1f), 1f);
		}





		

	}
}
