using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;
using TouchScript.Behaviors;
using TouchScript.Hit;
using System.Collections.Generic;
using System.Linq;


namespace WordTree
{
	public class CollisionManager : MonoBehaviour {

		
		void OnTriggerEnter2D (Collider2D other)
		{

			if (Application.loadedLevelName == "4. Learn Spelling") {
				
				if (other.name == gameObject.name) {

					Debug.Log ("Collision on " + other.name);

					gameObject.GetComponent<SpriteRenderer> ().color = other.GetComponent<SpriteRenderer> ().color;
					Color color = gameObject.renderer.material.color;
					color.a = 1.0f;
					gameObject.renderer.material.color = color;

					Debug.Log ("Destroyed draggable letter " + other.gameObject.name);
					Destroy (other.gameObject);

					Debug.Log ("Disabled collisions for " + gameObject.name);
					Destroy (gameObject.GetComponent<CollisionManager>());

					if (CheckCompletedWord ()) {

						GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetLetter");
						GameObject audioManager = GameObject.Find ("AudioManager");
						audioManager.GetComponent<AudioManager>().SpellOutWord(tar);

						LearnSpellingDirector.CongratsAnimation((tar.Length+1) * AudioManager.clipLength);

						ProgressManager.AddCompletedWord (ProgressManager.currentWord);

					}

				}
			}

			if (Application.loadedLevelName == "5. Spelling Game") {

				Debug.Log ("Collision on " + other.name);

				other.gameObject.GetComponent<GestureManager>().DisableGestures(other.gameObject);
				other.gameObject.GetComponent<PulseBehavior>().StopPulsing (other.gameObject);
				other.gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-1);

				Debug.Log ("Disabled collisions for Blank " + gameObject.name);
				Destroy(gameObject.GetComponent<CollisionManager>());

				if (CheckCompletedTargets("MovableLetter")){

					if (CheckCorrectSpelling("TargetBlank")){

						GameObject[] mov = GameObject.FindGameObjectsWithTag("MovableLetter");

						GameObject.Find ("SoundButton").GetComponent<GestureManager>().DisableGestures(GameObject.Find ("SoundButton"));
						GameObject.Find ("HintButton").GetComponent<GestureManager>().DisableGestures(GameObject.Find ("HintButton"));

						MarkCorrectLetters(0f);

						SpellingGameDirector.SpellOutWord();

						SpellingGameDirector.CelebratoryAnimation((mov.Length+1) * AudioManager.clipLength);

						ProgressManager.AddCompletedWord (ProgressManager.currentWord);

						/*
						GameObject spellingGameDirector = GameObject.Find ("SpellingGameDirector");
						SpellingGameDirector sgd = spellingGameDirector.GetComponent<SpellingGameDirector>();
						sgd.DestroyAll ((mov.Length+2) * AudioManager.clipLength);

						if (!CheckCompletedGame("Spelling Game"))
							sgd.LoadNextWord((mov.Length+3) * AudioManager.clipLength);
						if (CheckCompletedGame("Spelling Game")){
							SpellingGameDirector.wordIndex = 0;
							ProgressManager.AddCompletedLevel (ProgressManager.currentLevel);
							ProgressManager.UnlockNextLevel (ProgressManager.currentLevel);
						}
						*/


					}


					if (!CheckCorrectSpelling("TargetBlank")){

						SpellingGameDirector.TryAgainAnimation();
						MarkCorrectLetters(1f);
						ResetIncorrectLetters(1f);
						GameObject.FindGameObjectWithTag("WordObject").audio.PlayDelayed (1);

					}

					
				}

			}

			if (Application.loadedLevelName == "6. Sound Game") {
				
				Debug.Log ("Collision on " + other.name);
				
				other.gameObject.GetComponent<GestureManager> ().DisableGestures (other.gameObject);
				other.gameObject.GetComponent<PulseBehavior> ().StopPulsing (other.gameObject);
				other.gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 2f, 1);
				
				Debug.Log ("Disabled collisions for Letter " + gameObject.name);
				Destroy (gameObject.GetComponent<CollisionManager> ());
				
