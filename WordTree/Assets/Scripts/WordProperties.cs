using UnityEngine;
using System.Collections;

namespace WordTree
{

	public class WordProperties : ScriptableObject {

		string[] phonemes;
		float objScale;

		public string[] Phonemes()
		{
			return this.phonemes;
		}
		
		public float ObjScale()
		{
			return this.objScale;
		}

		void Init (string[] phonemes, float objScale)
		{
			this.phonemes = phonemes;
			this.objScale = objScale;
		}
		
		
		static WordProperties CreateInstance(string[] phonemes, float objScale)
		{
			WordProperties prop = ScriptableObject.CreateInstance<WordProperties> ();
			prop.Init (phonemes, objScale);
			return prop;
		}


		public static WordProperties GetWordProperties(string word)
		{
			switch (word) 
			{
			
			// Animals

			case "Cat":
				return CreateInstance(new string[] {"C","A","T"}, .5f);
				
			case "Dog":
				
				return CreateInstance(new string[] {"D","O","G"}, .6f);

			case "Hen":
				
				return CreateInstance(new string[] {"H","E","N"}, .6f);

			case "Pig":
				
				return CreateInstance(new string[] {"P","I","G"}, .5f);

			case "Rat":
				
				return CreateInstance(new string[] {"R","A","T"}, .6f);


			// Transportation

			case "Bus":
				
				return CreateInstance(new string[] {"B","U","S"}, .7f);
				
			case "Cab":
				
				return CreateInstance(new string[] {"C","A","B"}, .7f);
			
			case "Car":

				return CreateInstance(new string[] {"C","A","R"}, .6f);
				
			case "Jet":
				
				return CreateInstance(new string[] {"J","E","T"}, .7f);

			case "Van":
				
				return CreateInstance(new string[] {"V","A","N"}, .7f);
			
			// Bathroom
				
			case "Can":
				
				return CreateInstance(new string[] {"C","A","N"}, .5f);
				
			case "Gel":
				
				return CreateInstance(new string[] {"G","E","L"}, .5f);
				
			case "Lid":
				
				return CreateInstance(new string[] {"L","I","D"}, .5f);
				
			case "Mop":
				
				return CreateInstance(new string[] {"M","O","P"}, .6f);
				
			case "Tub":
				
				return CreateInstance(new string[] {"T","U","B"}, .6f);
			
			// Kitchen
				
			case "Cup":
				
				return CreateInstance(new string[] {"C","U","P"}, .6f);
				
			case "Jar":
				
				return CreateInstance(new string[] {"J","A","R"}, .5f);

			case "Jug":
				
				return CreateInstance(new string[] {"J","U","G"}, .5f);
				
			case "Oven":
				
				return CreateInstance(new string[] {"O","V","E","N"}, .5f);
				
			case "Pan":
				
				return CreateInstance(new string[] {"P","A","N"}, .7f);

			// Picnic
				
			case "Bag":
				
				return CreateInstance(new string[] {"B","A","G"}, .5f);
				
			case "Bun":
				
				return CreateInstance(new string[] {"B","U","N"}, .6f);
				
			case "Ham":
				
				return CreateInstance(new string[] {"H","A","M"}, .7f);
				
			case "Jam":
				
				return CreateInstance(new string[] {"J","A","M"}, .5f);
				
			case "Taco":
				
				return CreateInstance(new string[] {"T","A","C","O"}, .6f);
			
		    //Forest
				
			case "Bug":
				
				return CreateInstance(new string[] {"B","U","G"}, .7f);
				
			case "Fly":
				
				return CreateInstance(new string[] {"F","L","Y"}, .6f);
				
			case "Log":
				
				return CreateInstance(new string[] {"L","O","G"}, .7f);
				
			case "Mud":
				
				return CreateInstance(new string[] {"M","U","D"}, .8f);
				
			case "Web":
				
				return CreateInstance(new string[] {"W","E","B"}, .7f);

			//Bedroom
				
			case "Bed":
				
				return CreateInstance(new string[] {"B","E","D"}, 1f);
				
			case "Crib":
				
				return CreateInstance(new string[] {"C","R","I","B"}, .7f);
				
			case "Fan":
				
				return CreateInstance(new string[] {"F","A","N"}, .6f);
				
			case "Mat":
				
				return CreateInstance(new string[] {"M","A","T"}, .7f);
				
			case "Rug":

				return CreateInstance(new string[] {"R","U","G"}, .7f);

			// School
				
			case "Desk":
				
				return CreateInstance(new string[] {"C","U","P"}, .6f);
				
			case "Mug":
				
				return CreateInstance(new string[] {"J","A","R"}, .5f);
				
			case "Pad":
				
				return CreateInstance(new string[] {"J","U","G"}, .5f);
				
			case "Pen":
				
				return CreateInstance(new string[] {"O","V","E","N"}, .7f);
				
			case "Pin":
				
				return CreateInstance(new string[] {"P","A","N"}, .5f);

			// Playground
				
			case "Box":
				
				return CreateInstance(new string[] {"B","O","X"}, .7f);
				
			case "Net":
				
				return CreateInstance(new string[] {"N","E","T"}, .6f);
				
			case "Sun":
				
				return CreateInstance(new string[] {"S","U","N"}, .5f);
				
			case "Top":
				
				return CreateInstance(new string[] {"T","O","P"}, .5f);
				
			case "Yoyo":
				
				return CreateInstance(new string[] {"Y","O","Y","O"}, .5f);

			// Clothing
				
			case "Cap":
				
				return CreateInstance(new string[] {"C","A","P"}, .5f);
				
			case "Hat":
				
				return CreateInstance(new string[] {"H","A","T"}, .5f);
				
			case "Tux":
				
				return CreateInstance(new string[] {"T","U","X"}, .6f);
				
			case "Vest":
				
				return CreateInstance(new string[] {"V","E","S","T"}, .4f);
				
			case "Wig":
				
				return CreateInstance(new string[] {"W","I","G"}, .5f);

			// Garden
				
			case "Ant":
				
				return CreateInstance(new string[] {"A","N","T"}, .6f);
				
			case "Kiwi":
				
				return CreateInstance(new string[] {"K","I","W","I"}, .6f);
				
			case "Nut":
				
				return CreateInstance(new string[] {"N","U","T"}, .5f);
				
			case "Plum":
				
				return CreateInstance(new string[] {"P","L","U","M"}, .5f);
				
			case "Pot":
				
				return CreateInstance(new string[] {"P","O","T"}, .6f);
			
			// Camping
				
			case "Bat":
				
				return CreateInstance(new string[] {"B","A","T"}, .8f);
				
			case "Fox":
				
				return CreateInstance(new string[] {"F","O","X"}, .7f);
				
			case "Map":
				
				return CreateInstance(new string[] {"M","A","P"}, .6f);
				
			case "Star":
				
				return CreateInstance(new string[] {"S","T","A","R"}, .7f);
				
			case "Tent":
				
				return CreateInstance(new string[] {"T","E","N","T"}, .9f);

			default:

				return null;

			}
		}

	}
}
