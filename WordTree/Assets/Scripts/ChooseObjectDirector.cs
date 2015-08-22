using UnityEngine;
using System.Collections;

//Main controller for Scene 3: "Choose Object"
//Initializes scene and creates objects, loads narrator kid, handles touch events and words completed

namespace WordTree
{
	public class ChooseObjectDirector : MonoBehaviour {

		//Called on start, used to initialize stuff
		void Start () {

			//Create objects and background
			LoadLevel (ProgressManager.currentLevel);

			//Find narrator kid, load image for kid
			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			kid.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Graphics/" + ProgressManager.chosenKid);

			//Grow Animation for kid
			GrowKid ();

			//Load audio for kid
			kid.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/KidSpeaking/" + ProgressManager.currentLevel) as AudioClip;
			//Check if audio clip is attached
			if (kid.audio.clip != null) {
				kid.audio.priority = 255;
				//Play audio - kid speaks
				kid.audio.Play ();
			}

			//Find ChooseObjectDirector
			GameObject dir = GameObject.Find ("ChooseObjectDirector");
			//Load background music for scene onto ChooseObjectDirector
			dir.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/BackgroundMusic/" + ProgressManager.currentLevel) as AudioClip;
			//Check if audio clip is attached
			if (dir.audio.clip != null) {
				dir.audio.volume = .7f;
				//Start playing background music
				dir.audio.Play ();
			}

			//Find buttons and suscribe to gestures
			GameObject button = GameObject.FindGameObjectWithTag ("Button");
			button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			//Find word objects
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos) {

				//Start pulsing for each object
				Debug.Log ("Started pulsing for " + go.name);
				go.GetComponent<PulseBehavior> ().StartPulsing (go);

				//Check for word completion

				//If word not completed, darken and fade out object
				if (!ProgressManager.IsWordCompleted(go.name)){
					SetColorAndTransparency (go,Color.grey,.9f);
				}
				//If word completed, brighten and fill in object
				if (ProgressManager.IsWordCompleted(go.name)){
					Debug.Log ("Word Completed: " + go.name);
					SetColorAndTransparency(go,Color.white,1f);
				}
			}

			//Check for level completion
			if (CheckCompletedLevel ()) {
				//If level completed, add to completedLevels and unlock the next level
				ProgressManager.AddCompletedLevel (ProgressManager.currentLevel);
				ProgressManager.UnlockNextLevel (ProgressManager.currentLevel);
			}


		}

		//Update is called once per frame
		void Update(){

			//Find ChooseObjectDirector
			GameObject dir = GameObject.Find ("ChooseObjectDirector");

			//If attached audio (background music) has stopped playing, play the audio
			//For keeping background music playing in a loop
			if (!dir.audio.isPlaying)
				dir.audio.Play ();
			
		}

		//Animation to grow kid to desired size
		void GrowKid()
		{
			float scale = .5f; //desired scale size to grow kid to
			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");
			//Scale up kid
			LeanTween.scale (kid, new Vector3 (scale, scale, 1f), 1f);
		}

		//Change color and transparency of objects
		//For user to keep track of which words have been completed
		void SetColorAndTransparency(GameObject go, Color color, float transparency)
		{
			//Set transparency
			Color temp = go.renderer.material.color;
			temp.a = transparency;
			go.renderer.material.color = temp;

			//Set color
			go.GetComponent<SpriteRenderer>().color = color;

		}

		//Check if level has been completed, i.e. if all words have been completed
		//Returns true if level completed, otherwise returns false
		bool CheckCompletedLevel()
		{
			int numCompleted = 0; //keep track of number of words completed

			//Find word objects
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos) {
				//For learn spelling mode
				if (ProgressManager.currentMode == 1){
					//increment numCompleted if word completed
					if (ProgressManager.completedWordsLearn.Contains (go.name))
						numCompleted = numCompleted + 1;
				}
				//For spelling game mode
				if (ProgressManager.currentMode == 2){
					//increment numCompleted if word completed
					if (ProgressManager.completedWordsSpell.Contains (go.name))
						numCompleted = numCompleted + 1;
				}
				//For sound game mode
				if (ProgressManager.currentMode == 3){
					//increment numCompleted if word completed
					if (ProgressManager.completedWordsSound.Contains (go.name))
						numCompleted = numCompleted + 1;
				}
			}

			//check if all words have been completed
			if (numCompleted == gos.Length) {
				Debug.Log ("Level Completed: " + ProgressManager.currentLevel);
				return true;
			}
			return false;
					
		}

		//Initialize background object
		void CreateBackGround(string name, Vector3 posn, float scale)
		{
			//Find background object
			GameObject background = GameObject.Find ("Background");

			//load image
			SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
			Sprite sprite = Resources.Load<Sprite>("Graphics/Backgrounds/"+name);
			if (sprite == null)
				Debug.Log("ERROR: could not load background");
			spriteRenderer.sprite = sprite;

			//set position
			background.transform.position = posn;

			//set scale
			background.transform.localScale = new Vector3(scale,scale,1);

		}

		//Initialize scene - create objects and background
		//string level: name of level to load
		void LoadLevel(string level)
		{
			//Get properties of the level, including the words, background position, and background scale
			LevelProperties prop = LevelProperties.GetLevelProperties (level);
			string[] words = prop.Words ();
			Vector3 backgroundPosn = prop.BackgroundPosn ();
			float backgroundScale = prop.BackgroundScale ();

			//Create word objects
			LevelCreation.CreateWordObjects (level, words);

			//Create background
			CreateBackGround (level, backgroundPosn, backgroundScale);

		}



	}
}
