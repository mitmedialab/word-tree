using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class LevelCreation : MonoBehaviour {

		public static void CreateLevel(string level, string[] objects, float[] scale, int numObjects)
		{
			Vector3[] Position = new Vector3[numObjects];

			if (numObjects == 4) {
				float x = 5;
				float y = 2.5f;
				Position = new Vector3[4] {
					new Vector3 (-x, y, 0),
					new Vector3 (x, y, 0),
					new Vector3 (x, -y, 0),
					new Vector3 (-x, -y, 0),
				};
			}

			if (numObjects == 5) {
				float x1 = 8;
				float x2 = 3;
				float y1 = 2.5f;
				Position = new Vector3[5] {
					new Vector3 (-x1, 0, 0),
					new Vector3 (0, y1, 0),
					new Vector3 (x1, 0, 0),
					new Vector3 (x2, -y1, 0),
					new Vector3 (-x2, -y1, 0)
				};
			}
			
			ObjectProperties obj1= ObjectProperties.CreateInstance (objects[0], "WordObject", Position[0], new Vector3 (scale[0], scale[0], 1), level+"/"+objects[0], "Words/"+objects[0]);
			GameDirector.InstantiateObject (obj1);
			
			ObjectProperties obj2 = ObjectProperties.CreateInstance (objects[1], "WordObject", Position[1], new Vector3 (scale[1], scale[1], 1), level+"/"+objects[1], "Words/"+objects[1]);
			GameDirector.InstantiateObject (obj2);
			
			ObjectProperties obj3 = ObjectProperties.CreateInstance (objects[2], "WordObject", Position[2], new Vector3 (scale[2], scale[2], 1), level+"/"+objects[2], "Words/"+objects[2]);
			GameDirector.InstantiateObject (obj3);
			
			ObjectProperties obj4 = ObjectProperties.CreateInstance (objects [3], "WordObject", Position[3], new Vector3 (scale[3], scale[3], 1), level+"/"+objects[3], "Words/"+objects [3]);
			GameDirector.InstantiateObject (obj4);

			if (numObjects >= 5) {
				ObjectProperties obj5 = ObjectProperties.CreateInstance (objects [4], "WordObject", Position [4], new Vector3 (scale [4], scale [4], 1), level + "/" + objects [4], "Words/"+objects [4]);
				GameDirector.InstantiateObject (obj5);
			}
		}

	}
}