				if (CheckCompletedTargets ("MovableBlank")) {
					
					if (CheckCorrectSpelling ("TargetLetter")) {
						
						GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableBlank");
						
						GameObject.Find ("SoundButton").GetComponent<GestureManager> ().DisableGestures (GameObject.Find ("SoundButton"));
						GameObject.Find ("HintButton").GetComponent<GestureManager> ().DisableGestures (GameObject.Find ("HintButton"));
						
						MarkCorrectSounds (0f);
						
						GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetLetter");
						GameObject audioManager = GameObject.Find ("AudioManager");
						audioManager.GetComponent<AudioManager>().SpellOutWord(tar);
						
						SoundGameDirector.CelebratoryAnimation ((mov.Length + 1) * AudioManager.clipLength);

						ProgressManager.AddCompletedWord (ProgressManager.currentWord);

						/*
						GameObject soundGameDirector = GameObject.Find ("SoundGameDirector");
						SoundGameDirector sgd = soundGameDirector.GetComponent<SoundGameDirector> ();
						sgd.DestroyAll ((mov.Length + 2) * AudioManager.clipLength);
						
						if (!CheckCompletedGame ("Sound Game"))
							sgd.LoadNextWord ((mov.Length + 3) * AudioManager.clipLength);
						if (CheckCompletedGame ("Sound Game")) {
							SoundGameDirector.wordIndex = 0;
							ProgressManager.AddCompletedLevel (ProgressManager.currentLevel);
							ProgressManager.UnlockNextLevel (ProgressManager.currentLevel);
						}
						*/
						
						
					}
					
					
					if (!CheckCorrectSpelling ("TargetLetter")) {

						SoundGameDirector.TryAgainAnimation ();
						MarkCorrectSounds (1f);
						ResetIncorrectSounds (1f);
						GameObject.FindGameObjectWithTag("WordObject").audio.PlayDelayed (1);
						
					}
					
					
				}
			}
		}



		static List <GameObject> UnoccupiedTargets(string tag)
		{
			GameObject[] tar = GameObject.FindGameObjectsWithTag (tag);
			List<GameObject> unoccupiedTargets = new List<GameObject>();
			int z = 0;
			float radius = 0;

			if (tag == "TargetBlank") {
				z = -1;
				radius = .5f;
			}
			
			if (tag == "TargetLetter") {
				z = 1;
				radius = 1.5f;
			}

			for (int i=0; i<tar.Length; i++)
			{
				Vector2 posn = tar[i].transform.position;
				Collider2D[] mov = Physics2D.OverlapCircleAll(posn,radius,1,z,z);
				if (mov.Length == 0)
					unoccupiedTargets.Add (tar[i]);
				
			}

			return unoccupiedTargets;
		}


		static GameObject[] UserAnswer(string tag)
		{
			GameObject[] tar = GameObject.FindGameObjectsWithTag (tag);
			GameObject[] userAnswer = new GameObject[tar.Length];
			int z = 0;
			float radius = 0;

			if (tag == "TargetBlank") {
				z = -1;
				radius = .5f;
			}

			if (tag == "TargetLetter") {
				z = 1;
				radius = 1.5f;
			}

			for (int i=0; i<tar.Length; i++)
			{
				Vector2 posn = tar[i].transform.position;
					Collider2D[] mov = Physics2D.OverlapCircleAll(posn,radius,1,z,z);
				if (mov.Length > 1)
					Debug.LogError("Decrease OverlapCircleAll radius");
				if (mov.Length != 0)
					userAnswer[i] = mov[0].gameObject;
			}

			return userAnswer;
		}

		static List<GameObject> CorrectObjects(string tag)
		{
			GameObject[] userAnswer = UserAnswer (tag);
			GameObject[] tar = GameObject.FindGameObjectsWithTag (tag);
			List<GameObject> correctObjects = new List<GameObject>();
			
			for (int i=0; i<tar.Length; i++) {
				
				if (userAnswer [i].name == tar [i].name) {
					correctObjects.Add(userAnswer[i]);
				}
			}
			return correctObjects;
		}

		static List<GameObject> IncorrectObjects(string tag)
		{
			GameObject[] userAnswer = UserAnswer (tag);
			GameObject[] tar = GameObject.FindGameObjectsWithTag (tag);
			List<GameObject> incorrectObjects = new List<GameObject>();

			for (int i=0; i<tar.Length; i++) {
				
				if (userAnswer [i].name != tar [i].name) {
					incorrectObjects.Add(userAnswer[i]);
				}
			}
			return incorrectObjects;

		}

		public static void EnableCollisions(GameObject go, string tag)
		{
			List<GameObject> unoccupiedTargets = UnoccupiedTargets (tag);
			foreach (GameObject target in unoccupiedTargets)
			{
				if (target.GetComponent<CollisionManager> () == null) {
					target.AddComponent<CollisionManager> ();
					Debug.Log ("Enabled collisions for target " + go.name);
				}
			}
		}

		void MarkCorrectLetters(float delayTime)
		{
			List<GameObject> correctLetters = CorrectObjects ("TargetBlank");
			foreach (GameObject go in correctLetters) {
				LeanTween.color (go,Color.yellow,.1f).setDelay (delayTime);
				go.transform.localScale = new Vector3 (WordCreation.letterScale, WordCreation.letterScale, 1);
			}

		}

		void MarkCorrectSounds(float delayTime)
		{
			List<GameObject> correctSounds = CorrectObjects ("TargetLetter");
			foreach (GameObject go in correctSounds) {
				go.transform.localScale = new Vector3 (.4f, .4f, 1);
			}
			
		}


		public void ResetIncorrectLetters(float delayTime)
		{
			List<GameObject> incorrectLetters = IncorrectObjects("TargetBlank");
		
			foreach (GameObject go in incorrectLetters){

				go.transform.localScale = new Vector3 (WordCreation.letterScale, WordCreation.letterScale, 1);

				Debug.Log ("Resetting incorrect letter " + go.name);
				Vector3 posn = new Vector3(go.transform.position.x,0,-2);
				LeanTween.move (go, posn, 1.0f).setDelay (delayTime);

				go.GetComponent<PulseBehavior>().StartPulsing(go,delayTime);

				go.GetComponent<GestureManager>().EnableGestures(go);

			}
		
		}

		public void ResetIncorrectSounds (float delayTime)
		{
			List<GameObject> incorrectSounds = IncorrectObjects("TargetLetter");
			
			foreach (GameObject go in incorrectSounds){
				
				go.transform.localScale = new Vector3 (.4f,.4f, 1);
				
				Debug.Log ("Resetting incorrect sound " + go.name);
				Vector3 posn = new Vector3(go.transform.position.x,0,-2);
				LeanTween.move (go, posn, 1.0f).setDelay (delayTime);
				
				go.GetComponent<PulseBehavior>().StartPulsing(go,delayTime);
				
				go.GetComponent<GestureManager>().EnableGestures(go);
				
			}
			
		}



		public static void ShowLetterHint()
		{
			List<GameObject> unoccupiedTargets = UnoccupiedTargets("TargetBlank");
			int i = 0;
			string letterName = unoccupiedTargets [i].name;

			if (GameObject.Find ("Hint" + letterName + i) == null) {

				ObjectProperties letter = ObjectProperties.CreateInstance ("Hint" + letterName + i, "Hint", unoccupiedTargets [i].transform.position, new Vector3 (WordCreation.letterScale, WordCreation.letterScale, 1), "Letters/" + letterName, null);
				ObjectProperties.InstantiateObject (letter);
			}

			GameObject hint = GameObject.Find("Hint"+letterName+i);
			LeanTween.color (hint, Color.magenta, .5f).setDelay (.2f);
			LeanTween.color (hint, Color.black, .5f).setDelay (1.7f);
			LeanTween.alpha (hint, 0f, .01f).setDelay (2.2f);

				                 
		}

		public static void ShowSoundHint()
		{

		}

		bool CheckCompletedTargets(string tag)
		{
			GameObject[] mov = GameObject.FindGameObjectsWithTag (tag);
			
			foreach (GameObject go in mov){
				if (go.GetComponent<PanGesture>().enabled == true)
					return false;
			}
			
			Debug.Log ("Word Completed");
			return true;
			
		}


		bool CheckCorrectSpelling(string tag)
		{
			GameObject[] userAnswer = UserAnswer (tag);
			GameObject[] tar = GameObject.FindGameObjectsWithTag (tag);

			if (userAnswer[0] != null)
			{
				for (int i=0; i<tar.Length; i++) {

					if (userAnswer [i].name != tar [i].name) {
						Debug.Log ("Incorrect Spelling");
						return false;
					}
				}
			}


			Debug.Log ("Correct spelling");
			return true;
		}


		/*
		bool CheckCompletedGame(string mode)
		{
			LevelProperties prop = LevelProperties.GetLevelProperties (ProgressManager.currentLevel);
			string[] words = prop.Words ();
			if (mode == "Spelling Game") {
				if (SpellingGameDirector.wordIndex == words.Length - 1) {
					Debug.Log ("Game Completed");
					return true;
				}
			}
			if (mode == "Sound Game") {
				if (SoundGameDirector.wordIndex == words.Length - 1) {
					Debug.Log ("Game Completed");
					return true;
				}
			}
			return false;
		}
		*/

		bool CheckCompletedWord ()
		{
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			Debug.Log ("Letters left: " + (mov.Length-1));
			
			if (mov.Length == 1) {
				Debug.Log ("Word Completed: " + ProgressManager.currentWord);
				return true;
			}
			
			return false;
			
		}




	}
	
}