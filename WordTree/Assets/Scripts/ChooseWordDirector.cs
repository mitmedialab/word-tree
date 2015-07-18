using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class ChooseWordDirector : MonoBehaviour {


		void Start () {

			CreateLevelandBackgroundSwitch (GameDirector.currentLevel);

			GameObject arrow = GameObject.FindGameObjectWithTag ("Arrow");
			arrow.AddComponent<GestureManager> ().AddAndSubscribeToGestures (arrow);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos) {

				if (!IsWordCompleted(go.name)){
					Debug.Log ("Started pulsing for " + go.name);
					go.GetComponent<PulseBehavior> ().StartPulsing (go);
				}

				if (IsWordCompleted(go.name)){
					Debug.Log ("Word Completed: " + go.name);
					Debug.Log ("Dimmed " + go.name);
					go.GetComponent<SpriteRenderer>().color = Color.gray;
				}
			}

			if (CheckCompletedLevel ())
				AddCompletedLevel (GameDirector.currentLevel);


		}

		bool CheckCompletedLevel()
		{
			int completedWords = 0;

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("WordObject");
			foreach (GameObject go in gos) {
				if (GameDirector.completedWords.Contains (go.name))
					completedWords = completedWords + 1;
			}

			if (completedWords == gos.Length)
				return true;
			return false;
					
		}
		
		void AddCompletedLevel(string level)
		{
			GameDirector.completedLevels.Add (level);
		}


		bool IsWordCompleted(string word)
		{
			if (GameDirector.completedWords.Contains (word))
				return true;
			return false;
			
		}

		void CreateBackGround(string name, Vector3 posn, Vector3 scale)
		{
			GameObject background = GameObject.Find ("Background");
			SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
			Sprite sprite = Resources.Load<Sprite>("Graphics/Backgrounds/"+name);
			if (sprite == null)
				Debug.Log("ERROR: could not load background");
			spriteRenderer.sprite = sprite;

			background.transform.position = posn;
			background.transform.localScale = scale;

		}


		void CreateLevelandBackgroundSwitch(string level)
		{
			switch(level)
			{
				
			case "Fruits":

				LevelCreation.CreateLevel ("Fruits",new string[] {"Apple","Banana","Grape","Cherry","Orange"},new float[] {.7f, 1f, 1f, .7f, 1f}, 5);
				CreateBackGround("Fruits",new Vector3(0,0,2),new Vector3(2.1f,2.1f,1));
				break;

			case "Animals":

				LevelCreation.CreateLevel ("Animals",new string[] {"Bird","Zebra","Rabbit","Fish","Horse"},new float[] {.6f, .9f, .6f, 1.1f, .9f}, 5);
				CreateBackGround("Animals",new Vector3(0,0,2),new Vector3(1.3f,1.3f,1));
				break;

			case "SchoolSupplies":
				
				LevelCreation.CreateLevel ("SchoolSupplies",new string[] {"Book","Glue","Crayon","Tape","Pencil"},new float[] {.1f, .3f, .3f, .7f, 1f}, 5);
				CreateBackGround("SchoolSupplies",new Vector3(0,0,2),new Vector3(3.6f,3.6f,1));
				break;

			case "Clothes":
				
				LevelCreation.CreateLevel ("Clothes",new string[] {"Boot","Jacket","Glove","Pants","Shirt"},new float[] {.6f, .35f, 1.2f, 1f, .6f}, 5);
				CreateBackGround("Clothes",new Vector3(0,-7,2),new Vector3(1.8f,1.8f,1));
				break;

			case "Jobs":
				
				LevelCreation.CreateLevel ("Jobs",new string[] {"Author","Chef","Police","Nurse","Barber"},new float[] {.9f, .5f, .4f, .45f, .9f}, 5);
				CreateBackGround("Jobs",new Vector3(0,-7,2),new Vector3(1.8f,1.8f,1));
				break;

			case "Sports":
				
				LevelCreation.CreateLevel ("Sports",new string[] {"Golf","Hockey","Skate","Soccer","Track"},new float[] {.18f, .7f, 2.4f, .6f, .7f}, 5);
				CreateBackGround("Sports",new Vector3(0,-7,2),new Vector3(1.8f,1.8f,1));
				break;

			case "Transportation":
				
				LevelCreation.CreateLevel ("Transportation",new string[] {"Ship","Car","Plane","Bus","Train"},new float[] {.12f, .8f, .12f, .12f, .6f}, 5);
				CreateBackGround("Transportation",new Vector3(0,-7,2),new Vector3(1.8f,1.8f,1));
				break;

			case "Bedroom":
				
				LevelCreation.CreateLevel ("Bedroom",new string[] {"Clock","Bed","Lamp","Mirror","Pillow"},new float[] {.6f, 1f, .5f, .3f, .5f}, 5);
				CreateBackGround("Bedroom",new Vector3(0,-7,2),new Vector3(1.8f,1.8f,1));
				break;
			
			case "Vegetables":
				
				LevelCreation.CreateLevel ("Vegetables",new string[] {"Bean","Onion","Carrot","Pepper","Radish"},new float[] {.6f, .8f, .9f, .8f, 1.4f}, 5);
				CreateBackGround("Vegetables",new Vector3(0,-7,2),new Vector3(1.8f,1.8f,1));
				break;


				
			}
		}

	}
}
