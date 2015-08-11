using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SoundGameDirector : MonoBehaviour {

		void Start () {

			LoadSoundGameWord (ProgressManager.currentWord);

			GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
			foreach (GameObject button in buttons)
				button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetLetter");
			GameObject audioManager = GameObject.Find ("AudioManager");
			audioManager.GetComponent<AudioManager>().SpellOutWord(tar);
			
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableBlank");
			foreach (GameObject go in mov) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go, (tar.Length+1) * AudioManager.clipLength);
			}
		
		}

		void LoadSoundGameWord(string word)
		{
			WordProperties prop = WordProperties.GetWordProperties(word);
			string[] phonemes = prop.Phonemes ();
			float objScale = prop.ObjScale ();
			
			BlankCreation.CreateScrambledBlanks(word, phonemes, "Circle", "MovableBlank", "SoundGame");
			WordCreation.CreateWord (word, phonemes, "TargetLetter", "SoundGame");
			CreateWordImage (word, objScale);
			CreateJars ();
			
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			foreach (GameObject go in tar)
				go.GetComponent<SpriteRenderer> ().color = Color.black;
			
		}

		void CreateWordImage(string word, float scale)
		{
			float y = 3;
			
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, y, 0), new Vector3 (scale, scale, 1), ProgressManager.currentLevel + "/" + word, word);
			ObjectProperties.InstantiateObject (Obj);
		}

		void CreateJars()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("TargetLetter");
			foreach (GameObject go in gos) {
				Vector3 letterPosn = new Vector3(go.transform.position.x, go.transform.position.y, 1.5f);
				ObjectProperties jar = ObjectProperties.CreateInstance ("Jar", "Jar", letterPosn, new Vector3 (.45f, .45f, 1), "Jar", null);
				ObjectProperties.InstantiateObject (jar);
			}
		}



		public static void TryAgainAnimation()
		{	
			GameObject tryAgain = GameObject.Find ("TryAgain");
			
			LeanTween.alpha (tryAgain, 1f, .1f);
			LeanTween.alpha (tryAgain, 0f, .1f).setDelay (1f);
			
			LeanTween.scale (tryAgain, new Vector3 (2f,2f, 1), .7f);
			LeanTween.scale (tryAgain, new Vector3 (.5f,.5f,1), .5f).setDelay (.5f);
			
		}

		public static void CelebratoryAnimation(float delayTime)
		{	
			
			float time = 1f;
			
			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");
			
			Debug.Log ("Spinning " + go.name + " around");
			LeanTween.rotateAround (go, Vector3.forward, 360f, time).setDelay(delayTime);
			LeanTween.scale (go,new Vector3(go.transform.localScale.x*1.3f,go.transform.localScale.y*1.3f,1),time).setDelay (delayTime);
			LeanTween.moveY (go, 2.5f, time).setDelay (delayTime);
			
			Debug.Log ("Playing clip for congrats");
			AudioSource audio = go.AddComponent<AudioSource> ();
			audio.clip = Resources.Load ("Audio/CongratsSound") as AudioClip;
			audio.PlayDelayed (delayTime);
			
			
		}


	}
}
