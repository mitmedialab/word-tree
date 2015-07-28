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

			case "Fruits":
			
				return CreateInstance (new string[] {"Apple","Banana","Grape","Cherry","Orange"},new Vector3(0,3,2),2.8f);

			default:

				return null;


			}
	
		}

		/*
		void CreateLevelScene(string level)
		{
			switch(level)
			{
				
			case "Fruits":

				LevelCreation.CreateLevel ("Fruits",new string[] {"Apple","Banana","Grape","Cherry","Orange"});
				CreateBackGround("Fruits",new Vector3(0,3,2),2.8f;
				break;

			case "Animals":

				LevelCreation.CreateLevel ("Animals",new string[] {"Bird","Zebra","Rabbit","Fish","Horse"});
				CreateBackGround("Animals",new Vector3(0,2,2),1.5f);
				break;

			case "SchoolSupplies":
				
				LevelCreation.CreateLevel ("SchoolSupplies",new string[] {"Pencil","Glue","Crayon","Tape","Book"});
				CreateBackGround("SchoolSupplies",new Vector3(0,3,2),4.3f);
				break;

			case "Clothes":
				
				LevelCreation.CreateLevel ("Clothes",new string[] {"Boot","Jacket","Glove","Pants","Shirt"});
				CreateBackGround("Clothes",new Vector3(0,-6.5f,2),1.8f);
				break;

			case "Jobs":
				
				LevelCreation.CreateLevel ("Jobs",new string[] {"Chef","Author","Police","Nurse","Doctor"});
				CreateBackGround("Jobs",new Vector3(-1,1,2),1.8f);
				break;

			case "Sports":
				
				LevelCreation.CreateLevel ("Sports",new string[] {"Golf","Hockey","Skate","Soccer","Track"});
				CreateBackGround("Sports",new Vector3(0,0,2),2.5f);
				break;

			case "Transportation":
				
				LevelCreation.CreateLevel ("Transportation",new string[] {"Bus","Plane","Ship","Car","Train"});
				CreateBackGround("Transportation",new Vector3(-3f,6.5f,2),3f);
				break;

			case "Bedroom":
				
				LevelCreation.CreateLevel ("Bedroom",new string[] {"Pillow","Mirror","Lamp","Bed","Clock"});
				CreateBackGround("Bedroom",new Vector3(0,2.5f,2),3f);
				break;
			
			case "Vegetables":
				
				LevelCreation.CreateLevel ("Vegetables",new string[] {"Bean","Onion","Carrot","Pepper","Radish"});
				CreateBackGround("Vegetables",new Vector3(0,6,2),3.3f);
				break;


				
			}
		}
		*/


	}
}
