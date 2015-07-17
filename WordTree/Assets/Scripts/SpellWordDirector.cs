using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SpellWordDirector : MonoBehaviour {


		void Start () {

			StartCoroutine(LightOff(0));

			VocabList.CreateWordsAndObjectSwitch (GameDirector.currentWord);

			GameObject arrow = GameObject.FindGameObjectWithTag ("Arrow");
			arrow.AddComponent<GestureManager> ().AddAndSubscribeToGestures (arrow);

			GameObject word = GameObject.FindGameObjectWithTag ("WordObject");
			word.GetComponent<GestureManager> ().UnsubscribeFromGestures (word);
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
			Vector3[] Position = new Vector3[gos.Length];

			if (gos.Length == 4) {
				int z = -1;
				Position = new Vector3[4] {
					new Vector3 (-6, 0, z),
					new Vector3 (-3, 2, z),
					new Vector3 (3, 2, z),
					new Vector3 (6, 0, z)
				};
			}
			
			if (gos.Length == 5) {
				int z = -1;
				Position = new Vector3[5] {
					new Vector3 (-9, 0, z),
					new Vector3 (-6, 2, z),
					new Vector3 (3, 3, z),
					new Vector3 (6, 1.5f, z),
					new Vector3 (9, 0, z)
				};
			}

			if (gos.Length == 6) {
				int z = -1;
				Position = new Vector3[6] {
					new Vector3 (-9, 0, z),
					new Vector3 (-6, 1, z),
					new Vector3 (-3, 2, z),
					new Vector3 (3, 2, z),
					new Vector3 (6, 1, z),
					new Vector3 (9, 0, z)
				};
			}

			for (int i=0; i<gos.Length; i++) { 
				LeanTween.move(gos[i],Position[i],1.0f).setEase (LeanTweenType.easeOutQuad);
			}
			Debug.Log ("Exploded draggable letters");
		}

		IEnumerator EnableCollisions(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("TargetLetter"); 
			foreach (GameObject go in gos)
				go.AddComponent<CollisionManager> ();
			Debug.Log ("Added Collision Manager");
		}

		public void SpellOutWord()
		{
			float clipLength = .8f;
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			
			PlaySoundAndHighlightLetter (gos [0], 0);
			PlaySoundAndHighlightLetter (gos [1], 1);
			PlaySoundAndHighlightLetter (gos [2], 2);
			if (gos.Length >= 4)
				PlaySoundAndHighlightLetter (gos [3], 3);
			if (gos.Length >= 5)
				PlaySoundAndHighlightLetter (gos [4], 4);
			if (gos.Length >= 6)
				PlaySoundAndHighlightLetter (gos [5], 5);
				
			PlaySoundAndHighlightWord ();

			StartCoroutine(CongratsAnimation((gos.Length+1f) * clipLength));
				
		}

		void PlaySoundAndHighlightLetter(GameObject go, float index)
		{
			float clipLength = .8f;

			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				go.audio.PlayDelayed (index*clipLength);  
			}

			StartCoroutine(LightOn (go.transform.position,index*clipLength,"letter"));
			StartCoroutine (LightOff ((index+.5f) * clipLength));
		}

		void PlaySoundAndHighlightWord()
		{
			float clipLength = .8f;
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");
			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				go.audio.PlayDelayed ((gos.Length) * clipLength);
			}

			StartCoroutine (LightOn (new Vector3(0,-2,-1),(gos.Length)*clipLength,"word"));
			StartCoroutine (LightOff ((gos.Length+.5f) * clipLength));
		}



		IEnumerator LightOn(Vector3 location, float delayTime, string size)
		{
			yield return new WaitForSeconds (delayTime);

			Vector3 scale = new Vector3 (1, 1, 1);
			if (size == "letter")
				scale = new Vector3 (5, 5, 1);
			if (size == "word")
				scale = new Vector3 (20, 5, 1);

			GameObject highlight = GameObject.FindGameObjectWithTag ("Light");
			highlight.GetComponent<MeshRenderer> ().enabled = true;
			highlight.transform.position = location;
			highlight.transform.localScale = scale;
			Debug.Log ("Highlight on" + location);
		}
		
		IEnumerator LightOff(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject highlight = GameObject.FindGameObjectWithTag ("Light");
			highlight.GetComponent<MeshRenderer> ().enabled = false;
			
		}

		IEnumerator CongratsAnimation(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");

			Debug.Log ("Spinning " + go.name + " around");
			LeanTween.rotateAround (go, Vector3.forward, 360f, 1.5f);

			Debug.Log ("Playing clip for congrats");
			AudioSource audio = go.AddComponent<AudioSource> ();
			audio.clip = Resources.Load ("Audio/Congrats") as AudioClip;
			audio.Play ();

		}


	}
}
