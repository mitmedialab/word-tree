using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class VocabList : MonoBehaviour {

		/*

		public static void CreateSpellingLesson(string word)
		{
			switch(word)
			{
				
			//Fruits Level
			case "Apple":
				
				WordCreation.CreateMovableAndTargetWords("APPLE",new string[] {"A-short","P","P","LE","LE"});
				CreateWordImage("Apple",.7f);
				break;
				
			case "Banana":
				
				WordCreation.CreateMovableAndTargetWords("BANANA",new string[] {"B","A","N","A","N","A"});
				CreateWordImage("Banana",1);
				break;

			case "Cherry":
				
				WordCreation.CreateMovableAndTargetWords("CHERRY",new string[] {"C","H","E","R","R","Y"});
				CreateWordImage("Cherry",.7f);
				break;
				
			case "Grape":
				
				WordCreation.CreateMovableAndTargetWords("GRAPE",new string[] {"G","R","A","P","E"});
				CreateWordImage("Grape",1);
				break;
			
			case "Orange":
				
				WordCreation.CreateMovableAndTargetWords("ORANGE",new string[] {"O","R","A","N","G","E"});
				CreateWordImage("Orange",1);
				break;

				
			//Animals Level
			case "Bird":
				
				WordCreation.CreateMovableAndTargetWords("BIRD",new string[] {"B","I","R","D"});
				CreateWordImage("Bird",.6f);
				break;

			case "Fish":
				
				WordCreation.CreateMovableAndTargetWords("FISH",new string[] {"F","I","S","H"});
				CreateWordImage("Fish",1.1f);
				break;

			case "Horse":
				
				WordCreation.CreateMovableAndTargetWords("HORSE",new string[] {"H","O","R","S","E"});
				CreateWordImage("Horse",.9f);
				break;

			case "Rabbit":
				
				WordCreation.CreateMovableAndTargetWords("RABBIT",new string[] {"R","A","B","B","I","T"});
				CreateWordImage("Rabbit",.6f);
				break;

			case "Zebra":
				
				WordCreation.CreateMovableAndTargetWords("ZEBRA",new string[] {"Z","E","B","R","A"});
				CreateWordImage("Zebra",1f);
				break;
			
			//SchoolSupplies Level
			case "Book":
				
				WordCreation.CreateMovableAndTargetWords("BOOK",new string[] {"B","O","O","K"});
				CreateWordImage("Book",.1f);
				break;
				
			case "Crayon":
				
				WordCreation.CreateMovableAndTargetWords("CRAYON",new string[] {"C","R","A","Y","O","N"});
				CreateWordImage("Crayon",.3f);
				break;
				
			case "Glue":
				
				WordCreation.CreateMovableAndTargetWords("GLUE",new string[] {"G","L","U","E"});
				CreateWordImage("Glue",.3f);
				break;
				
			case "Pencil":
				
				WordCreation.CreateMovableAndTargetWords("PENCIL",new string[] {"P","E","N","C","I","L"});
				CreateWordImage("Pencil",1f);
				break;
			
			case "Tape":
				
				WordCreation.CreateMovableAndTargetWords("TAPE",new string[] {"T","A","P","E"});
				CreateWordImage("Tape",.7f);
				break;

			//Clothes Level
			case "Boot":
				
				WordCreation.CreateMovableAndTargetWords("BOOT",new string[] {"B","O","O","T"});
				CreateWordImage("Boot",.6f);
				break;
				
			case "Glove":
				
				WordCreation.CreateMovableAndTargetWords("GLOVE",new string[] {"G","L","O","V","E"});
				CreateWordImage("Glove",1.2f);
				break;
				
			case "Jacket":
				
				WordCreation.CreateMovableAndTargetWords("JACKET",new string[] {"J","A","C","K","E","T"});
				CreateWordImage("Jacket",.35f);
				break;
				
			case "Pants":
				
				WordCreation.CreateMovableAndTargetWords("PANTS",new string[] {"P","A","N","T","S"});
				CreateWordImage("Pants",1f);
				break;
				
			case "Shirt":
				
				WordCreation.CreateMovableAndTargetWords("SHIRT",new string[] {"S","H","I","R","T"});
				CreateWordImage("Shirt",.6f);
				break;
			
			//Jobs Level
			case "Author":
				
				WordCreation.CreateMovableAndTargetWords("AUTHOR",new string[] {"A","U","T","H","O","R"});
				CreateWordImage("Author",.8f);
				break;
				
			case "Chef":
				
				WordCreation.CreateMovableAndTargetWords("CHEF",new string[] {"C","H","E","F"});
				CreateWordImage("Chef",.7f);
				break;
			
			case "Doctor":
				
				WordCreation.CreateMovableAndTargetWords("DOCTOR",new string[] {"D","O","C","T","O","R"});
				CreateWordImage("Doctor",1f);
				break;
				
			case "Nurse":
				
				WordCreation.CreateMovableAndTargetWords("NURSE",new string[] {"N","U","R","S","E"});
				CreateWordImage("Nurse",.5f);
				break;
				
			case "Police":
				
				WordCreation.CreateMovableAndTargetWords("POLICE",new string[] {"P","O","L","I","C","E"});
				CreateWordImage("Police",.45f);
				break;
			
			//Sports Level
			case "Golf":
				
				WordCreation.CreateMovableAndTargetWords("GOLF",new string[] {"G","O","L","F"});
				CreateWordImage("Golf",.18f);
				break;
				
			case "Hockey":
				
				WordCreation.CreateMovableAndTargetWords("HOCKEY",new string[] {"H","O","C","K","E","Y"});
				CreateWordImage("Hockey",.7f);
				break;
				
			case "Soccer":
				
				WordCreation.CreateMovableAndTargetWords("SOCCER",new string[] {"S","O","C","C","E","R"});
				CreateWordImage("Soccer",.6f);
				break;
				
			case "Skate":
				
				WordCreation.CreateMovableAndTargetWords("SKATE",new string[] {"S","K","A","T","E"});
				CreateWordImage("Skate",2.4f);
				break;
				
			case "Track":
				
				WordCreation.CreateMovableAndTargetWords("TRACK",new string[] {"T","R","A","C","K"});
				CreateWordImage("Track",.7f);
				break;

			//Transportation Level
			case "Bus":
				
				WordCreation.CreateMovableAndTargetWords("BUS",new string[] {"B","U","S"});
				CreateWordImage("Bus",.12f);
				break;
				
			case "Car":
				
				WordCreation.CreateMovableAndTargetWords("CAR",new string[] {"C","A","R"});
				CreateWordImage("Car",.8f);
				break;
				
			case "Plane":
				
				WordCreation.CreateMovableAndTargetWords("PLANE",new string[] {"P","L","A","N","E"});
				CreateWordImage("Plane",.12f);
				break;
				
			case "Ship":
				
				WordCreation.CreateMovableAndTargetWords("SHIP",new string[] {"S","H","I","P"});
				CreateWordImage("Ship",.12f);
				break;
				
			case "Train":
				
				WordCreation.CreateMovableAndTargetWords("TRAIN",new string[] {"T","R","A","I","N"});
				CreateWordImage("Train",.6f);
				break;

			//Bedroom Level
			case "Bed":
				
				WordCreation.CreateMovableAndTargetWords("BED",new string[] {"B","E","D"});
				CreateWordImage("Bed",1f);
				break;
				
			case "Clock":
				
				WordCreation.CreateMovableAndTargetWords("CLOCK",new string[] {"C","L","O","C","K"});
				CreateWordImage("Clock",.6f);
				break;
				
			case "Lamp":
				
				WordCreation.CreateMovableAndTargetWords("LAMP",new string[] {"L","A","M","P"});
				CreateWordImage("Lamp",.5f);
				break;
				
			case "Mirror":
				
				WordCreation.CreateMovableAndTargetWords("MIRROR",new string[] {"M","I","R","R","O","R"});
				CreateWordImage("Mirror",.3f);
				break;
				
			case "Pillow":
				
				WordCreation.CreateMovableAndTargetWords("PILLOW",new string[] {"P","I","L","L","O","W"});
				CreateWordImage("Pillow",.5f);
				break;
			
			//Vegetables Level
			case "Bean":
				
				WordCreation.CreateMovableAndTargetWords("BEAN",new string[] {"B","E","A","N"});
				CreateWordImage("Bean",.6f);
				break;
				
			case "Carrot":
				
				WordCreation.CreateMovableAndTargetWords("CARROT",new string[] {"C","A","R","R","O","T"});
				CreateWordImage("Carrot",.9f);
				break;
				
			case "Onion":
				
				WordCreation.CreateMovableAndTargetWords("ONION",new string[] {"O","N","I","O","N"});
				CreateWordImage("Onion",.8f);
				break;
				
			case "Pepper":
				
				WordCreation.CreateMovableAndTargetWords("PEPPER",new string[] {"P","E","P","P","E","R"});
				CreateWordImage("Pepper",.8f);
				break;
				
			case "Radish":
				
				WordCreation.CreateMovableAndTargetWords("RADISH",new string[] {"R","A","D","I","S","H"});
				CreateWordImage("Radish",1.4f);
				break;
			}
		}
		*/
	}
}
