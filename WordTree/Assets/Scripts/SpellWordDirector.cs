using UnityEngine;
using System.Collections;


namespace WordTree
{
	public class SpellWordDirector : MonoBehaviour {

		float clipLength = .7f;

		void Start () {

			StartCoroutine(LightOff(0));

			VocabList.CreateSpellingLesson (GameDirector.currentWord);

			GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
			foreach (GameObject button in buttons)
				button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			GameObject word = GameObject.FindGameObjectWithTag ("WordObject");
			word.GetComponent<GestureManager> ().DisableGestures (word);

			word.audio.Play();

			StartCoroutine(ExplodeWord(1));
			StartCoroutine (EnableCollisions(2));

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			foreach (GameObject go in gos) {
				go.GetComponent<PulseBehavior>().StartPulsing(go);
			}

		}


		IEnumerator ExplodeWord(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");

			Vector3[] PositionTemplate = new Vector3[gos.Length];
			Vector3[] Position = new Vector3[gos.Length];
			int[] OrderTemplate = new int[gos.Length];
			int[] Order = new int[gos.Length];
			int z = -2;

			if (gos.Length == 3) {

				PositionTemplate = new Vector3[3] {
					new Vector3 (-7, 0, z),
					new Vector3 (6, 2, z),
					new Vector3 (8, -3, z)
				};

				OrderTemplate = new int[3] {0,1,2};
				Order = ShuffleArray(OrderTemplate);

				Position = new Vector3[3]{
				PositionTemplate[Order[0]],
				PositionTemplate[Order[1]],
				PositionTemplate[Order[2]]
				};
			}

			if (gos.Length == 4) {

				PositionTemplate = new Vector3[4] {
					new Vector3 (-8, -3, z),
					new Vector3 (-6, 2, z),
					new Vector3 (6, 2, z),
					new Vector3 (8, -3, z)
				};

				OrderTemplate = new int[4] {0,1,2,3};
				Order = ShuffleArray(OrderTemplate);

				Position = new Vector3[4]{
					PositionTemplate[Order[0]],
					PositionTemplate[Order[1]],
					PositionTemplate[Order[2]],
					PositionTemplate[Order[3]]
				};
			}
			
			if (gos.Length == 5) {

				PositionTemplate = new Vector3[5] {
					new Vector3 (-8, -2, z),
					new Vector3 (-6, 2, z),
					new Vector3 (5, 3, z),
					new Vector3 (9, 0, z),
					new Vector3 (8, -3, z)
				};

				OrderTemplate = new int[5] {0,1,2,3,4};
				Order = ShuffleArray(OrderTemplate);

				Position = new Vector3[5]{
					PositionTemplate[Order[0]],
					PositionTemplate[Order[1]],
					PositionTemplate[Order[2]],
					PositionTemplate[Order[3]],
					PositionTemplate[Order[4]]
				};
			}

			if (gos.Length == 6) {
				PositionTemplate = new Vector3[6] {
					new Vector3 (-8, -3, z),
					new Vector3 (-9, 0, z),
					new Vector3 (-5, 3, z),
					new Vector3 (5, 3, z),
					new Vector3 (9, 0, z),
					new Vector3 (8, -3, z)
				};

				OrderTemplate = new int[6] {0,1,2,3,4,5};
				Order = ShuffleArray(OrderTemplate);

				Position = new Vector3[6] {
					PositionTemplate[Order[0]],
					PositionTemplate[Order[1]],
					PositionTemplate[Order[2]],
					PositionTemplate[Order[3]],
					PositionTemplate[Order[4]],
					PositionTemplate[Order[5]]
				};
			}

			for (int i=0; i<gos.Length; i++) { 
				LeanTween.move(gos[i],Position[i],1.0f).setEase (LeanTweenType.easeOutQuad);
			}
			Debug.Log ("Exploded draggable letters");
		}

		int[] ShuffleArray(int[] array)
		{
			for (int i = array.Length; i > 0; i--)
			{
				int j = Random.Range (0,i);
				int temp = array[j];
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
				scale = new Vector3 (WordCreation.xScale * 17, WordCreation.yScale * 17, 1);
			if (size == "word") {
				GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetLetter");
				scale = new Vector3 (tar.Length * WordCreation.xScale * 12, WordCreation.yScale * 17, 1);
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

		void PulseOnce(GameObject go, string size)
		{
			float pulseLength = clipLength * .15f;
			float scaleUp = 1.3f;

			if (size == "letter") {
				LeanTween.scale (go, new Vector3 (scaleUp * WordCreation.xScale, scaleUp * WordCreation.yScale, 1), pulseLength);
				StartCoroutine (ScaleDown (clipLength * .5f, go));
				Debug.Log ("Pulse on " + go.name);
			}

			if (size == "word") {
				GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");

				for (int i=0; i < tar.Length; i++) {
					LeanTween.scale (tar[i], new Vector3 (scaleUp * WordCreation.xScale, scaleUp * WordCreation.yScale, 1), pulseLength);
					StartCoroutine (ScaleDown (clipLength * .5f, tar[i]));
				}
			}

		}
		
		IEnumerator ScaleDown(float delayTime, GameObject go)
		{
			yield return new WaitForSeconds (delayTime - .1f);
			
			LeanTween.scale (go,new Vector3(1f*WordCreation.xScale,1f*WordCreation.yScale,1),clipLength*.5f);
		}

		IEnumerator CongratsAnimation(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");

			Debug.Log ("Spinning " + go.name + " around");
			LeanTween.rotateAround (go, Vector3.forward, 360f, 1.5f);

			Debug.Log ("Playing clip for congrats");
			AudioSource audio = go.AddComponent<AudioSource> ();
			audio.clip = Resources.Load ("Audio/CongratsSound") as AudioClip;
			audio.Play ();

		}


	}
}
