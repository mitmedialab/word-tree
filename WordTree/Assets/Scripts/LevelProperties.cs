using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class LevelProperties : ScriptableObject {

		string[] words;
		Vector3 backgroundPosn;
		float backgroundScale;

		public string[] Words()
		{
			return this.words;
		}

		public Vector3 BackgroundPosn()
		{
			return this.backgroundPosn;
		}

		public float BackgroundScale()
		{
			return this.backgroundScale;
		}

		void Init (string[] words, Vector3 backgroundPosn, float backgroundScale)
		{
			this.words = words;
			this.backgroundPosn = backgroundPosn;
			this.backgroundScale = backgroundScale;
		}
		
		
		static LevelProperties CreateInstance(string[] words, Vector3 backgroundPosn, float backgroundScale)
		{
			LevelProperties prop = ScriptableObject.CreateInstance<LevelProperties> ();
			prop.Init (words, backgroundPosn, backgroundScale);
			return prop;
		}

		public static LevelProperties GetLevelProperties(string level)
		{
			switch (level) 
			{

			case "Animals":
			
				return CreateInstance (new string[] {"Cat","Dog","Rat","Pig","Hen"},new Vector3(0,0,2),3f);

			case "Transportation":
				
				return CreateInstance (new string[] {"Car","Bus","Cab","Van","Jet"},new Vector3(0,0,2),3f);

			case "Bathroom":
				
				return CreateInstance (new string[] {"Tub","Lid","Gel","Can","Mop"},new Vector3(0,0,2),3f);

			case "Kitchen":
				
				return CreateInstance (new string[] {"Cup","Jar","Jug","Pan","Oven"},new Vector3(0,0,2),3f);

			case "Picnic":
				
				return CreateInstance (new string[] {"Bun","Ham","Jam","Bag","Taco"},new Vector3(0,0,2),3f);

			case "Forest":
				
				return CreateInstance (new string[] {"Log","Mud","Web","Bug","Fly"},new Vector3(0,0,2),3f);

			case "Bedroom":
				
				return CreateInstance (new string[] {"Bed","Rug","Fan","Mat","Crib"},new Vector3(0,0,2),3f);

			case "School":
				
				return CreateInstance (new string[] {"Pen","Pin","Mug","Pad","Desk"},new Vector3(0,0,2),3f);

			case "Playground":
				
				return CreateInstance (new string[] {"Sun","Net","Top","Box","Yoyo"},new Vector3(0,0,2),3f);

			case "Clothing":
				
				return CreateInstance (new string[] {"Hat","Cap","Wig","Tux","Vest"},new Vector3(0,0,2),3f);

			case "Garden":
				
				return CreateInstance (new string[] {"Pot","Nut","Ant","Kiwi","Plum"},new Vector3(0,0,2),3f);

			case "Camping":
				
				return CreateInstance (new string[] {"Bat","Map","Fox","Tent","Star"},new Vector3(0,0,2),3f);

			default:

				return null;


			}
	
		}


	}
}
