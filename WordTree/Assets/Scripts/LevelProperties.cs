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
				
				return CreateInstance (new string[] {"Bus","Jet","Cab","Van","Car"},new Vector3(0,0,2),3f);

			case "Bathroom":
				
				return CreateInstance (new string[] {"Lid","Tub","Gel","Can","Mop"},new Vector3(0,0,2),3f);

			case "Kitchen":
				
				return CreateInstance (new string[] {"Cup","Oven","Pan","Jug","Jar"},new Vector3(0,0,2),3f);

			case "Picnic":
				
				return CreateInstance (new string[] {"Bun","Ham","Jam","Bag","Taco"},new Vector3(0,0,2),3f);

			case "Forest":
				
				return CreateInstance (new string[] {"Log","Mud","Web","Bug","Fly"},new Vector3(0,0,2),3f);

			case "Bedroom":
				
				return CreateInstance (new string[] {"Rug","Bed","Crib","Mat","Fan"},new Vector3(0,0,2),3f);

			case "School":
				
				return CreateInstance (new string[] {"Pen","Mug","Pin","Pad","Desk"},new Vector3(0,0,2),3f);

			case "Playground":
				
				return CreateInstance (new string[] {"Net","Sun","Top","Box","Yoyo"},new Vector3(0,0,2),3f);

			case "Clothing":
				
				return CreateInstance (new string[] {"Cap","Wig","Hat","Tux","Vest"},new Vector3(0,0,2),3f);

			case "Garden":
				
				return CreateInstance (new string[] {"Pot","Nut","Ant","Kiwi","Plum"},new Vector3(0,0,2),3f);

			case "Camping":
				
				return CreateInstance (new string[] {"Bat","Star","Tent","Fox","Map"},new Vector3(0,0,2),3f);

			default:

				return null;


			}
	
		}


	}
}
