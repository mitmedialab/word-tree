using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {


		void Start () {

			ProgressManager.InitiateLevelList ();
			ProgressManager.unlockedLevels.Add(ProgressManager.levelList[0]);
			ProgressManager.unlockedLevels.Add (ProgressManager.levelList[3]);


			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			kid.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Graphics/" + ProgressManager.chosenKid);
			GrowKid ();

			GameObject dir = GameObject.Find ("WordTreeDirector");
			dir.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/BackgroundMusic/WordTree") as AudioClip;
			if (dir.audio.clip != null)
				dir.audio.Play ();

			GameObject home = GameObject.Find ("HomeButton");
			home.AddComponent<GestureManager> ().AddAndSubscribeToGestures (home);

			GameObject Lock = GameObject.Find (ProgressManager.lockStatus);
			if (ProgressManager.lockStatus == "")
				Lock = GameObject.Find ("LockClosed");
			Lock.AddComponent<GestureManager> ().AddAndSubscribeToGestures (Lock);
			LeanTween.moveZ (Lock, -2f, .01f);


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

			if (ProgressManager.lockStatus == "LockOpen")
				ProgressManager.UnlockAllLevels ();
		
		}

		void Update(){
			
			GameObject dir = GameObject.Find ("WordTreeDirector");
			if (!dir.audio.isPlaying)
				dir.audio.Play ();
			
		}



		void GrowKid()
		{
			float scale = .5f;
			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			LeanTween.scale (kid, new Vector3 (scale, scale, 1f), 1f);
			LeanTween.rotateAround (kid, Vector3.forward, 360f, 1f);

			if (ProgressManager.currentLevel != "") {
				kid.transform.position = GameObject.Find (ProgressManager.currentLevel + ProgressManager.currentMode).transform.position;
				LeanTween.move (kid, new Vector3 (-7.5f, -3.5f, -2), 1f);
			}
		}





		

	}
}
