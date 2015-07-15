using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class LevelProperties : MonoBehaviour {

		public static void CreateLevel(string level, string[] objects, float[,] scale, int numObjects)
		{
			int x = 0;
			int y = 0;
			Vector3[] Position = new Vector3[numObjects];

			if (numObjects == 4) {
				x = 4;
				y = 2;
				Position = new Vector3[4] {
					new Vector3 (-x, y, 0),
					new Vector3 (x, y, 0),
					new Vector3 (x, -y, 0),
					new Vector3 (-x, -y, 0),
				};
			}
			
			ObjectProperties obj1= ObjectProperties.CreateInstance (objects[0], "WordObject", Position[0], new Vector3 (scale[0,0], scale[0,1], 1), level+"/"+objects[0], objects[0]);
			GameDirector.InstantiateObject (obj1);
			
			ObjectProperties obj2 = ObjectProperties.CreateInstance (objects[1], "WordObject", Position[1], new Vector3 (scale[1,0], scale[1,1], 1), level+"/"+objects[1], objects[1]);
			GameDirector.InstantiateObject (obj2);
			
			ObjectProperties obj3 = ObjectProperties.CreateInstance (objects[2], "WordObject", Position[2], new Vector3 (scale[2,0], scale[2,1], 1), level+"/"+objects[2], objects[2]);
			GameDirector.InstantiateObject (obj3);
			
			ObjectProperties obj4 = ObjectProperties.CreateInstance (objects [3], "WordObject", Position[3], new Vector3 (scale[3,0], scale[3,1], 1), level+"/"+objects[3], objects [3]);
			GameDirector.InstantiateObject (obj4);
		}

	}
}
