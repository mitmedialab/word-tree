using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SpellingGameDirector : MonoBehaviour {


		void Start () {


		
		}

		void CreateBlanks(string word)
		{
			float xScale = .3f;
			float yScale = .3f;
			int y = 0;
			int z = 0;
			Vector3[] Position = new Vector3[word.Length];
			int[,] Order = new int[3,word.Length];
			
			if (tag == "MovableLetter")
				z = -1;
			
			if (word.Length == 3) {
				Position = new Vector3[3] {
					new Vector3 (-2, y, z),
					new Vector3 (0, y, z),
					new Vector3 (2, y, z)
				};
				Order = new int[3,3] {
					{2,3,1},
					{3,1,2},
					{3,2,1}
				};
			}
			
			if (word.Length == 4) {
				Position = new Vector3[4] {
					new Vector3 (-3, y, z),
					new Vector3 (-1, y, z),
					new Vector3 (1, y, z),
					new Vector3 (3, y, z),
				};
				Order = new int[3,4] {
					{2,3,4,1},
					{3,1,4,2},
					{4,3,1,2}
				};
			}
			
			if (word.Length == 5) {
				Position = new Vector3[5] {
					new Vector3 (-4, y, z),
					new Vector3 (-2, y, z),
					new Vector3 (0, y, z),
					new Vector3 (2, y, z),
					new Vector3 (4, y, z)
				};
				Order = new int[3,5] {
					{3,5,1,2,4},
					{4,1,2,5,3},
					{2,5,4,3,1}
				};
			}
			
			if (word.Length == 6) {
				Position = new Vector3[6] {
					new Vector3 (-5, y, z),
					new Vector3 (-3, y, z),
					new Vector3 (-1, y, z),
					new Vector3 (1, y, z),
					new Vector3 (3, y, z),
					new Vector3 (5, y, z)
				};
				Order = new int[3,6] {
					{2,5,4,1,6,3},
					{4,6,2,5,3,1},
					{6,3,1,2,4,5}
				};
			}
		}



		public static void CreateSpellingGame(string word)
		{
			switch(word)
			{
				
				//Fruits Level
			case "Apple":
				
				WordCreation.CreateMovableWord("APPLE",new string[] {"A-short","P","P","LE","LE"});
				VocabList.CreateObject("Apple",.7f);
				break;
				
			case "Banana":
				
				WordCreation.CreateMovableWord("BANANA",new string[] {"B","A","N","A","N","A"});
				VocabList.CreateObject("Banana",1);
				break;
				
			case "Cherry":
				
				WordCreation.CreateMovableWord("CHERRY",new string[] {"C","H","E","R","R","Y"});
				VocabList.CreateObject("Cherry",.7f);
				break;
				
			case "Grape":
				
				WordCreation.CreateMovableWord("GRAPE",new string[] {"G","R","A","P","E"});
				VocabList.CreateObject("Grape",1);
				break;
				
			case "Orange":
				
				WordCreation.CreateMovableWord("ORANGE",new string[] {"O","R","A","N","G","E"});
				VocabList.CreateObject("Orange",1);
				break;
				
				
				//Animals Level
			case "Bird":
				
				WordCreation.CreateMovableWord("BIRD",new string[] {"B","I","R","D"});
				VocabList.CreateObject("Bird",.6f);
				break;
				
			case "Fish":
				
				WordCreation.CreateMovableWord("FISH",new string[] {"F","I","S","H"});
				VocabList.CreateObject("Fish",1.1f);
				break;
				
			case "Horse":
				
				WordCreation.CreateMovableWord("HORSE",new string[] {"H","O","R","S","E"});
				VocabList.CreateObject("Horse",.9f);
				break;
				
			case "Rabbit":
				
				WordCreation.CreateMovableWord("RABBIT",new string[] {"R","A","B","B","I","T"});
				VocabList.CreateObject("Rabbit",.6f);
				break;
				
			case "Zebra":
				
				WordCreation.CreateMovableWord("ZEBRA",new string[] {"Z","E","B","R","A"});
				VocabList.CreateObject("Zebra",.9f);
				break;
				
				//SchoolSupplies Level
			case "Book":
				
				WordCreation.CreateMovableWord("BOOK",new string[] {"B","O","O","K"});
				VocabList.CreateObject("Book",.1f);
				break;
				
			case "Crayon":
				
				WordCreation.CreateMovableWord("CRAYON",new string[] {"C","R","A","Y","O","N"});
				VocabList.CreateObject("Crayon",.3f);
				break;
				
			case "Glue":
				
				WordCreation.CreateMovableWord("GLUE",new string[] {"G","L","U","E"});
				VocabList.CreateObject("Glue",.3f);
				break;
				
			case "Pencil":
				
				WordCreation.CreateMovableWord("PENCIL",new string[] {"P","E","N","C","I","L"});
				VocabList.CreateObject("Pencil",1f);
				break;
				
			case "Tape":
				
				WordCreation.CreateMovableWord("TAPE",new string[] {"T","A","P","E"});
				VocabList.CreateObject("Tape",.7f);
				break;
				
				//Clothes Level
			case "Boot":
				
				WordCreation.CreateMovableWord("BOOT",new string[] {"B","O","O","T"});
				VocabList.CreateObject("Boot",.6f);
				break;
				
			case "Glove":
				
				WordCreation.CreateMovableWord("GLOVE",new string[] {"G","L","O","V","E"});
				VocabList.CreateObject("Glove",1.2f);
				break;
				
			case "Jacket":
				
				WordCreation.CreateMovableWord("JACKET",new string[] {"J","A","C","K","E","T"});
				VocabList.CreateObject("Jacket",.35f);
				break;
				
			case "Pants":
				
				WordCreation.CreateMovableWord("PANTS",new string[] {"P","A","N","T","S"});
				VocabList.CreateObject("Pants",1f);
				break;
				
			case "Shirt":
				
				WordCreation.CreateMovableWord("SHIRT",new string[] {"S","H","I","R","T"});
				VocabList.CreateObject("Shirt",.6f);
				break;
				
				//Jobs Level
			case "Author":
				
				WordCreation.CreateMovableWord("AUTHOR",new string[] {"A","U","T","H","O","R"});
				VocabList.CreateObject("Author",.8f);
				break;
				
			case "Chef":
				
				WordCreation.CreateMovableWord("CHEF",new string[] {"C","H","E","F"});
				VocabList.CreateObject("Chef",.7f);
				break;
				
			case "Doctor":
				
				WordCreation.CreateMovableWord("DOCTOR",new string[] {"D","O","C","T","O","R"});
				VocabList.CreateObject("Doctor",.9f);
				break;
				
			case "Nurse":
				
				WordCreation.CreateMovableWord("NURSE",new string[] {"N","U","R","S","E"});
				VocabList.CreateObject("Nurse",.5f);
				break;
				
			case "Police":
				
				WordCreation.CreateMovableWord("POLICE",new string[] {"P","O","L","I","C","E"});
				VocabList.CreateObject("Police",.45f);
				break;
				
				//Sports Level
			case "Golf":
				
				WordCreation.CreateMovableWord("GOLF",new string[] {"G","O","L","F"});
				VocabList.CreateObject("Golf",.18f);
				break;
				
			case "Hockey":
				
				WordCreation.CreateMovableWord("HOCKEY",new string[] {"H","O","C","K","E","Y"});
				VocabList.CreateObject("Hockey",.7f);
				break;
				
			case "Soccer":
				
				WordCreation.CreateMovableWord("SOCCER",new string[] {"S","O","C","C","E","R"});
				VocabList.CreateObject("Soccer",.6f);
				break;
				
			case "Skate":
				
				WordCreation.CreateMovableWord("SKATE",new string[] {"S","K","A","T","E"});
				VocabList.CreateObject("Skate",2.4f);
				break;
				
			case "Track":
				
				WordCreation.CreateMovableWord("TRACK",new string[] {"T","R","A","C","K"});
				VocabList.CreateObject("Track",.7f);
				break;
				
				//Transportation Level
			case "Bus":
				
				WordCreation.CreateMovableWord("BUS",new string[] {"B","U","S"});
				VocabList.CreateObject("Bus",.12f);
				break;
				
			case "Car":
				
				WordCreation.CreateMovableWord("CAR",new string[] {"C","A","R"});
				VocabList.CreateObject("Car",.8f);
				break;
				
			case "Plane":
				
				WordCreation.CreateMovableWord("PLANE",new string[] {"P","L","A","N","E"});
				VocabList.CreateObject("Plane",.12f);
				break;
				
			case "Ship":
				
				WordCreation.CreateMovableWord("SHIP",new string[] {"S","H","I","P"});
				VocabList.CreateObject("Ship",.12f);
				break;
				
			case "Train":
				
				WordCreation.CreateMovableWord("TRAIN",new string[] {"T","R","A","I","N"});
				VocabList.CreateObject("Train",.6f);
				break;
				
				//Bedroom Level
			case "Bed":
				
				WordCreation.CreateMovableWord("BED",new string[] {"B","E","D"});
				VocabList.CreateObject("Bed",1f);
				break;
				
			case "Clock":
				
				WordCreation.CreateMovableWord("CLOCK",new string[] {"C","L","O","C","K"});
				VocabList.CreateObject("Clock",.6f);
				break;
				
			case "Lamp":
				
				WordCreation.CreateMovableWord("LAMP",new string[] {"L","A","M","P"});
				VocabList.CreateObject("Lamp",.5f);
				break;
				
			case "Mirror":
				
				WordCreation.CreateMovableWord("MIRROR",new string[] {"M","I","R","R","O","R"});
				VocabList.CreateObject("Mirror",.3f);
				break;
				
			case "Pillow":
				
				WordCreation.CreateMovableWord("PILLOW",new string[] {"P","I","L","L","O","W"});
				VocabList.CreateObject("Pillow",.5f);
				break;
				
				//Vegetables Level
			case "Bean":
				
				WordCreation.CreateMovableWord("BEAN",new string[] {"B","E","A","N"});
				VocabList.CreateObject("Bean",.6f);
				break;
				
			case "Carrot":
				
				WordCreation.CreateMovableWord("CARROT",new string[] {"C","A","R","R","O","T"});
				VocabList.CreateObject("Carrot",.9f);
				break;
				
			case "Onion":
				
				WordCreation.CreateMovableWord("ONION",new string[] {"O","N","I","O","N"});
				VocabList.CreateObject("Onion",.8f);
				break;
				
			case "Pepper":
				
				WordCreation.CreateMovableWord("PEPPER",new string[] {"P","E","P","P","E","R"});
				VocabList.CreateObject("Pepper",.8f);
				break;
				
			case "Radish":
				
				WordCreation.CreateMovableWord("RADISH",new string[] {"R","A","D","I","S","H"});
				VocabList.CreateObject("Radish",1.4f);
				break;
			}


		}
	}
}
