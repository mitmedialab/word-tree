using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SoundGameDirector : MonoBehaviour {

		public static int wordIndex = 0;

		void Start () {

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Button");
			foreach (GameObject go in gos)
				go.AddComponent<GestureManager> ().AddAndSubscribeToGestures (go);
			
			LoadSoundGame (ProgressManager.currentLevel);
		
		}

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
			
			foreach (GameObject go in mov)
				Destroy (go);
			foreach (GameObject go in tar)
				Destroy (go);
			foreach (GameObject go in hint)
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

			BlankCreation.CreateScrambledBlanks(word, phonemes, "Balloon", "MovableBlank", "SoundGame");
			WordCreation.CreateWord (word, phonemes, "TargetLetter", "SoundGame");
			CreateObject (word, objScale);

			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			foreach (GameObject go in tar)
				go.GetComponent<SpriteRenderer> ().color = Color.black;
			
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableBlank");
			foreach (GameObject go in mov) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go);
			}
			
		}
		
		void CreateObject(string word, float scale)
		{
			float y = 3;
			
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, y, 0), new Vector3 (scale, scale, 1), ProgressManager.currentLevel + "/" + word, "Words/"+word);
			ObjectProperties.InstantiateObject (Obj);
		}


	}
}
