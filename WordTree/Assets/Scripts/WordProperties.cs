using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class WordProperties : MonoBehaviour {

		public static void CreateWord(string[] word, string[] sounds, string tag, int numLetters)
		{
			float xScale = .4f;
			float yScale = .4f;
			int y = 0;
			int z = 0;
			string color = "color";
			Vector3[] Position = new Vector3[numLetters];

			if (tag == "TargetLetter"){
				z = 0;
				color = "-Black";
			}

			if (tag == "MovableLetter") {
				z = -1;
				color = "-Blue";
			}

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
		


			ObjectProperties letter1 = ObjectProperties.CreateInstance (word[0], tag, Position[0], new Vector3 (xScale, yScale, 1), "Letters/"+word[0]+color, sounds[0]);
			GameDirector.InstantiateObject (letter1);
		
			ObjectProperties letter2 = ObjectProperties.CreateInstance (word[1], tag, Position[1], new Vector3 (xScale, yScale, 1), "Letters/"+word[1]+color, sounds[1]);
			GameDirector.InstantiateObject (letter2);

			ObjectProperties letter3 = ObjectProperties.CreateInstance (word[2], tag, Position[2], new Vector3 (xScale, yScale, 1), "Letters/"+word[2]+color, sounds[2]);
			GameDirector.InstantiateObject (letter3);

			ObjectProperties letter4 = ObjectProperties.CreateInstance (word[3], tag, Position[3], new Vector3 (xScale, yScale, 1), "Letters/"+word[3]+color, sounds[3]);
			GameDirector.InstantiateObject (letter4);

			ObjectProperties letter5 = ObjectProperties.CreateInstance (word[4], tag, Position[4], new Vector3 (xScale, yScale, 1), "Letters/"+word[4]+color, sounds[4]);
			GameDirector.InstantiateObject (letter5);



		}
		
	}
}
