using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class VocabList : MonoBehaviour {
		
		public static void CreateObject(string word, float scale)
		{
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, 2, 0), new Vector3 (scale, scale, 1), GameDirector.currentLevel + "/" + word, "Words/"+word);
			GameDirector.InstantiateObject (Obj);
		}
		
		public static void CreateSpellingLesson(string word)
		{
			switch(word)
			{
				
			//Fruits Level
			case "Apple":
				
				WordCreation.CreateMovableAndTargetWords("APPLE",new string[] {"A-short","P","P","LE","LE"});
				CreateObject("Apple",.7f);
				break;
				
			case "Banana":
				
				WordCreation.CreateMovableAndTargetWords("BANANA",new string[] {"B","A","N","A","N","A"});
				CreateObject("Banana",1);
				break;

			case "Cherry":
				
				WordCreation.CreateMovableAndTargetWords("CHERRY",new string[] {"C","H","E","R","R","Y"});
				CreateObject("Cherry",.7f);
				break;
				
			case "Grape":
				
				WordCreation.CreateMovableAndTargetWords("GRAPE",new string[] {"G","R","A","P","E"});
				CreateObject("Grape",1);
				break;
			
			case "Orange":
				
				WordCreation.CreateMovableAndTargetWords("ORANGE",new string[] {"O","R","A","N","G","E"});
				CreateObject("Orange",1);
				break;

				
			//Animals Level
			case "Bird":
				
				WordCreation.CreateMovableAndTargetWords("BIRD",new string[] {"B","I","R","D"});
				CreateObject("Bird",.6f);
				break;

			case "Fish":
				
				WordCreation.CreateMovableAndTargetWords("FISH",new string[] {"F","I","S","H"});
				CreateObject("Fish",1.1f);
				break;

			case "Horse":
				
				WordCreation.CreateMovableAndTargetWords("HORSE",new string[] {"H","O","R","S","E"});
				CreateObject("Horse",.9f);
				break;

			case "Rabbit":
				
				WordCreation.CreateMovableAndTargetWords("RABBIT",new string[] {"R","A","B","B","I","T"});
				CreateObject("Rabbit",.6f);
				break;

			case "Zebra":
				
				WordCreation.CreateMovableAndTargetWords("ZEBRA",new string[] {"Z","E","B","R","A"});
				CreateObject("Zebra",1f);
				break;
			
			//SchoolSupplies Level
			case "Book":
				
				WordCreation.CreateMovableAndTargetWords("BOOK",new string[] {"B","O","O","K"});
				CreateObject("Book",.1f);
				break;
				
			case "Crayon":
				
				WordCreation.CreateMovableAndTargetWords("CRAYON",new string[] {"C","R","A","Y","O","N"});
				CreateObject("Crayon",.3f);
				break;
				
			case "Glue":
				
				WordCreation.CreateMovableAndTargetWords("GLUE",new string[] {"G","L","U","E"});
				CreateObject("Glue",.3f);
				break;
				
			case "Pencil":
				
				WordCreation.CreateMovableAndTargetWords("PENCIL",new string[] {"P","E","N","C","I","L"});
				CreateObject("Pencil",1f);
				break;
			
			case "Tape":
				
				WordCreation.CreateMovableAndTargetWords("TAPE",new string[] {"T","A","P","E"});
				CreateObject("Tape",.7f);
				break;

			//Clothes Level
			case "Boot":
				
				WordCreation.CreateMovableAndTargetWords("BOOT",new string[] {"B","O","O","T"});
				CreateObject("Boot",.6f);
				break;
				
			case "Glove":
				
				WordCreation.CreateMovableAndTargetWords("GLOVE",new string[] {"G","L","O","V","E"});
				CreateObject("Glove",1.2f);
				break;
				
			case "Jacket":
				
				WordCreation.CreateMovableAndTargetWords("JACKET",new string[] {"J","A","C","K","E","T"});
				CreateObject("Jacket",.35f);
				break;
				
			case "Pants":
				
				WordCreation.CreateMovableAndTargetWords("PANTS",new string[] {"P","A","N","T","S"});
				CreateObject("Pants",1f);
				break;
				
			case "Shirt":
				
				WordCreation.CreateMovableAndTargetWords("SHIRT",new string[] {"S","H","I","R","T"});
				CreateObject("Shirt",.6f);
				break;
			
			//Jobs Level
			case "Author":
				
				WordCreation.CreateMovableAndTargetWords("AUTHOR",new string[] {"A","U","T","H","O","R"});
				CreateObject("Author",.8f);
				break;
				
			case "Chef":
				
				WordCreation.CreateMovableAndTargetWords("CHEF",new string[] {"C","H","E","F"});
				CreateObject("Chef",.7f);
				break;
			
			case "Doctor":
				
				WordCreation.CreateMovableAndTargetWords("DOCTOR",new string[] {"D","O","C","T","O","R"});
				CreateObject("Doctor",1f);
				break;
				
			case "Nurse":
				
				WordCreation.CreateMovableAndTargetWords("NURSE",new string[] {"N","U","R","S","E"});
				CreateObject("Nurse",.5f);
				break;
				
			case "Police":
				
				WordCreation.CreateMovableAndTargetWords("POLICE",new string[] {"P","O","L","I","C","E"});
				CreateObject("Police",.45f);
				break;
			
			//Sports Level
			case "Golf":
				
				WordCreation.CreateMovableAndTargetWords("GOLF",new string[] {"G","O","L","F"});
				CreateObject("Golf",.18f);
				break;
				
			case "Hockey":
				
				WordCreation.CreateMovableAndTargetWords("HOCKEY",new string[] {"H","O","C","K","E","Y"});
				CreateObject("Hockey",.7f);
				break;
				
			case "Soccer":
				
				WordCreation.CreateMovableAndTargetWords("SOCCER",new string[] {"S","O","C","C","E","R"});
				CreateObject("Soccer",.6f);
				break;
				
			case "Skate":
				
				WordCreation.CreateMovableAndTargetWords("SKATE",new string[] {"S","K","A","T","E"});
				CreateObject("Skate",2.4f);
				break;
				
			case "Track":
				
				WordCreation.CreateMovableAndTargetWords("TRACK",new string[] {"T","R","A","C","K"});
				CreateObject("Track",.7f);
				break;

			//Transportation Level
			case "Bus":
				
				WordCreation.CreateMovableAndTargetWords("BUS",new string[] {"B","U","S"});
				CreateObject("Bus",.12f);
				break;
				
			case "Car":
				
				WordCreation.CreateMovableAndTargetWords("CAR",new string[] {"C","A","R"});
				CreateObject("Car",.8f);
				break;
				
			case "Plane":
				
				WordCreation.CreateMovableAndTargetWords("PLANE",new string[] {"P","L","A","N","E"});
				CreateObject("Plane",.12f);
				break;
				
			case "Ship":
				
				WordCreation.CreateMovableAndTargetWords("SHIP",new string[] {"S","H","I","P"});
				CreateObject("Ship",.12f);
				break;
				
			case "Train":
				
				WordCreation.CreateMovableAndTargetWords("TRAIN",new string[] {"T","R","A","I","N"});
				CreateObject("Train",.6f);
				break;

			//Bedroom Level
			case "Bed":
				
				WordCreation.CreateMovableAndTargetWords("BED",new string[] {"B","E","D"});
				CreateObject("Bed",1f);
				break;
				
			case "Clock":
				
				WordCreation.CreateMovableAndTargetWords("CLOCK",new string[] {"C","L","O","C","K"});
				CreateObject("Clock",.6f);
				break;
				
			case "Lamp":
				
				WordCreation.CreateMovableAndTargetWords("LAMP",new string[] {"L","A","M","P"});
				CreateObject("Lamp",.5f);
				break;
				
			case "Mirror":
				
				WordCreation.CreateMovableAndTargetWords("MIRROR",new string[] {"M","I","R","R","O","R"});
				CreateObject("Mirror",.3f);
				break;
				
			case "Pillow":
				
				WordCreation.CreateMovableAndTargetWords("PILLOW",new string[] {"P","I","L","L","O","W"});
				CreateObject("Pillow",.5f);
				break;
			
			//Vegetables Level
			case "Bean":
				
				WordCreation.CreateMovableAndTargetWords("BEAN",new string[] {"B","E","A","N"});
				CreateObject("Bean",.6f);
				break;
				
			case "Carrot":
				
				WordCreation.CreateMovableAndTargetWords("CARROT",new string[] {"C","A","R","R","O","T"});
				CreateObject("Carrot",.9f);
				break;
				
			case "Onion":
				
				WordCreation.CreateMovableAndTargetWords("ONION",new string[] {"O","N","I","O","N"});
				CreateObject("Onion",.8f);
				break;
				
			case "Pepper":
				
				WordCreation.CreateMovableAndTargetWords("PEPPER",new string[] {"P","E","P","P","E","R"});
				CreateObject("Pepper",.8f);
				break;
				
			case "Radish":
				
				WordCreation.CreateMovableAndTargetWords("RADISH",new string[] {"R","A","D","I","S","H"});
				CreateObject("Radish",1.4f);
				break;
			}
		}
	}
}
