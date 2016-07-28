using UnityEngine;
using System.Collections;

//<summary>
//Main game controller for "Choose Object" scene
//Creates word objects for user to pick, sets up kid avatar
//</summary>
namespace WordTree
{
	public class ChooseObjectDirector : MonoBehaviour
	{
		private GestureManager gestureManager;
		//<summary>
		//Called on start, used to initialize stuff
		//</summary>
		void Start()
		{
			//Scale graphics to screen size
			Utilities.setCameraViewForScreen();
			//create instance of grestureManager
			GestureManager gestureManager = GameObject.
				FindGameObjectWithTag(Constants.Tags.TAG_GESTURE_MANAGER).GetComponent<GestureManager>();
			if (gestureManager != null) 
			{
				//Create objects and background
				LoadLevel(ProgressManager.currentLevel);
				//Set up kid
				GameObject kid = GameObject.FindGameObjectWithTag(Constants.Tags.TAG_KID);
				//check if kid is attached
				if (kid != null)
				{
					kid.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/"
						+ ProgressManager.chosenKid);
				} 
				else 
				{
					Debug.LogWarning("Cannot find kid in scene");
				}
				//check if sprite is attached
				if (kid.GetComponent<SpriteRenderer>().sprite != null) 
				{
					//Play Grow Animation for kid
					GrowKid();
					//Load audio for kid
					kid.AddComponent<AudioSource>().clip = Resources.Load("Audio/KidSpeaking/"
					+ ProgressManager.currentLevel) as AudioClip;
					//Check if audio clip is attached
					if (kid.GetComponent<AudioSource>().clip != null) 
					{
						kid.GetComponent<AudioSource>().priority = 0;
						kid.GetComponent<AudioSource>().volume = 1.0f;
						//Play audio clip attached to kid if there is one
						kid.GetComponent<AudioSource>().Play();
					} 
					else 
					{
						Debug.LogWarning("No audio found");
					}
				}
				else 
				{
					Debug.LogWarning("Cannot load sprite");
				}
					//Find ChooseObjectDirector gameObject
					GameObject dir = GameObject.Find("ChooseObjectDirector");
				if (dir != null) 
				{
					//Load background music for scene onto ChooseObjectDirector
					dir.AddComponent<AudioSource>().clip = Resources.Load("Audio/BackgroundMusic/"
					+ ProgressManager.currentLevel) as AudioClip;
					//Check if audio clip is attached
					if (dir.GetComponent<AudioSource>().clip != null)
					{
						dir.GetComponent<AudioSource>().priority = 0;
						dir.GetComponent<AudioSource>().volume = .25f;
						//Start playing background music if attached
						dir.GetComponent<AudioSource>().Play();
					} 
					else 
					{
						Debug.LogWarning("No audio file found");
					}
				} 
				else 
				{
					Debug.LogWarning("Cannot find ChooseObjectDirector");
				}
				//Subscribe buttons to touch gestures
				GameObject button = GameObject.FindGameObjectWithTag(Constants.Tags.TAG_BUTTON);
				if (button != null) 
				{
					button.AddComponent<GestureManager>().AddAndSubscribeToGestures(button);
				}
				else 
				{
					Debug.LogWarning("Cannot find button");
				}
				//Find word objects
				GameObject[] gos = GameObject.FindGameObjectsWithTag(Constants.Tags.TAG_WORD_OBJECT);
				foreach (GameObject go in gos) 
				{	
					//Start pulsing for each object
					Debug.Log("Started pulsing for " + go.name);
					go.GetComponent<PulseBehavior>().StartPulsing(go);
					//Check if word has been completed by user
					//If word not completed, darken and fade out object
					if (!ProgressManager.IsWordCompleted(go.name))
					{
						SetColorAndTransparency(go, Color.grey, .9f);
					}
					//If word completed, brighten and fill in object
					else 
					{
						Debug.Log("Word Completed: " + go.name);
						SetColorAndTransparency(go, Color.white, 1f);
					}
				}
				//Check if this level has been completed, i.e. if all words in the level have been completed
				if (CheckCompletedLevel()) 
				{
					//If level completed, add to completedLevels list and unlock the next level
					ProgressManager.AddCompletedLevel(ProgressManager.currentLevel);
					ProgressManager.UnlockNextLevel(ProgressManager.currentLevel);
				}
			}
			else 
			{
				Debug.LogError("Cannot find gesture manager component");
			}
		}

