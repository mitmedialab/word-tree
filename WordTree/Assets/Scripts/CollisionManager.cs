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

				GestureManager gm = other.GetComponent<GestureManager>();
				gm.DisableGestures(other.gameObject);
				Debug.Log ("Disabled touch for " + other.name);

				PulseBehavior pb = other.GetComponent<PulseBehavior>();
				pb.StopPulsing (other.gameObject);
				Debug.Log ("Stopped pulsing for " + other.name);

				other.transform.position = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y,-1);

			}

		}



		bool CheckCompletedWord ()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			foreach (GameObject go in gos) {
				PanGesture pg = go.GetComponent<PanGesture> ();
				if (pg.enabled == true)
					return false;
			}

			Debug.Log ("Word Completed");
			return true;
		}



		void Update()
		{
			if (CheckCompletedWord () == true) {
				PlayNextLetter();
			}
		}


		void PlayNextLetter()
		{
			int musicNumber = 0;
			AudioSource[] sounds = GameObject.FindObjectsOfType (typeof(AudioSource)) as AudioSource[];

			if (musicNumber < sounds.Length){
				audio.clip = sounds[musicNumber].clip;
				audio.Play ();
				musicNumber = musicNumber+1;
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