using UnityEngine;
using System.Collections;

namespace WordTree{

	public class BlankCreation : MonoBehaviour {

		static float xScale;
		static float yScale;
		static float blankWidth = 2f;
		static int y;
		static int z = 0;

		public static void CreateBlanks(string word, string shape)
		{
			if (shape == "Rectangle") {
				xScale = .4f;
				yScale = .5f;
				y = -3;
			}

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
			
			if (word.Length == 6) {
				position = new Vector3[6] {
					new Vector3 (-2.5f * blankWidth, y, z),
					new Vector3 (-1.5f * blankWidth, y, z),
					new Vector3 (-.5f * blankWidth, y, z),
					new Vector3 (.5f * blankWidth, y, z),
					new Vector3 (1.5f * blankWidth, y, z),
					new Vector3 (2.5f * blankWidth, y, z)
				};
				
				
			}
			
			ObjectProperties blank1 = ObjectProperties.CreateInstance (letterArray [0], "TargetBlank", position [0], new Vector3 (xScale, yScale, 1), shape, null);
			ObjectProperties.InstantiateObject (blank1);
			
			ObjectProperties blank2 = ObjectProperties.CreateInstance (letterArray [1], "TargetBlank", position [1], new Vector3 (xScale, yScale, 1), shape, null);
			ObjectProperties.InstantiateObject (blank2);
			
			ObjectProperties blank3 = ObjectProperties.CreateInstance (letterArray [2], "TargetBlank", position [2], new Vector3 (xScale, yScale, 1), shape, null);
			ObjectProperties.InstantiateObject (blank3);
			
			if (word.Length >= 4) {
				
				ObjectProperties blank4 = ObjectProperties.CreateInstance (letterArray [3], "TargetBlank", position [3], new Vector3 (xScale, yScale, 1), shape, null);
				ObjectProperties.InstantiateObject (blank4);
			}
			
			if (word.Length >= 5) {
				
				ObjectProperties blank5 = ObjectProperties.CreateInstance (letterArray [4], "TargetBlank", position [4], new Vector3 (xScale, yScale, 1), shape, null);
				ObjectProperties.InstantiateObject (blank5);
			}
			
			if (word.Length >= 6) {
				
				ObjectProperties blank6 = ObjectProperties.CreateInstance (letterArray [5], "TargetBlank", position [5], new Vector3 (xScale, yScale, 1), shape, null);
				ObjectProperties.InstantiateObject (blank6);
			}

			if (shape == "Rectangle") {
				GameObject[] blanks = GameObject.FindGameObjectsWithTag ("TargetBlank");
				foreach (GameObject go in blanks) {
					Color color = go.renderer.material.color;
					color.a = .1f;
					go.renderer.material.color = color;
				}
			}

		}

	}

}
