using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordCreation : MonoBehaviour {

		public static float letterScale = .3f;
		static float letterWidth = 2f;
		static int y;
		static int z;

		public static void CreateScrambledWord(string word, string[] soundArray)
		{

			Vector3[] posn = new Vector3[word.Length];
			Vector3[] shuffledPosn = new Vector3[word.Length];
			
			CreateWord (word, soundArray, "MovableLetter","Game");

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			for (int i=0; i<mov.Length; i++)
				posn [i] = mov [i].transform.position;
			shuffledPosn = ShuffleArray (posn);

			for (int i=0; i<mov.Length; i++)
				mov [i].transform.position = shuffledPosn [i];


		}

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

		public static void CreateMovableAndTargetWords(string word, string[] soundArray)
		{

			CreateWord (word, soundArray, "MovableLetter", "Learn");
			CreateWord (word, soundArray, "TargetLetter", "Learn");

			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetLetter");
			foreach (GameObject go in tar) {
				SpriteRenderer sprite = go.GetComponent<SpriteRenderer> ();
				sprite.color = Color.black;
				Color color = go.renderer.material.color;
				color.a = .5f;
				go.renderer.material.color = color;
			}

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			Color[] colors = new Color[] {Color.cyan,Color.green,Color.blue,Color.grey,Color.magenta,Color.yellow};
			for (int i=0; i<mov.Length; i++) {
				SpriteRenderer sprite = mov[i].GetComponent<SpriteRenderer> ();
				sprite.color = colors[i];
			}
				

		}

		public static void CreateWord(string word, string[] sounds, string tag, string mode)
		{

			Vector3[] position = new Vector3[word.Length];
			string[] letters = new string[word.Length];

			for (int i=0; i<word.Length; i++) {
				char letter = System.Char.ToUpper (word [i]);
				letters[i] = System.Char.ToString (letter);
			}


			if (mode == "Learn")
				y = -1;
			if (mode == "Game")
				y = 0;

			if (tag == "MovableLetter")
				z = -2;
			if (tag == "TargetLetter")
				z = 0;

			if (word.Length == 3) {
				position = new Vector3[3]{
					new Vector3 (-1f*letterWidth, y, z),
					new Vector3 (0, y, z),
					new Vector3 (1f*letterWidth, y, z)
				};
			}

			if (word.Length == 4) {
				position = new Vector3[4] {
					new Vector3 (-1.5f*letterWidth, y, z),
					new Vector3 (-.5f*letterWidth, y, z),
					new Vector3 (.5f*letterWidth, y, z),
					new Vector3 (1.5f*letterWidth, y, z),
				};
			}

			if (word.Length == 5) {
				position = new Vector3[5] {
					new Vector3 (-2f*letterWidth, y, z),
					new Vector3 (-1f*letterWidth, y, z),
					new Vector3 (0, y, z),
					new Vector3 (1f*letterWidth, y, z),
					new Vector3 (2f*letterWidth, y, z)
				};
			}

			if (word.Length == 6) {
				position = new Vector3[6] {
					new Vector3 (-2.5f*letterWidth, y, z),
					new Vector3 (-1.5f*letterWidth, y, z),
					new Vector3 (-.5f*letterWidth, y, z),
					new Vector3 (.5f*letterWidth, y, z),
					new Vector3 (1.5f*letterWidth, y, z),
					new Vector3 (2.5f*letterWidth, y, z)
				};
			}
		


			ObjectProperties letter1 = ObjectProperties.CreateInstance (letters[0], tag, position[0], new Vector3 (letterScale, letterScale, 1), "Letters/"+letters[0], sounds[0]);
			ObjectProperties.InstantiateObject (letter1);
		
			ObjectProperties letter2 = ObjectProperties.CreateInstance (letters[1], tag, position[1], new Vector3 (letterScale, letterScale, 1), "Letters/"+letters[1], sounds[1]);
			ObjectProperties.InstantiateObject (letter2);

			ObjectProperties letter3 = ObjectProperties.CreateInstance (letters[2], tag, position[2], new Vector3 (letterScale, letterScale, 1), "Letters/"+letters[2], sounds[2]);
			ObjectProperties.InstantiateObject (letter3);

			if (word.Length >= 4) {

				ObjectProperties letter4 = ObjectProperties.CreateInstance (letters[3], tag, position[3], new Vector3 (letterScale, letterScale, 1), "Letters/"+letters[3], sounds[3]);
				ObjectProperties.InstantiateObject (letter4);
			}

			if (word.Length >= 5) {

				ObjectProperties letter5 = ObjectProperties.CreateInstance (letters[4], tag, position[4], new Vector3 (letterScale, letterScale, 1), "Letters/"+letters[4], sounds[4]);
				ObjectProperties.InstantiateObject (letter5);
			}

			if (word.Length >= 6) {
				
				ObjectProperties letter6 = ObjectProperties.CreateInstance (letters[5], tag, position[5], new Vector3 (letterScale, letterScale, 1), "Letters/"+letters[5], sounds[5]);
				ObjectProperties.InstantiateObject (letter6);
			}

		

		}



	}
}
