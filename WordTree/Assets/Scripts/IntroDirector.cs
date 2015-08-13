using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class IntroDirector : MonoBehaviour {


		void Start () {

			GameObject[] kids = GameObject.FindGameObjectsWithTag ("Kid");
			foreach (GameObject kid in kids) {
				kid.AddComponent<PulseBehavior> ().StartPulsing (kid);
				kid.AddComponent<GestureManager> ().AddAndSubscribeToGestures (kid);
			}

			GameObject dir = GameObject.Find ("IntroDirector");
			dir.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/BackgroundMusic/WordTree") as AudioClip;
			if (dir.audio.clip != null)
				dir.audio.Play ();

			ProgressManager.lockStatus = "";
	
		}

		void Update(){

			GameObject dir = GameObject.Find ("IntroDirector");
			if (!dir.audio.isPlaying)
				dir.audio.Play ();

		}
	

	}
}