		//<summary>
		//Update is called once per frame
		//</summary>
		void Update()
		{
			//Find ChooseObjectDirector
			GameObject dir = GameObject.Find("ChooseObjectDirector");
			if (dir != null) 
			{
				if (dir.GetComponent<AudioSource>() != null) 
				{
					//If attached audio (background music) has stopped playing, play the audio
					//For keeping background music playing in a loop
					if (!dir.GetComponent<AudioSource>().isPlaying) 
					{
						dir.GetComponent<AudioSource>().Play();
					}
				} 
				else 
				{ 
					Debug.LogWarning("Cannot load audio component of ChooseObjectDirector");
				}
			}
			else 
			{
				Debug.LogWarning("Cannot load ChooseObjectDirector");
			}
			// if user presses escape or 'back' button on android, exit program
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				Application.Quit();
			}	
		}

		//<summary>
		//Animation to grow kid to desired size
		//</summary>
		void GrowKid()
		{
			float scale = .3f; //desired scale to grow kid to
			GameObject kid = GameObject.FindGameObjectWithTag(Constants.Tags.TAG_KID);
			if (kid != null) 
			{
				//Scale up kid to desired size
				LeanTween.scale(kid, new Vector3(scale, scale, 1f), 1f);
			}
			else 
			{
				Debug.LogWarning("Cannot find kid");
			}
		}

		//<summary>
		//Change color and transparency of objects
		//For user to keep track of which words have been completed
		//</summary>
		void SetColorAndTransparency(GameObject go, Color color, float transparency)
		{
			//Set transparency
			Color temp = go.GetComponent<Renderer>().material.color;
			temp.a = transparency;
			go.GetComponent<Renderer>().material.color = temp;
			//Set color
			go.GetComponent<SpriteRenderer>().color = color;
		}

		//<summary>
		//Check if level has been completed, i.e. if all words have been completed
		//Return true if level completed, otherwise return false
		//</summary>
		bool CheckCompletedLevel()
		{
			int numCompleted = 0; //counter for number of words completed in the scene
			//Find word objects
			GameObject[] gos = GameObject.FindGameObjectsWithTag(Constants.Tags.TAG_WORD_OBJECT);
			foreach (GameObject go in gos) 
			{
				//if current scene is Learn Spelling
				if (ProgressManager.currentMode == 1 && ProgressManager.completedWordsLearn.Contains(go.name))
				{
					//completed a word; update counter
					numCompleted = numCompleted + 1;
				}
				//if current scene is Spelling Game
				if (ProgressManager.currentMode == 2 && ProgressManager.completedWordsSpell.Contains(go.name))
				{
					//completed a word; update counter
					numCompleted = numCompleted + 1;
				}
				//if current scene is Sound Game
				if (ProgressManager.currentMode == 3 && ProgressManager.completedWordsSound.Contains(go.name)) 
				{
				    //completed a word; update counter
					numCompleted = numCompleted + 1;
				}
			}
			//check if all words have been completed
			//by comparing number of completed words with the number of word objects in the scene
			if (numCompleted == gos.Length) 
			{
				Debug.Log("Level Completed: " + ProgressManager.currentLevel);
				return true;
			}
			return false;
		}

		//<summary>
		//Initialize background object
		//Takes in the file name for background image, desired position of image, and scale of image.
		//</summary>
		void CreateBackGround(string name, Vector3 posn, float scale)
		{
			//Find background object
			GameObject background = GameObject.Find("Background");
			if (background != null) 
			{
				//load image
				SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
				Sprite sprite = Resources.Load<Sprite>("Graphics/Backgrounds/" + name);
				if (sprite != null) 
				{
					spriteRenderer.sprite = sprite;
					//set position
					background.transform.position = posn;
					//set scale
					background.transform.localScale = new Vector3(scale, scale, 1);
				}
				else
				{
					Debug.LogError("ERROR: could not load background");
				}
			} 
			else 
			{
				Debug.LogWarning("Cannot find background game object");
			}
		}

		//<summary>
		//Initialize scene - create objects and background
		//string level: name of level to load
		//</summary>
		void LoadLevel(string level)
		{
			//Get properties of the level, including the words included in the level, the position of the background image, 
			// and the desired scale of the background image
			LevelProperties prop = LevelProperties.GetLevelProperties(level);
			if (prop != null) 
			{
				string[] words = prop.Words();
				Vector3 backgroundPosn = prop.BackgroundPosn();
				float backgroundScale = prop.BackgroundScale();
				//Create word objects
				LevelCreation.CreateWordObjects(level, words);
				//Create background
				CreateBackGround(level, backgroundPosn, backgroundScale);
			} 
			else 
			{
				Debug.LogWarning("Cannot find level name");
			}
		}
			
	}
}
