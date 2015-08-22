using UnityEngine;
using System.Collections;

//Handles instantiating blanks programmatically
//Two types of blanks: 
// 1. Rectangle: for Spelling Game, drag letters to target rectangle blanks
// 2. Circle: for Sound Game, drag movable circle blanks (sound bubble) to correct letter

namespace WordTree{

	public class BlankCreation : MonoBehaviour {

		static float xScale; // horizontal scale size of blank
		static float yScale; // vertical scale size of blank
		static float blankWidth = 2.5f; //distance between each blank, i.e. how spread out the blanks are
		static int y; // y position of blank
		static int z; // z position of blank

		//Create blanks that are scrambled randomly
		public static void CreateScrambledBlanks(string word, string[] sounds, string shape, string tag, string mode)
		{

			Color[] shuffledColors = new Color[word.Length]; //contains possible colors to be assigned to blanks
			Vector3[] posn = new Vector3[word.Length]; //contains the position for each blank
			int[,] order = new int[4, word.Length]; //contains pre-programmed shuffled orders, i.e. ways to rearrange the order of blanks

			//Instantiate normal blanks
			CreateBlanks (word, sounds, shape, tag, mode);

			//Set 4 different shuffled orders for each possible word length
			if (word.Length == 3){
				order = new int[,] {{2,3,1}, {3,1,2}, {3,2,1}, {2,1,3}};
			}
			if (word.Length == 4){
				order = new int[,] {{2,1,4,3}, {3,4,1,2}, {4,1,3,2}, {1,3,4,2}};
			}
			if (word.Length == 5){
				order = new int[,] {{2,1,5,3,4}, {3,5,2,4,1}, {4,1,2,5,3}, {5,4,1,3,2}};
			}

			//Find all blanks with specified tag
			GameObject[] blanks = GameObject.FindGameObjectsWithTag(tag);

			//Set possible colors
			Color[] colors = new Color[] {Color.green,Color.yellow,Color.cyan,Color.blue,Color.magenta};

			//Shuffle colors and assign to blanks
			shuffledColors = ShuffleArrayColor (colors);
			for (int i=0; i<blanks.Length; i++) {
				SpriteRenderer sprite = blanks[i].GetComponent<SpriteRenderer> ();
				sprite.color = shuffledColors[i];
			}

			//Get position of each blank
			for (int i=0; i<blanks.Length; i++)
				posn [i] = blanks[i].transform.position;

			//int index: for determining which shuffled order to use (4 to choose from currently)
			int index = Random.Range (0,4);
			//Reassign positions of each blank, according to shuffled order chosen
			for (int i = 0; i<blanks.Length; i++) {
				blanks [i].transform.position = posn [order[index, i]-1];
			}
			
		}

		//For shuffling a Vector3[] array
		static Vector3[] ShuffleArray(Vector3[] array)
		{
			for (int i = array.Length; i > 0; i--)
			{
				int j = Random.Range (0,i);
				Vector3 temp = array[j];
				array[j] = array[i - 1];
				array[i - 1]  = temp;
			}
			return array;
		}

		//For shuffling a Color[] array
		static Color[] ShuffleArrayColor(Color[] array)
		{
			for (int i = array.Length; i > 0; i--)
			{
				int j = Random.Range (0,i);
				Color temp = array[j];
				array[j] = array[i - 1];
				array[i - 1]  = temp;
			}
			return array;
		}

		//Instantiate blanks. Takes in the desired word, phonemes, blank shape (Rectangle or Circle), tag (MovableBlank or TargetBlank),
		// and game mode (SpellingGame or SoundGame).
		public static void CreateBlanks(string word, string[] sounds, string shape, string tag, string mode)
		{
			//Set scale size
			if (shape == "Rectangle") {
				xScale = .7f;
				yScale = 1.5f;
			}
			if (shape == "Circle") {
				xScale = .3f;
				yScale = .3f;
			}

			//Set y position
			if (mode == "SpellingGame")
				y = -3;
			if (mode == "SoundGame")
				y = 0;

			//Set z position
			if (tag == "MovableBlank")
				z = -2; //movable objects set at z = -2
			if (tag == "TargetBlank")
				z = 0; //static objects set at z = 0


			//Create array of uppercase letters
			string[] letterArray = new string[word.Length];
			for (int i=0; i<word.Length; i++) {
				char letter = System.Char.ToUpper (word [i]);
				letterArray [i] = System.Char.ToString (letter);
			}

			//Set x positions of each letter, for each possible word length
			//Word is centered, letters evenly spaced out according to blankWidth
			Vector3[] position = new Vector3[word.Length];
			if (word.Length == 3) {
				position = new Vector3[3]{
					new Vector3 (-1f * blankWidth, y, z),
					new Vector3 (0, y, z),
					new Vector3 (1f * blankWidth, y, z)
				};
			}
			if (word.Length == 4) {
				position = new Vector3[4] {
					new Vector3 (-1.5f * blankWidth, y, z),
					new Vector3 (-.5f * blankWidth, y, z),
					new Vector3 (.5f * blankWidth, y, z),
					new Vector3 (1.5f * blankWidth, y, z),
				};
			}
			if (word.Length == 5) {
				position = new Vector3[5] {
					new Vector3 (-2f * blankWidth, y, z),
					new Vector3 (-1f * blankWidth, y, z),
					new Vector3 (0, y, z),
					new Vector3 (1f * blankWidth, y, z),
					new Vector3 (2f * blankWidth, y, z)
				};
			}

			//Assign properties according to input given, then instantiate each blank
			for (int i=0; i<word.Length; i++) {
				ObjectProperties blank = ObjectProperties.CreateInstance (letterArray [i], tag, position [i], new Vector3 (xScale, yScale, 1), shape, "Phonemes/" + sounds [i]);
				ObjectProperties.InstantiateObject (blank);
			}



		}

	}

}
