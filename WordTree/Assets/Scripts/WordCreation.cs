using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordCreation : MonoBehaviour {

		public static void CreateWord(string[] word, string[] sounds, string tag, int numLetters)
		{
			float xScale = .3f;
			float yScale = .3f;
			int y = -2;
			int z = 0;
			Vector3[] Position = new Vector3[numLetters];

			if (tag == "MovableLetter")
				z = -1;

			if (numLetters == 3) {
				Position = new Vector3[3] {
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

			if (tag == "TargetLetter") {
				GameObject[] gos = GameObject.FindGameObjectsWithTag ("TargetLetter");
				foreach (GameObject go in gos) {
					SpriteRenderer sprite = go.GetComponent<SpriteRenderer> ();
					sprite.color = Color.black;
				}
			}
		

		}



	}
}
