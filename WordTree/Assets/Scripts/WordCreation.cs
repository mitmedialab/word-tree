using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordCreation : MonoBehaviour {

		public static float letterScale = .3f;
		static float letterWidth = 2.4f;
		static float y;
		static int z;

		public static void CreateScrambledWord(string word, string[] soundArray)
		{

			Vector3[] posn = new Vector3[word.Length];
			int[,] order = new int[4, word.Length];
			
			CreateWord (word, soundArray, "MovableLetter","SpellingGame");

			if (word.Length == 3){
				order = new int[,] {{2,3,1}, {3,1,2}, {3,2,1}, {2,1,3}};
			}

			if (word.Length == 4){
				order = new int[,] {{2,1,4,3}, {3,4,1,2}, {4,1,3,2}, {1,3,4,2}};
			}

			if (word.Length == 5){
				order = new int[,] {{2,1,5,3,4}, {3,5,2,4,1}, {4,1,2,5,3}, {5,4,1,3,2}};
			}

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			for (int i=0; i<mov.Length; i++)
				posn [i] = mov[i].transform.position;

			int index = Random.Range (0,4);
			for (int i = 0; i<mov.Length; i++) {
				mov [i].transform.position = posn [order[index, i]-1];
			}


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
			Color[] colors = new Color[] {Color.cyan,Color.blue,Color.magenta,Color.grey,Color.yellow};
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
				y = -2;
			if (mode == "SpellingGame")
				y = 0;
			if (mode == "SoundGame")
				y = -3.5f;

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


			for (int i=0; i<word.Length; i++) {
				ObjectProperties letter = ObjectProperties.CreateInstance (letters [i], tag, position [i], new Vector3 (letterScale, letterScale, 1), "Letters/" + letters [i], "Phonemes/" + sounds [i]);
				ObjectProperties.InstantiateObject (letter);
			}


		

		}



	}
}
