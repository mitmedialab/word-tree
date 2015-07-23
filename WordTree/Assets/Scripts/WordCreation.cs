using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordCreation : MonoBehaviour {

		public static float xScale;
		public static float yScale;

		public static void CreateMovableWord(string word, string[] soundArray)
		{
			int y = 0;
			int z = -1;
			Vector3[] posn = new Vector3[word.Length];
			Vector3[] shuffledPosn = new Vector3[word.Length];
			 

			string[] letterArray = new string[word.Length];
			for (int i=0; i<word.Length; i++)
				letterArray [i] = System.Char.ToString (word [i]);
			
			CreateWord (letterArray, soundArray, "MovableLetter");

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			for (int i=0; i<mov.Length; i++)
				posn [i] = mov [i].transform.position;
			shuffledPosn = ShuffleArray (posn);

			for (int i=0; i<mov.Length; i++)
				mov [i].transform.position = shuffledPosn [i];

			foreach (GameObject go in mov)
				go.transform.position = new Vector3 (go.transform.position.x, y, z);

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
			string[] letterArray = new string[word.Length];
			for (int i=0; i<word.Length; i++)
				letterArray [i] = System.Char.ToString(word [i]);

			CreateWord (letterArray, soundArray, "MovableLetter");
			CreateWord (letterArray, soundArray, "TargetLetter");

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

		public static void CreateWord(string[] word, string[] sounds, string tag)
		{
			xScale = .3f;
			yScale = .3f;
			int y = -2;
			int z = 0;
			int numLetters = word.Length;
			Vector3[] Position = new Vector3[numLetters];

			if (tag == "MovableLetter")
				z = -2;

			if (numLetters == 3) {
				Position = new Vector3[3]{
					new Vector3 (-2, y, z),
					new Vector3 (0, y, z),
					new Vector3 (2, y, z)
				};
			}

			if (numLetters == 4) {
				Position = new Vector3[4] {
					new Vector3 (-3, y, z),
					new Vector3 (-1, y, z),
					new Vector3 (1, y, z),
					new Vector3 (3, y, z),
				};
			}

			if (numLetters == 5) {
				Position = new Vector3[5] {
					new Vector3 (-4, y, z),
					new Vector3 (-2, y, z),
					new Vector3 (0, y, z),
					new Vector3 (2, y, z),
					new Vector3 (4, y, z)
				};
			}

			if (numLetters == 6) {
				Position = new Vector3[6] {
					new Vector3 (-5, y, z),
					new Vector3 (-3, y, z),
					new Vector3 (-1, y, z),
					new Vector3 (1, y, z),
					new Vector3 (3, y, z),
					new Vector3 (5, y, z)
				};
			}
		


			ObjectProperties letter1 = ObjectProperties.CreateInstance (word[0], tag, Position[0], new Vector3 (xScale, yScale, 1), "Letters/"+word[0], sounds[0]);
			GameDirector.InstantiateObject (letter1);
		
			ObjectProperties letter2 = ObjectProperties.CreateInstance (word[1], tag, Position[1], new Vector3 (xScale, yScale, 1), "Letters/"+word[1], sounds[1]);
			GameDirector.InstantiateObject (letter2);

			ObjectProperties letter3 = ObjectProperties.CreateInstance (word[2], tag, Position[2], new Vector3 (xScale, yScale, 1), "Letters/"+word[2], sounds[2]);
			GameDirector.InstantiateObject (letter3);

			if (numLetters >= 4) {

				ObjectProperties letter4 = ObjectProperties.CreateInstance (word[3], tag, Position[3], new Vector3 (xScale, yScale, 1), "Letters/"+word[3], sounds[3]);
				GameDirector.InstantiateObject (letter4);
			}

			if (numLetters >= 5) {

				ObjectProperties letter5 = ObjectProperties.CreateInstance (word[4], tag, Position[4], new Vector3 (xScale, yScale, 1), "Letters/"+word[4], sounds[4]);
				GameDirector.InstantiateObject (letter5);
			}

			if (numLetters >= 6) {
				
				ObjectProperties letter6 = ObjectProperties.CreateInstance (word[5], tag, Position[5], new Vector3 (xScale, yScale, 1), "Letters/"+word[5], sounds[5]);
				GameDirector.InstantiateObject (letter6);
			}

		

		}



	}
}
