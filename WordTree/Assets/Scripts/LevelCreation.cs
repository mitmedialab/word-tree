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

			for (int i=0; i<objects.Length; i++)
				scale[i] = WordProperties.GetWordProperties(objects[i]).ObjScale();

			
			ObjectProperties obj1= ObjectProperties.CreateInstance (objects[0], "WordObject", position[0], new Vector3 (scale[0], scale[0], 1), level+"/"+objects[0], "Words/"+objects[0]);
			ObjectProperties.InstantiateObject (obj1);
			
			ObjectProperties obj2 = ObjectProperties.CreateInstance (objects[1], "WordObject", position[1], new Vector3 (scale[1], scale[1], 1), level+"/"+objects[1], "Words/"+objects[1]);
			ObjectProperties.InstantiateObject (obj2);
			
			ObjectProperties obj3 = ObjectProperties.CreateInstance (objects[2], "WordObject", position[2], new Vector3 (scale[2], scale[2], 1), level+"/"+objects[2], "Words/"+objects[2]);
			ObjectProperties.InstantiateObject (obj3);
			
			ObjectProperties obj4 = ObjectProperties.CreateInstance (objects [3], "WordObject", position[3], new Vector3 (scale[3], scale[3], 1), level+"/"+objects[3], "Words/"+objects [3]);
			ObjectProperties.InstantiateObject (obj4);

			ObjectProperties obj5 = ObjectProperties.CreateInstance (objects [4], "WordObject", position [4], new Vector3 (scale [4], scale [4], 1), level + "/" + objects [4], "Words/"+objects [4]);
			ObjectProperties.InstantiateObject (obj5);

		}

	}
}
