using UnityEngine;
using System.Collections;

// Main game controller for the Intro scene
// Sets up kid avatars for user to pick

namespace WordTree
{
	public class IntroDirector : MonoBehaviour {

		// Called on start, used to initialize stuff
		void Start () {
			//set up camera view to reflect screen size

			// game is designed for 16.0:9.0 aspect ratio
			float targetaspect = 16.0f / 9.0f;

			// determine the game window's current aspect ratio
			float windowaspect = (float)Screen.width / (float)Screen.height;

			//want game's current aspect ratio to match the target aspect ratio
			// current viewport height should be scaled by this amount
			float scaleHeight = windowaspect / targetaspect;

			// if scaleHeight is less than current height, create rectangle to so desired height:width ratio 
			//is created
			if (scaleHeight < 1.0f)
			{
				Rect rect = Camera.main.rect;

				rect.width = 1.0f;
				rect.height = scaleHeight;
				rect.x = 0;
				rect.y = (1.0f - scaleHeight) / 2.0f;

				Camera.main.rect = rect;
			}
			//if scaleHeight is greater or equal to current height, create rectangle so 
			//desired height:width ratio is created
			else 
			{
				float scalewidth = 1.0f / scaleHeight;

				Rect rect = Camera.main.rect;

				rect.width = scalewidth;
				rect.height = 1.0f;
				rect.x = (1.0f - scalewidth) / 2.0f;
				rect.y = 0;

				Camera.main.rect = rect;
			}
			//create instance of grestureManager
			GestureManager gestureManager =GameObject.FindGameObjectWithTag(Constants.Tags.TAG_GESTURE_MANAGER)
				.GetComponent<GestureManager>();


			// find kid
			GameObject[] kids = GameObject.FindGameObjectsWithTag(Constants.Tags.TAG_KID);

		foreach (GameObject kid in kids) {
				// start pulsing kid
				
				kid.AddComponent<PulseBehavior>().StartPulsing(kid);

				// subscribe kid to touch gestures
				gestureManager.AddAndSubscribeToGestures(kid);
			}

			// find IntroDirector
			GameObject dir = GameObject.Find("IntroDirector");

			// load Background music onto IntroDirector
			dir.AddComponent<AudioSource>().clip = Resources.Load("Audio/BackgroundMusic/WordTree") as AudioClip;
			// play background music if attached
			if (dir.GetComponent<AudioSource>().clip != null)
				dir.GetComponent<AudioSource>().Play();

			ProgressManager.lockStatus = "";
	
		}

		// Update is called once per frame
		void Update(){

			GameObject dir = GameObject.Find("IntroDirector");
			//If attached audio (background music) has stopped playing, play the audio
			//For keeping background music playing in a loop
			if (!dir.GetComponent<AudioSource>().isPlaying)
				dir.GetComponent<AudioSource>().volume = .25f;
				dir.GetComponent<AudioSource>().Play();
			// if user presses escape or 'back' button on android, exit program
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();
			

		}
	

	}
}
