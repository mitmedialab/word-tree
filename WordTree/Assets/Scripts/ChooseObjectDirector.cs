using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class ChooseObjectDirector : MonoBehaviour {


		void Start () {

			LoadLevel (ProgressManager.currentLevel);

			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			kid.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Graphics/" + ProgressManager.chosenKid);
			GrowKid ();

			kid.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/KidSpeaking/" + ProgressManager.currentLevel) as AudioClip;
			if (kid.audio.clip != null) {
				kid.audio.priority = 255;
				kid.audio.Play ();
			}

			GameObject dir = GameObject.Find ("ChooseObjectDirector");
			dir.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/BackgroundMusic/" + ProgressManager.currentLevel) as AudioClip;
			if (dir.audio.clip != null) {
				dir.audio.volume = .7f;
				dir.audio.Play ();
			}

			GameObject button = GameObject.FindGameObjectWithTag ("Button");
			button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos) {


				Debug.Log ("Started pulsing for " + go.name);
				go.GetComponent<PulseBehavior> ().StartPulsing (go);

				if (!ProgressManager.IsWordCompleted(go.name)){
					SetColorAndTransparency (go,Color.grey,.9f);
				}

				if (ProgressManager.IsWordCompleted(go.name)){
					Debug.Log ("Word Completed: " + go.name);
					SetColorAndTransparency(go,Color.white,1f);
				}
			}

			if (CheckCompletedLevel ()) {
				ProgressManager.AddCompletedLevel (ProgressManager.currentLevel);
				ProgressManager.UnlockNextLevel (ProgressManager.currentLevel);
			}


		}

		void Update(){
			
			GameObject dir = GameObject.Find ("ChooseObjectDirector");
			if (!dir.audio.isPlaying)
				dir.audio.Play ();
			
		}

		void GrowKid()
		{
			float scale = .5f;
			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			LeanTween.scale (kid, new Vector3 (scale, scale, 1f), 1f);
		}

		void SetColorAndTransparency(GameObject go, Color color, float transparency)
		{
			Color temp = go.renderer.material.color;
			temp.a = transparency;
			go.renderer.material.color = temp;

			go.GetComponent<SpriteRenderer>().color = color;

		}

		bool CheckCompletedLevel()
		{
			int numCompleted = 0;

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos) {
				if (ProgressManager.currentMode == 1){
					if (ProgressManager.completedWordsLearn.Contains (go.name))
						numCompleted = numCompleted + 1;
				}
				if (ProgressManager.currentMode == 2){
					if (ProgressManager.completedWordsSpell.Contains (go.name))
						numCompleted = numCompleted + 1;
				}
				if (ProgressManager.currentMode == 3){
					if (ProgressManager.completedWordsSound.Contains (go.name))
						numCompleted = numCompleted + 1;
				}
			}

			if (numCompleted == gos.Length) {
				Debug.Log ("Level Completed: " + ProgressManager.currentLevel);
				return true;
			}
			return false;
					
		}


		void CreateBackGround(string name, Vector3 posn, float scale)
		{
			GameObject background = GameObject.Find ("Background");
			SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
			Sprite sprite = Resources.Load<Sprite>("Graphics/Backgrounds/"+name);
			if (sprite == null)
				Debug.Log("ERROR: could not load background");
			spriteRenderer.sprite = sprite;

			background.transform.position = posn;
			background.transform.localScale = new Vector3(scale,scale,1);

		}

		void LoadLevel(string level)
		{
			LevelProperties prop = LevelProperties.GetLevelProperties (level);
			string[] words = prop.Words ();
			Vector3 backgroundPosn = prop.BackgroundPosn ();
			float backgroundScale = prop.BackgroundScale ();

			LevelCreation.CreateWordObjects (level, words);
			CreateBackGround (level, backgroundPosn, backgroundScale);

		}



	}
}
