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

				if (CheckCompletedBlanks()){

					if (CheckCorrectSpelling()){

						GameObject[] mov = GameObject.FindGameObjectsWithTag("MovableLetter");

						GameObject.Find ("SoundButton").GetComponent<GestureManager>().DisableGestures(GameObject.Find ("SoundButton"));
						GameObject.Find ("HintButton").GetComponent<GestureManager>().DisableGestures(GameObject.Find ("HintButton"));

						MarkCorrectLetters(0f);

						SpellOutWord();

						CompleteWordAnimation((mov.Length+1) * AudioManager.clipLength);

						GameObject spellingGameDirector = GameObject.Find ("SpellingGameDirector");
						SpellingGameDirector sgd = spellingGameDirector.GetComponent<SpellingGameDirector>();
						sgd.DestroyAll ((mov.Length+2) * AudioManager.clipLength);

						if (!CheckCompletedGame())
							sgd.LoadNextWord((mov.Length+3) * AudioManager.clipLength);
						if (CheckCompletedGame()){
							SpellingGameDirector.wordIndex = 0;
							ProgressManager.AddCompletedLevel (ProgressManager.currentLevel);
							ProgressManager.UnlockNextLevel (ProgressManager.currentLevel);
						}


					}


					if (!CheckCorrectSpelling()){

						TryAgainAnimation();
						MarkCorrectLetters(0f);
						ResetIncorrectLetters(0f);

					}

					
				}

			}


		}

		void SpellOutWord()
		{
			GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetBlank");
			GameObject[] mov = new GameObject[tar.Length];
			for (int i=0; i<tar.Length; i++)
			{
				Vector2 posn = tar[i].transform.position;
				Collider2D[] letters = Physics2D.OverlapCircleAll(posn,1.0f,1,-1,-1);
				mov[i] = letters[0].gameObject;
			}
			GameObject audioManager = GameObject.Find ("AudioManager");
			audioManager.GetComponent<AudioManager>().SpellOutWord(mov);
		}


		static GameObject[] UnoccupiedBlanks()
		{
			GameObject[] blanks = GameObject.FindGameObjectsWithTag ("TargetBlank");
			int numUnoccupied = 0;

			for (int i=0; i<blanks.Length; i++)
			{
				Vector2 posn = blanks[i].transform.position;
				Collider2D[] letters = Physics2D.OverlapCircleAll(posn,1.0f,1,-1,-1);
				if (letters.Length == 0)
					numUnoccupied = numUnoccupied + 1;
				
			}
			Debug.Log ("Unoccupied Blanks: " + numUnoccupied);

			GameObject[] unoccupiedBlanks = new GameObject[numUnoccupied];
			int j = 0;
			for (int i=0; i<blanks.Length; i++)
			{
				Vector2 posn = blanks[i].transform.position;
				Collider2D[] letters = Physics2D.OverlapCircleAll(posn,1.0f,1,-1,-1);
				if (letters.Length == 0)
					unoccupiedBlanks[j++] = blanks[i];
				
			}

			return unoccupiedBlanks;
		}

		public static void EnableCollisions(GameObject go)
		{
			GameObject[] unoccupiedBlanks = UnoccupiedBlanks ();
			foreach (GameObject blank in unoccupiedBlanks)
				{
					if (blank.GetComponent<CollisionManager> () == null) {
						blank.AddComponent<CollisionManager> ();
						Debug.Log ("Enabled collisions for blank " + go.name);
					}
				}
		}

		GameObject[] UserSpelling()
		{
			GameObject[] blanks = GameObject.FindGameObjectsWithTag ("TargetBlank");
			GameObject[] userSpelling = new GameObject[blanks.Length];
			
			for (int i=0; i<blanks.Length; i++)
			{
				Vector2 posn = blanks[i].transform.position;
				Collider2D[] letter = Physics2D.OverlapCircleAll(posn,1.0f,1,-1,-1);
				if (letter.Length != 0)
					userSpelling[i] = letter[0].gameObject;
				
			}

			return userSpelling;
		}


		GameObject[] IncorrectLetters()
		{
			GameObject[] userSpelling = UserSpelling ();
			GameObject[] blanks = GameObject.FindGameObjectsWithTag ("TargetBlank");
			int numIncorrect = 0;
			
			for (int i=0; i<blanks.Length; i++) {
				
				if (userSpelling [i].name != blanks [i].name) {
					numIncorrect = numIncorrect + 1;
				}
			}
			
			GameObject[] incorrectLetters = new GameObject[numIncorrect];
			int j = 0;
			for (int i=0; i<blanks.Length; i++) {
				
				if (userSpelling [i].name != blanks [i].name) {
					incorrectLetters[j++] = userSpelling[i];
				}
			}
	
			return incorrectLetters;
		}

		GameObject[] CorrectLetters()
		{
			GameObject[] userSpelling = UserSpelling ();
			GameObject[] blanks = GameObject.FindGameObjectsWithTag ("TargetBlank");
			int numCorrect = 0;
			
			for (int i=0; i<blanks.Length; i++) {
				
				if (userSpelling [i].name == blanks [i].name) {
					numCorrect = numCorrect + 1;
				}
			}
			
			GameObject[] correctLetters = new GameObject[numCorrect];
			int j = 0;
			for (int i=0; i<blanks.Length; i++) {
				
				if (userSpelling [i].name == blanks [i].name) {
					correctLetters[j++] = userSpelling[i];
				}
			}

			return correctLetters;
		}

		void MarkCorrectLetters(float delayTime)
		{
			GameObject[] correctLetters = CorrectLetters ();
			foreach (GameObject go in correctLetters) {
				LeanTween.color (go,Color.yellow,.1f).setDelay (delayTime);
				go.transform.localScale = new Vector3 (WordCreation.letterScale, WordCreation.letterScale, 1);
			}

		}

		public void ResetIncorrectLetters(float delayTime)
		{
			GameObject[] gos = IncorrectLetters();
			
			foreach (GameObject go in gos){

				go.transform.localScale = new Vector3 (WordCreation.letterScale, WordCreation.letterScale, 1);

				Debug.Log ("Resetting incorrect letter " + go.name);
				Vector3 posn = new Vector3(go.transform.position.x,0,-2);
				LeanTween.move (go, posn, 1.0f).setEase (LeanTweenType.easeOutQuad).setDelay (delayTime);

				go.GetComponent<PulseBehavior>().StartPulsing(go);

				go.GetComponent<GestureManager>().EnableGestures(go);

			}
		
		}

		void TryAgainAnimation()
		{	
			GameObject tryAgain = GameObject.Find ("TryAgain");

			LeanTween.alpha (tryAgain, 1f, .1f);
			LeanTween.alpha (tryAgain, 0f, .1f).setDelay (2.5f);


		}


		void CompleteWordAnimation(float delayTime)
		{
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetBlank");

			foreach (GameObject go in tar)
				LeanTween.alpha (go, 0f, .01f).setDelay (delayTime);
			foreach (GameObject go in mov) {
				LeanTween.moveX (go, 0, AudioManager.clipLength).setDelay (delayTime);
				LeanTween.scale (go, new Vector3 (0, 0, 1), AudioManager.clipLength).setDelay (delayTime);
			}

			
			GameObject stars = GameObject.Find ("Stars");
			LeanTween.moveZ (stars, -3, .01f).setDelay (delayTime);
			LeanTween.scale (stars, new Vector3 (2.5f, 2.5f, 1), AudioManager.clipLength).setDelay (delayTime);
			LeanTween.alpha (stars, 0f, .3f).setDelay (delayTime + AudioManager.clipLength - .3f);

			LeanTween.moveZ (stars, 3, .01f).setDelay (delayTime + 2f);
			LeanTween.scale (stars, new Vector3 (.2f, .2f, 1), .01f).setDelay (delayTime + 2f);
			LeanTween.alpha (stars, 1f, .01f).setDelay (delayTime + 2f);
			
			
		}

		public static void ShowHint()
		{
			GameObject[] unoccupiedBlanks = UnoccupiedBlanks ();
			int i = Random.Range (0, unoccupiedBlanks.Length);
			string letterName = unoccupiedBlanks [i].name;

			if (GameObject.Find ("Hint" + letterName + i) == null) {

				ObjectProperties letter = ObjectProperties.CreateInstance ("Hint" + letterName + i, "Hint", unoccupiedBlanks [i].transform.position, new Vector3 (WordCreation.letterScale, WordCreation.letterScale, 1), "Letters/" + letterName, null);
				ObjectProperties.InstantiateObject (letter);
			}

			GameObject hint = GameObject.Find("Hint"+letterName+i);
			LeanTween.color (hint, Color.magenta, .5f).setDelay (.2f);
			LeanTween.color (hint, Color.black, .5f).setDelay (1.7f);
			LeanTween.alpha (hint, 0f, .01f).setDelay (2.2f);

				                 
		}


		bool CheckCorrectSpelling()
		{
			GameObject[] userSpelling = UserSpelling ();
			GameObject[] blanks = GameObject.FindGameObjectsWithTag ("TargetBlank");

			if (userSpelling[0] != null)
			{
				for (int i=0; i<blanks.Length; i++) {

					if (userSpelling [i].name != blanks [i].name) {
						Debug.Log ("Incorrect Spelling");
						return false;
					}
				}
			}

			Debug.Log ("Correct spelling");
			return true;
		}

		bool CheckCompletedBlanks()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			foreach (GameObject go in gos){
				  if (go.GetComponent<PanGesture>().enabled == true)
					return false;
			}

			Debug.Log ("Blanks Completed");
			return true;

		}

		bool CheckCompletedWord ()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			Debug.Log ("Letters left: " + (gos.Length-1));

			if (gos.Length == 1) {
				Debug.Log ("Word Completed: " + ProgressManager.currentWord);
				return true;
			}

			return false;

		}

		bool CheckCompletedGame()
		{
			LevelProperties prop = LevelProperties.GetLevelProperties (ProgressManager.currentLevel);
			string[] words = prop.Words ();
			if (SpellingGameDirector.wordIndex == words.Length - 1) {
				Debug.Log ("Game Completed");
				return true;
			}
			return false;
		}




	}
	
}