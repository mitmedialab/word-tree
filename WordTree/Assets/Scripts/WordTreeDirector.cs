using UnityEngine;
using System.Collections;

// Main game controller for "Word Tree" scene
// Sets up level icons of word tree, loads kid 

namespace WordTree
{
	public class WordTreeDirector : MonoBehaviour {

		// called on start, initialize stuff
		void Start() {
			
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

			// add all levels onto level list
			ProgressManager.InitiateLevelList();

			// unlock the first two levels
			ProgressManager.unlockedLevels.Add(ProgressManager.levelList[0]);
			ProgressManager.unlockedLevels.Add(ProgressManager.levelList[3]);

			// set up kid
			GameObject kid = GameObject.FindGameObjectWithTag("Kid");

			kid.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/" + ProgressManager.chosenKid);

			// grow kid animation
			GrowKid();

			// load background music onto the word tree director
			GameObject dir = GameObject.Find("WordTreeDirector");
			dir.AddComponent<AudioSource>().clip = Resources.Load("Audio/BackgroundMusic/WordTree") as AudioClip;

			// play background music if attached to director
			if (dir.GetComponent<AudioSource>().clip != null)
				dir.GetComponent<AudioSource>().volume = .25f;
				dir.GetComponent<AudioSource>().Play();

			// subscribe home button to gestures
			GameObject home = GameObject.Find("HomeButton");
			home.AddComponent<GestureManager>().AddAndSubscribeToGestures(home);

			// set up lock - lock starts out as closed
			GameObject Lock = GameObject.Find(ProgressManager.lockStatus);
			if (ProgressManager.lockStatus == "")
				Lock = GameObject.Find("LockClosed");

			// subscribe lock to gestures
			Lock.AddComponent<GestureManager>().AddAndSubscribeToGestures(Lock);

			// move lock to front
			LeanTween.moveZ(Lock, -2f, .01f);

			// find level icons
			GameObject[] gos = GameObject.FindGameObjectsWithTag("LevelIcon");
			foreach (GameObject go in gos) {
				
			
				// if level is not unlocked yet, make level icon disappear
				if (!ProgressManager.IsLevelUnlocked(go.name)){
					Color color = go.GetComponent<Renderer>().material.color;
					color.a = 0f;
					go.GetComponent<Renderer>().material.color = color;
				}

				// if level has been unlocked
				if (ProgressManager.IsLevelUnlocked(go.name))
				{
					// subscribe level icon to gestures
					go.AddComponent<GestureManager>().AddAndSubscribeToGestures(go);

					// start pulsing level icon
					go.AddComponent<PulseBehavior>().StartPulsing(go);

					// if level has not been completed
					if (!ProgressManager.IsLevelCompleted(go.name))
						// darken level icon
						go.GetComponent<SpriteRenderer>().color = Color.grey;

					// if level has been completed
					if (ProgressManager.IsLevelCompleted(go.name)){
						// brighten level icon
						go.GetComponent<SpriteRenderer>().color = Color.white;
					}
				}


			}

			// if lock has been previously opened
			if (ProgressManager.lockStatus == "LockOpen")
				// keep showing all level icons on word tree
				ProgressManager.UnlockAllLevels();
		
		}


		// Called once per frame
		void Update(){

			// keep background music playing in a loop
			GameObject dir = GameObject.Find("WordTreeDirector");
			if (!dir.GetComponent<AudioSource>().isPlaying)
				dir.GetComponent<AudioSource>().Play();
			// if user presses escape or 'back' button on android, exit program
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();
			
		}


		// Grow kid animation - kid spirals into place
		void GrowKid()
		{
			float scale = .25f; // scale to grow kid to
			GameObject kid = GameObject.FindGameObjectWithTag("Kid"); 

			// grow kid to specified size
			LeanTween.scale(kid, new Vector3 (scale, scale, 1f), 1f);

			// rotate kid around once
			LeanTween.rotateAround(kid, Vector3.forward, 360f, 1f);


			// if we are going back to the word tree scene from another level
			// i.e. if this isn't the first time entering the word tree scene
			if (ProgressManager.currentLevel != "") {
				// kid grows out from appropriate level icon (of the level user just came from)
				kid.transform.position = GameObject.Find(ProgressManager.currentLevel + ProgressManager.currentMode).transform.position;

				// move kid to bottom left hand corner of screen
				LeanTween.move(kid, new Vector3 (-7.5f, -3.5f, -2), 1f);
			}
		}





		

	}
}
