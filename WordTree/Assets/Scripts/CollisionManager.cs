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
			if (other.name == gameObject.name) {
				SpriteRenderer sprite = other.GetComponent<SpriteRenderer> ();
				sprite.color = Color.grey;
				Debug.Log ("Collision on " + other.name);

				PanGesture pg = other.GetComponent<PanGesture>();
				pg.enabled = false;
				Debug.Log ("Disabled touch for " + other.name);
		

				other.transform.position = gameObject.transform.position;

				if (CheckCompletedWord() == true){

					PlayEntireWord ();

				}

			}
		}


		bool CheckCompletedWord ()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("PlayObject");
			foreach (GameObject go in gos) {
				PanGesture pg = go.GetComponent<PanGesture> ();
				if (pg.enabled == true)
					return false;
			}

			Debug.Log ("Word Completed");
			return true;
		}

		void PlayLetterSounds ()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("PlayObject");
			AudioSource[] sounds = new AudioSource[gos.Length];

			int j = 0;
			foreach (GameObject go in gos) {
				AudioSource audio = go.GetComponent<AudioSource>();
				sounds[j] = audio;
				j = j+1;
			}

			for (var k = 0; k < sounds.Length; k++) {
				sounds[k].PlayDelayed (1);
			}

		}

		void PlayEntireWord()
		{
			GameObject word = GameObject.Find (Application.loadedLevelName);
			AudioSource[] sounds = word.GetComponents<AudioSource> ();
			AudioSource pronunciation = sounds[0];
			AudioSource congrats = sounds[1];

			pronunciation.PlayDelayed(1);
			congrats.PlayDelayed(2);


		}



	}
	
}