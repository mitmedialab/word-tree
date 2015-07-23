using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;
using TouchScript.Behaviors;
using TouchScript.Hit;


namespace WordTree
{
	public class CollisionManager : MonoBehaviour {

		
		void OnTriggerEnter2D (Collider2D other)
		{

			if (Application.loadedLevelName == "4. Spell Word") {

				GameObject SpellWordDirector = GameObject.Find ("SpellWordDirector");
				SpellWordDirector swd = SpellWordDirector.GetComponent<SpellWordDirector> ();
				
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

					swd.PulseOnce(gameObject,"letter",1.05f);

					if (CheckCompletedWord ()) {

						swd.SpellOutWord ();

						AddCompletedWord (GameDirector.currentWord);

					}

				}
			}

			if (Application.loadedLevelName == "5. Spelling Game") {

				GameObject spellingGameDirector = GameObject.Find ("SpellingGameDirector");
				SpellingGameDirector sgd = spellingGameDirector.GetComponent<SpellingGameDirector>();

				Debug.Log ("Collision on " + other.name);

				other.gameObject.GetComponent<GestureManager>().DisableGestures(other.gameObject);
				other.gameObject.GetComponent<PulseBehavior>().StopPulsing (other.gameObject);
				other.gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-1);
				other.gameObject.transform.localScale = new Vector3 (WordCreation.xScale, WordCreation.yScale, 1);

				Debug.Log ("Disabled collisions for Blank " + gameObject.name);
				Destroy(gameObject.GetComponent<CollisionManager>());

				if (CheckCompletedBlanks()){

					ResetGravityEffect();

					if (CheckCorrectSpelling()){

						MarkCorrectLetters(0f);
						sgd.PulseWordOnce(1f);
						ExplodeStarsAnimation(2f);

					}


					if (!CheckCorrectSpelling()){

						TryAgainAnimation();
						MarkCorrectLetters(0f);
						ResetIncorrectLetters(0f);

					}

					
				}

			}


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

			foreach (GameObject go in incorrectLetters)
				Debug.Log ("Incorrect Letter" + go.name);
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
				go.transform.localScale = new Vector3 (WordCreation.xScale, WordCreation.yScale, 1);
			}

		}

		void ResetIncorrectLetters(float delayTime)
		{
			GameObject[] gos = IncorrectLetters();
			
			foreach (GameObject go in gos){

				go.transform.localScale = new Vector3 (WordCreation.xScale, WordCreation.yScale, 1);

				Debug.Log ("Moving " + go.name);
				Vector3 posn = new Vector3(go.transform.position.x,0,-2);
				LeanTween.move (go, posn, 1.0f).setEase (LeanTweenType.easeOutQuad).setDelay (delayTime);

				Debug.Log ("Pulsing " + go.name);
				go.GetComponent<PulseBehavior>().StartPulsing(go);

				go.GetComponent<GestureManager>().EnableGestures(go);

			}
		
		}

		void TryAgainAnimation()
		{	
			GameObject tryAgain = GameObject.Find ("TryAgain");
			GameObject owl = GameObject.Find ("Owl");

			Debug.Log ("Starting Try Again animation");

			//Animation: Owl falls from top of screen
			tryAgain.transform.position = new Vector3(0f,2f,-3);
			owl.transform.position = new Vector3 (3f,3.3f,-3.01f);

			tryAgain.GetComponent<Rigidbody2D> ().isKinematic = false;
			owl.GetComponent<Rigidbody2D> ().isKinematic = false;

			//Alternative animation: Owl fades in and fades out

			/*
			tryAgain.transform.position = new Vector3(0f,0f,-3);
			owl.transform.position = new Vector3 (3f,1.3f,-3.01f);

			LeanTween.alpha (tryAgain, 1f, .3f);
			LeanTween.alpha (owl, 1f, .3f);

			LeanTween.alpha (tryAgain, 0f, .3f).setDelay (2.5f);
			LeanTween.alpha (owl, 0f, .3f).setDelay (2.5f);
			*/
		}

		void ResetGravityEffect()
		{
			GameObject tryAgain = GameObject.Find ("TryAgain");
			GameObject owl = GameObject.Find ("Owl");
			
			tryAgain.GetComponent<Rigidbody2D> ().isKinematic = true;
			owl.GetComponent<Rigidbody2D> ().isKinematic = true;
		}


		void ExplodeStarsAnimation(float delayTime)
		{
			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetBlank");
			foreach (GameObject go in mov)
				LeanTween.alpha (go, 0f, .01f).setDelay(delayTime);
			foreach (GameObject go in tar)
				LeanTween.alpha (go, 0f, .01f).setDelay (delayTime);
			
			GameObject stars = GameObject.Find ("Stars");
			LeanTween.moveZ (stars, -3, .01f).setDelay (delayTime);
			LeanTween.scale (stars, new Vector3 (2.5f, 2.5f, 1), 1f).setDelay (delayTime);
			LeanTween.alpha (stars, 0f, .3f).setDelay (delayTime+.7f);
			
			
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
				Debug.Log ("Word Completed: " + GameDirector.currentWord);
				return true;
			}

			return false;

		}

		public static void AddCompletedWord(string word)
		{
			GameDirector.completedWords.Add (word);
		}




	}
	
}