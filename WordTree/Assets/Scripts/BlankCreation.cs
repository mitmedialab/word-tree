using UnityEngine;
using System.Collections;

namespace WordTree{

	public class BlankCreation : MonoBehaviour {

		static float xScale;
		static float yScale;
		static float blankWidth = 2.5f;
		static int y;
		static int z;

		public static void CreateScrambledBlanks(string word, string[] sounds, string shape, string tag, string mode)
		{
			
			Vector3[] posn = new Vector3[word.Length];
			Vector3[] shuffledPosn = new Vector3[word.Length];
			Color[] shuffledColors = new Color[word.Length];
			
			CreateBlanks (word, sounds, shape, tag, mode);
			
			GameObject[] gos = GameObject.FindGameObjectsWithTag (tag);
			for (int i=0; i<gos.Length; i++)
				posn [i] = gos [i].transform.position;
			shuffledPosn = ShuffleArray (posn);
			
			for (int i=0; i<gos.Length; i++)
				gos [i].transform.position = shuffledPosn [i];

			GameObject[] blanks = GameObject.FindGameObjectsWithTag(tag);
			Color[] colors = new Color[] {Color.green,Color.yellow,Color.cyan,Color.blue,Color.magenta};
			shuffledColors = ShuffleArrayColor (colors);
			for (int i=0; i<blanks.Length; i++) {
				SpriteRenderer sprite = blanks[i].GetComponent<SpriteRenderer> ();
				sprite.color = shuffledColors[i];
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

		public static void CreateBlanks(string word, string[] sounds, string shape, string tag, string mode)
		{
			if (shape == "Rectangle") {
				xScale = .7f;
				yScale = 1.5f;
			}

			if (shape == "Circle") {
				xScale = .3f;
				yScale = .3f;
			}


			if (mode == "SpellingGame")
				y = -3;
			if (mode == "SoundGame")
				y = 0;


			if (tag == "MovableBlank")
				z = -2;
			if (tag == "TargetBlank")
				z = 0;


			Vector3[] position = new Vector3[word.Length];
			
			string[] letterArray = new string[word.Length];
			for (int i=0; i<word.Length; i++) {
				char letter = System.Char.ToUpper (word [i]);
				letterArray [i] = System.Char.ToString (letter);
			}
			
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

			for (int i=0; i<word.Length; i++) {
				ObjectProperties blank = ObjectProperties.CreateInstance (letterArray [i], tag, position [i], new Vector3 (xScale, yScale, 1), shape, sounds [i]);
				ObjectProperties.InstantiateObject (blank);
			}



		}

	}

}
