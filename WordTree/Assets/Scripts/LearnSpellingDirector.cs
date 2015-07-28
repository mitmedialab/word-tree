using UnityEngine;
using System.Collections;


namespace WordTree
{
	public class LearnSpellingDirector : MonoBehaviour {

		void Start () {


			LoadSpellingLesson (ProgressManager.currentWord);

			GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
			foreach (GameObject button in buttons)
				button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			GameObject word = GameObject.FindGameObjectWithTag ("WordObject");
			word.GetComponent<GestureManager> ().DisableGestures (word);

			word.audio.Play();

			StartCoroutine (StartPulsing (.5f));
			StartCoroutine(ExplodeWord(1));
			StartCoroutine (EnableCollisions(2));

		}
		
		void LoadSpellingLesson(string word)
		{
			WordProperties prop = WordProperties.GetWordProperties (word);
			string[] phonemes = prop.Phonemes ();
			float objScale = prop.ObjScale ();
			
			WordCreation.CreateMovableAndTargetWords (word, phonemes);
			CreateObject (word, objScale);
		}

		void CreateObject(string word, float scale)
		{
			float y = 2;
			
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, y, 0), new Vector3 (scale, scale, 1), ProgressManager.currentLevel + "/" + word, "Words/"+word);
			ObjectProperties.InstantiateObject (Obj);
		}

		IEnumerator ExplodeWord(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");

			Vector3[] posn = new Vector3[gos.Length];
			Vector3[] shuffledPosn = new Vector3[gos.Length];

			int y1 = 3;
			int y2 = 2;
			int z = -2;

			if (gos.Length == 3) {

				posn = new Vector3[3] {
					new Vector3 (-7, 0, z),
					new Vector3 (6, y2, z),
					new Vector3 (8, -y1, z)
				};
			}

			if (gos.Length == 4) {

				posn = new Vector3[4] {
					new Vector3 (-8, -y1, z),
					new Vector3 (-6, y2, z),
					new Vector3 (6, y2, z),
					new Vector3 (8, -y1, z)
				};
			}
			
			if (gos.Length == 5) {

				posn = new Vector3[5] {
					new Vector3 (-8, -y2, z),
					new Vector3 (-6, y2, z),
					new Vector3 (5, y1, z),
					new Vector3 (9, 0, z),
					new Vector3 (8, -y1, z)
				};
			}

			if (gos.Length == 6) {

				posn = new Vector3[6] {
					new Vector3 (-8, -y1, z),
					new Vector3 (-9, 0, z),
					new Vector3 (-5, y1, z),
					new Vector3 (5, y1, z),
					new Vector3 (9, 0, z),
					new Vector3 (8, -y1, z)
				};
			}

			shuffledPosn = ShuffleArray (posn);

			for (int i=0; i<gos.Length; i++) { 
				LeanTween.move(gos[i],shuffledPosn[i],1.0f);
				LeanTween.rotateAround (gos[i], Vector3.forward, 360f, 1.0f);

			}
			Debug.Log ("Exploded draggable letters");
		}

		Vector3[] ShuffleArray(Vector3[] array)
		{
			for (int i = array.Length; i > 0; i--)
			{
				int j = Random.Range (0,i);
				Vector3 temp = array[j];
				array[j] = array[i - 1];
				array[i - 1]  = temp;
			}
			return array;
		}

		
		IEnumerator EnableCollisions(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("TargetLetter"); 
			foreach (GameObject go in gos)
				go.AddComponent<CollisionManager> ();
			Debug.Log ("Enabled Collisions");
		}

		IEnumerator StartPulsing(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			foreach (GameObject go in gos) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go);
			}
		}

		/*
		public void SpellOutWord()
		{
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			
			PlaySoundAndHighlightLetter (tar [0], 0);
			PlaySoundAndHighlightLetter (tar [1], 1);
			PlaySoundAndHighlightLetter (tar [2], 2);
			if (tar.Length >= 4)
				PlaySoundAndHighlightLetter (tar [3], 3);
			if (tar.Length >= 5)
				PlaySoundAndHighlightLetter (tar [4], 4);
			if (tar.Length >= 6)
				PlaySoundAndHighlightLetter (tar [5], 5);
				
			PlaySoundAndHighlightWord ();

			StartCoroutine(CongratsAnimation((tar.Length+1f) * this.clipLength));
				
		}

		void PlaySoundAndHighlightLetter(GameObject targetLetter, float index)
		{

			if (targetLetter.audio != null && targetLetter.audio.clip != null) {
				Debug.Log ("Playing clip for " + targetLetter.name);
				targetLetter.audio.PlayDelayed (index*this.clipLength);  
			}

			StartCoroutine(LightOnAndPulse (new Vector3(targetLetter.transform.position.x,targetLetter.transform.position.y,1),index*this.clipLength,"letter",targetLetter));
			StartCoroutine (LightOff (((index+.5f) * this.clipLength)));
		}

		void PlaySoundAndHighlightWord()
		{
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");
			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				go.audio.PlayDelayed ((tar.Length) * this.clipLength);
			}

			StartCoroutine (LightOnAndPulse (new Vector3(0,-2,1),(tar.Length)*this.clipLength,"word",null));
			StartCoroutine (LightOff ((tar.Length+.5f) * this.clipLength));
		}


		IEnumerator LightOnAndPulse(Vector3 location, float delayTime, string size, GameObject go)
		{
			yield return new WaitForSeconds (delayTime);

			Vector3 scale = new Vector3 (1, 1, 1);
			if (size == "letter")
				scale = new Vector3 (WordCreation.letterScale * 17, WordCreation.letterScale * 17, 1);
			if (size == "word") {
				GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetLetter");
				scale = new Vector3 (tar.Length * WordCreation.letterScale * 12, WordCreation.letterScale * 17, 1);
			}

			GameObject highlight = GameObject.FindGameObjectWithTag ("Light");
			highlight.GetComponent<MeshRenderer> ().enabled = true;
			highlight.transform.position = location;
			highlight.transform.localScale = scale;
			if (go != null)
				Debug.Log ("Highlight on " + go.name);
			 
			PulseOnce (go, size);
		}


		IEnumerator LightOff(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject highlight = GameObject.FindGameObjectWithTag ("Light");
			highlight.GetComponent<MeshRenderer> ().enabled = false;
			
		}

		public void PulseOnce(GameObject go, string size, float scaleUp = 1.3f)
		{
			float pulseLength = clipLength * .15f;

			if (size == "letter") {
				LeanTween.scale (go, new Vector3 (scaleUp * WordCreation.letterScale, scaleUp * WordCreation.letterScale, 1), pulseLength);
				StartCoroutine (ScaleDown (clipLength * .5f, go));
				Debug.Log ("Pulse on " + go.name);
			}

			if (size == "word") {
				GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");

				for (int i=0; i < tar.Length; i++) {
					LeanTween.scale (tar[i], new Vector3 (scaleUp * WordCreation.letterScale, scaleUp * WordCreation.letterScale, 1), pulseLength);
					StartCoroutine (ScaleDown (clipLength * .5f, tar[i]));

				}
			}

		}
		
		IEnumerator ScaleDown(float delayTime, GameObject go)
		{
			yield return new WaitForSeconds (delayTime - .1f);
			
			LeanTween.scale (go,new Vector3(1f*WordCreation.letterScale,1f*WordCreation.letterScale,1),clipLength*.5f);
		}
		*/

		public static void CongratsAnimation(float delayTime)
		{

			float time = 1f;

			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");

			Debug.Log ("Spinning " + go.name + " around");
			LeanTween.rotateAround (go, Vector3.forward, 360f, time).setDelay(delayTime);
			LeanTween.scale (go,new Vector3(go.transform.localScale.x*1.3f,go.transform.localScale.y*1.3f,1),time).setDelay (delayTime);
			LeanTween.moveY (go, 1.5f, time).setDelay (delayTime);

			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			foreach (GameObject letter in tar)
				LeanTween.moveY (letter,-3f,time).setDelay(delayTime);

			Debug.Log ("Playing clip for congrats");
			AudioSource audio = go.AddComponent<AudioSource> ();
			audio.clip = Resources.Load ("Audio/CongratsSound") as AudioClip;
			audio.PlayDelayed (delayTime);

		}


	}
}
