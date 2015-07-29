using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SoundGameDirector : MonoBehaviour {

		//public static int wordIndex = 0;

		void Start () {

			LoadSoundGameWord (ProgressManager.currentWord);
			//LoadSoundGame (ProgressManager.currentLevel);

			GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
			foreach (GameObject button in buttons)
				button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			GameObject word = GameObject.FindGameObjectWithTag ("WordObject");
			word.GetComponent<GestureManager> ().DisableGestures (word);

			GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetLetter");
			GameObject audioManager = GameObject.Find ("AudioManager");
			audioManager.GetComponent<AudioManager>().SpellOutWord(tar);
			
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableBlank");
			foreach (GameObject go in mov) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go, (tar.Length+1) * AudioManager.clipLength);
			}
		
		}
		/*
		public void LoadNextWord(float delayTime)
		{
			StartCoroutine (loadNextWord(delayTime));
		}
		
		IEnumerator loadNextWord(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);
			
			wordIndex = wordIndex + 1;
			
			Debug.Log ("Loading next word");
			LevelProperties prop = LevelProperties.GetLevelProperties (ProgressManager.currentLevel);
			string[] words = prop.Words ();
			LoadGameWord (words[wordIndex]);
			
			GameObject.Find ("SoundButton").GetComponent<GestureManager>().EnableGestures(GameObject.Find ("SoundButton"));
			GameObject.Find ("HintButton").GetComponent<GestureManager>().EnableGestures(GameObject.Find ("HintButton"));
			
			
		}
		
		public void DestroyAll(float delayTime)
		{
			StartCoroutine (destroyAll (delayTime));
		}
		
		IEnumerator destroyAll(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);
			
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableBlank");
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			GameObject[] hint = GameObject.FindGameObjectsWithTag ("Hint");
			GameObject[] jar = GameObject.FindGameObjectsWithTag ("Jar");
			
			foreach (GameObject go in mov)
				Destroy (go);
			foreach (GameObject go in tar)
				Destroy (go);
			foreach (GameObject go in hint)
				Destroy (go);
			foreach (GameObject go in jar)
				Destroy (go);
			Destroy (GameObject.FindGameObjectWithTag("WordObject"));
		}
		
		void LoadSoundGame(string level)
		{
			LevelProperties prop = LevelProperties.GetLevelProperties (level);
			string[] words = prop.Words ();
			LoadGameWord (words [wordIndex]);
			
		}
		
		
		void LoadGameWord(string word)
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
			
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableBlank");
			foreach (GameObject go in mov) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go);
			}
			
		}
		*/

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
			
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, y, 0), new Vector3 (scale, scale, 1), ProgressManager.currentLevel + "/" + word, "Words/"+word);
			ObjectProperties.InstantiateObject (Obj);
		}

		void CreateJars()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("TargetLetter");
			foreach (GameObject go in gos) {
				Vector3 letterPosn = go.transform.position;
				ObjectProperties jar = ObjectProperties.CreateInstance ("Jar", "Jar", letterPosn, new Vector3 (1f, .8f, 1), "Jar", null);
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
			
			GameObject confetti = GameObject.Find ("Confetti");
			LeanTween.moveZ (confetti, -3, .01f).setDelay (delayTime);
			LeanTween.scale (confetti, new Vector3 (6f, 6f, 1), AudioManager.clipLength).setDelay (delayTime);
			LeanTween.alpha (confetti, 0f, .3f).setDelay (delayTime + AudioManager.clipLength - .3f);
			
			LeanTween.moveZ (confetti, 3, .01f).setDelay (delayTime + 2f);
			LeanTween.scale (confetti, new Vector3 (.2f, .2f, 1), .01f).setDelay (delayTime + 2f);
			LeanTween.alpha (confetti, 1f, .01f).setDelay (delayTime + 2f);
			
			
		}


	}
}
