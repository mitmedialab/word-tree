using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class LevelCreation : MonoBehaviour {

		public static void CreateWordObjects(string level, string[] objects)
		{
			Vector3[] position = new Vector3[objects.Length];
			float[] scale = new float[objects.Length];

			if (objects.Length == 5) {
				float x1 = 8;
				float x2 = 3;
				float y1 = 2.5f;

				position = new Vector3[5] {
					new Vector3 (-x1, 0, 0),
					new Vector3 (0, y1, 0),
					new Vector3 (x1, 0, 0),
					new Vector3 (x2, -y1, 0),
					new Vector3 (-x2, -y1, 0)
				};
			}

			for (int i=0; i<objects.Length; i++) {
				scale[i] = WordProperties.GetWordProperties(objects[i]).ObjScale();

				ObjectProperties obj = ObjectProperties.CreateInstance (objects [i], "WordObject", position [i], new Vector3 (scale [i], scale [i], 1), level + "/" + objects [i], objects [i]);
				ObjectProperties.InstantiateObject (obj);
			}


		}

	}
}
