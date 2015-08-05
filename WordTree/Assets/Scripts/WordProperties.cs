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
				return CreateInstance(new string[] {"C","A","T"}, 1f);
				
			case "Dog":
				
				return CreateInstance(new string[] {"D","O","G"}, 1f);

			case "Hen":
				
				return CreateInstance(new string[] {"H","E","N"}, 1f);

			case "Pig":
				
				return CreateInstance(new string[] {"P","I","G"}, 1f);

			case "Rat":
				
				return CreateInstance(new string[] {"R","A","T"}, 1f);


			// Transportation

			case "Bus":
				
				return CreateInstance(new string[] {"B","U","S"}, 1f);
				
			case "Cab":
				
				return CreateInstance(new string[] {"C","A","B"}, 1f);
			
			case "Car":

				return CreateInstance(new string[] {"C","A","R"}, 1f);
				
			case "Jet":
				
				return CreateInstance(new string[] {"J","E","T"}, 1f);

			case "Van":
				
				return CreateInstance(new string[] {"V","A","N"}, 1f);
			
			// Bathroom
				
			case "Can":
				
				return CreateInstance(new string[] {"C","A","N"}, 1f);
				
			case "Gel":
				
				return CreateInstance(new string[] {"G","E","L"}, 1f);
				
			case "Lid":
				
				return CreateInstance(new string[] {"L","I","D"}, 1f);
				
			case "Mop":
				
				return CreateInstance(new string[] {"M","O","P"}, 1f);
				
			case "Tub":
				
				return CreateInstance(new string[] {"T","U","B"}, 1f);
			
			// Kitchen
				
			case "Cup":
				
				return CreateInstance(new string[] {"C","U","P"}, 1f);
				
			case "Jar":
				
				return CreateInstance(new string[] {"J","A","R"}, 1f);

			case "Jug":
				
				return CreateInstance(new string[] {"J","U","G"}, 1f);
				
			case "Oven":
				
				return CreateInstance(new string[] {"O","V","E","N"}, 1f);
				
			case "Pan":
				
				return CreateInstance(new string[] {"P","A","N"}, 1f);

			// Picnic
				
			case "Bag":
				
				return CreateInstance(new string[] {"B","A","G"}, 1f);
				
			case "Bun":
				
				return CreateInstance(new string[] {"B","U","N"}, 1f);
				
			case "Ham":
				
				return CreateInstance(new string[] {"H","A","M"}, 1f);
				
			case "Jam":
				
				return CreateInstance(new string[] {"J","A","M"}, 1f);
				
			case "Taco":
				
				return CreateInstance(new string[] {"T","A","C","O"}, 1f);
			
		    //Forest
				
			case "Bug":
				
				return CreateInstance(new string[] {"B","U","G"}, 1f);
				
			case "Fly":
				
				return CreateInstance(new string[] {"F","L","Y"}, 1f);
				
			case "Log":
				
				return CreateInstance(new string[] {"L","O","G"}, 1f);
				
			case "Mud":
				
				return CreateInstance(new string[] {"M","U","D"}, 1f);
				
			case "Web":
				
				return CreateInstance(new string[] {"W","E","B"}, 1f);

			//Bedroom
				
			case "Bed":
				
				return CreateInstance(new string[] {"B","E","D"}, 1f);
				
			case "Crib":
				
				return CreateInstance(new string[] {"C","R","I","B"}, 1f);
				
			case "Fan":
				
				return CreateInstance(new string[] {"F","A","N"}, 1f);
				
			case "Mat":
				
				return CreateInstance(new string[] {"M","A","T"}, 1f);
				
			case "Rug":

				return CreateInstance(new string[] {"R","U","G"}, 1f);

			// School
				
			case "Desk":
				
				return CreateInstance(new string[] {"C","U","P"}, 1f);
				
			case "Mug":
				
				return CreateInstance(new string[] {"J","A","R"}, 1f);
				
			case "Pad":
				
				return CreateInstance(new string[] {"J","U","G"}, 1f);
				
			case "Pen":
				
				return CreateInstance(new string[] {"O","V","E","N"}, 1f);
				
			case "Pin":
				
				return CreateInstance(new string[] {"P","A","N"}, 1f);

			// Playground
				
			case "Box":
				
				return CreateInstance(new string[] {"B","O","X"}, 1f);
				
			case "Net":
				
				return CreateInstance(new string[] {"N","E","T"}, 1f);
				
			case "Sun":
				
				return CreateInstance(new string[] {"S","U","N"}, 1f);
				
			case "Top":
				
				return CreateInstance(new string[] {"T","O","P"}, 1f);
				
			case "Yoyo":
				
				return CreateInstance(new string[] {"Y","O","Y","O"}, 1f);

			// Clothing
				
			case "Cap":
				
				return CreateInstance(new string[] {"C","A","P"}, 1f);
				
			case "Hat":
				
				return CreateInstance(new string[] {"H","A","T"}, 1f);
				
			case "Tux":
				
				return CreateInstance(new string[] {"T","U","X"}, 1f);
				
			case "Vest":
				
				return CreateInstance(new string[] {"V","E","S","T"}, 1f);
				
			case "Wig":
				
				return CreateInstance(new string[] {"W","I","G"}, 1f);

			// Garden
				
			case "Ant":
				
				return CreateInstance(new string[] {"A","N","T"}, 1f);
				
			case "Kiwi":
				
				return CreateInstance(new string[] {"K","I","W","I"}, 1f);
				
			case "Nut":
				
				return CreateInstance(new string[] {"N","U","T"}, 1f);
				
			case "Plum":
				
				return CreateInstance(new string[] {"P","L","U","M"}, 1f);
				
			case "Pot":
				
				return CreateInstance(new string[] {"P","O","T"}, 1f);
			
			// Camping
				
			case "Bat":
				
				return CreateInstance(new string[] {"B","A","T"}, 1f);
				
			case "Fox":
				
				return CreateInstance(new string[] {"F","O","X"}, 1f);
				
			case "Map":
				
				return CreateInstance(new string[] {"M","A","P"}, 1f);
				
			case "Star":
				
				return CreateInstance(new string[] {"S","T","A","R"}, 1f);
				
			case "Tent":
				
				return CreateInstance(new string[] {"T","E","N","T"}, 1f);

			default:

				return null;

			}
		}

	}
}
