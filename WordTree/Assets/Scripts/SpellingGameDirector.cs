using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SpellingGameDirector : MonoBehaviour {


		void Start () {

			CreateSpellingGame ("Apple");

			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetBlank");
			foreach (GameObject go in tar)
				go.AddComponent<CollisionManager> ();
		
		}

		static void CreateBlanks(string word)
		{
			float xScale = .5f;
			float yScale = .5f;
			int y = -2;
			int z = 0;
			Vector3[] Position = new Vector3[word.Length];

			string[] letterArray = new string[word.Length];
			for (int i=0; i<word.Length; i++) {
				char letter = System.Char.ToUpper (word [i]);
				letterArray [i] = System.Char.ToString (letter);
			}

			
			if (word.Length == 3) {
				Position = new Vector3[3]{
					new Vector3 (-2, y, z),
					new Vector3 (0, y, z),
					new Vector3 (2, y, z)
				};
			}
			
			if (word.Length == 4) {
				Position = new Vector3[4] {
					new Vector3 (-3, y, z),
					new Vector3 (-1, y, z),
					new Vector3 (1, y, z),
					new Vector3 (3, y, z),
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
			}

			ObjectProperties blank1 = ObjectProperties.CreateInstance (letterArray[0], "TargetBlank", Position[0], new Vector3 (xScale, yScale, 1), "Blank", null);
			GameDirector.InstantiateObject (blank1);
			
			ObjectProperties blank2 = ObjectProperties.CreateInstance (letterArray[1], "TargetBlank", Position[1], new Vector3 (xScale, yScale, 1), "Blank", null);
			GameDirector.InstantiateObject (blank2);
			
			ObjectProperties blank3 = ObjectProperties.CreateInstance (letterArray[2], "TargetBlank", Position[2], new Vector3 (xScale, yScale, 1), "Blank", null);
			GameDirector.InstantiateObject (blank3);
			
			if (word.Length >= 4) {
				
				ObjectProperties blank4 = ObjectProperties.CreateInstance (letterArray[3], "TargetBlank", Position[3], new Vector3 (xScale, yScale, 1), "Blank", null);
				GameDirector.InstantiateObject (blank4);
			}
			
			if (word.Length >= 5) {
				
				ObjectProperties blank5 = ObjectProperties.CreateInstance (letterArray[4], "TargetBlank", Position[4], new Vector3 (xScale, yScale, 1), "Blank", null);
				GameDirector.InstantiateObject (blank5);
			}
			
			if (word.Length >= 6) {
				
				ObjectProperties blank6 = ObjectProperties.CreateInstance (letterArray[5], "TargetBlank", Position[5], new Vector3 (xScale, yScale, 1), "Blank", null);
				GameDirector.InstantiateObject (blank6);
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
				CreateBlanks(word);
				break;
				
			case "Banana":
				
				WordCreation.CreateMovableWord("BANANA",new string[] {"B","A","N","A","N","A"});
				VocabList.CreateObject("Banana",1);
				CreateBlanks(word);
				break;
				
			case "Cherry":
				
				WordCreation.CreateMovableWord("CHERRY",new string[] {"C","H","E","R","R","Y"});
				VocabList.CreateObject("Cherry",.7f);
				CreateBlanks(word);
				break;
				
			case "Grape":
				
				WordCreation.CreateMovableWord("GRAPE",new string[] {"G","R","A","P","E"});
				VocabList.CreateObject("Grape",1);
				CreateBlanks(word);
				break;
				
			case "Orange":
				
				WordCreation.CreateMovableWord("ORANGE",new string[] {"O","R","A","N","G","E"});
				VocabList.CreateObject("Orange",1);
				CreateBlanks(word);
				break;
				
				
				//Animals Level
			case "Bird":
				
				WordCreation.CreateMovableWord("BIRD",new string[] {"B","I","R","D"});
				VocabList.CreateObject("Bird",.6f);
				CreateBlanks(word);
				break;
				
			case "Fish":
				
				WordCreation.CreateMovableWord("FISH",new string[] {"F","I","S","H"});
				VocabList.CreateObject("Fish",1.1f);
				CreateBlanks(word);
				break;
				
			case "Horse":
				
				WordCreation.CreateMovableWord("HORSE",new string[] {"H","O","R","S","E"});
				VocabList.CreateObject("Horse",.9f);
				CreateBlanks(word);
				break;
				
			case "Rabbit":
				
				WordCreation.CreateMovableWord("RABBIT",new string[] {"R","A","B","B","I","T"});
				VocabList.CreateObject("Rabbit",.6f);
				CreateBlanks(word);
				break;
				
			case "Zebra":
				
				WordCreation.CreateMovableWord("ZEBRA",new string[] {"Z","E","B","R","A"});
				VocabList.CreateObject("Zebra",.9f);
				CreateBlanks(word);
				break;
				
				//SchoolSupplies Level
			case "Book":
				
				WordCreation.CreateMovableWord("BOOK",new string[] {"B","O","O","K"});
				VocabList.CreateObject("Book",.1f);
				CreateBlanks(word);
				break;
				
			case "Crayon":
				
				WordCreation.CreateMovableWord("CRAYON",new string[] {"C","R","A","Y","O","N"});
				VocabList.CreateObject("Crayon",.3f);
				CreateBlanks(word);
				break;
				
			case "Glue":
				
				WordCreation.CreateMovableWord("GLUE",new string[] {"G","L","U","E"});
				VocabList.CreateObject("Glue",.3f);
				CreateBlanks(word);
				break;
				
			case "Pencil":
				
				WordCreation.CreateMovableWord("PENCIL",new string[] {"P","E","N","C","I","L"});
				VocabList.CreateObject("Pencil",1f);
				CreateBlanks(word);
				break;
				
			case "Tape":
				
				WordCreation.CreateMovableWord("TAPE",new string[] {"T","A","P","E"});
				VocabList.CreateObject("Tape",.7f);
				CreateBlanks(word);
				break;
				
				//Clothes Level
			case "Boot":
				
				WordCreation.CreateMovableWord("BOOT",new string[] {"B","O","O","T"});
				VocabList.CreateObject("Boot",.6f);
				CreateBlanks(word);
				break;
				
			case "Glove":
				
				WordCreation.CreateMovableWord("GLOVE",new string[] {"G","L","O","V","E"});
				VocabList.CreateObject("Glove",1.2f);
				CreateBlanks(word);
				break;
				
			case "Jacket":
				
				WordCreation.CreateMovableWord("JACKET",new string[] {"J","A","C","K","E","T"});
				VocabList.CreateObject("Jacket",.35f);
				CreateBlanks(word);
				break;
				
			case "Pants":
				
				WordCreation.CreateMovableWord("PANTS",new string[] {"P","A","N","T","S"});
				VocabList.CreateObject("Pants",1f);
				CreateBlanks(word);
				break;
				
			case "Shirt":
				
				WordCreation.CreateMovableWord("SHIRT",new string[] {"S","H","I","R","T"});
				VocabList.CreateObject("Shirt",.6f);
				CreateBlanks(word);
				break;
				
				//Jobs Level
			case "Author":
				
				WordCreation.CreateMovableWord("AUTHOR",new string[] {"A","U","T","H","O","R"});
				VocabList.CreateObject("Author",.8f);
				CreateBlanks(word);
				break;
				
			case "Chef":
				
				WordCreation.CreateMovableWord("CHEF",new string[] {"C","H","E","F"});
				VocabList.CreateObject("Chef",.7f);
				CreateBlanks(word);
				break;
				
			case "Doctor":
				
				WordCreation.CreateMovableWord("DOCTOR",new string[] {"D","O","C","T","O","R"});
				VocabList.CreateObject("Doctor",.9f);
				CreateBlanks(word);
				break;
				
			case "Nurse":
				
				WordCreation.CreateMovableWord("NURSE",new string[] {"N","U","R","S","E"});
				VocabList.CreateObject("Nurse",.5f);
				CreateBlanks(word);
				break;
				
			case "Police":
				
				WordCreation.CreateMovableWord("POLICE",new string[] {"P","O","L","I","C","E"});
				VocabList.CreateObject("Police",.45f);
				CreateBlanks(word);
				break;
				
				//Sports Level
			case "Golf":
				
				WordCreation.CreateMovableWord("GOLF",new string[] {"G","O","L","F"});
				VocabList.CreateObject("Golf",.18f);
				CreateBlanks(word);
				break;
				
			case "Hockey":
				
				WordCreation.CreateMovableWord("HOCKEY",new string[] {"H","O","C","K","E","Y"});
				VocabList.CreateObject("Hockey",.7f);
				CreateBlanks(word);
				break;
				
			case "Soccer":
				
				WordCreation.CreateMovableWord("SOCCER",new string[] {"S","O","C","C","E","R"});
				VocabList.CreateObject("Soccer",.6f);
				CreateBlanks(word);
				break;
				
			case "Skate":
				
				WordCreation.CreateMovableWord("SKATE",new string[] {"S","K","A","T","E"});
				VocabList.CreateObject("Skate",2.4f);
				CreateBlanks(word);
				break;
				
			case "Track":
				
				WordCreation.CreateMovableWord("TRACK",new string[] {"T","R","A","C","K"});
				VocabList.CreateObject("Track",.7f);
				CreateBlanks(word);
				break;
				
				//Transportation Level
			case "Bus":
				
				WordCreation.CreateMovableWord("BUS",new string[] {"B","U","S"});
				VocabList.CreateObject("Bus",.12f);
				CreateBlanks(word);
				break;
				
			case "Car":
				
				WordCreation.CreateMovableWord("CAR",new string[] {"C","A","R"});
				VocabList.CreateObject("Car",.8f);
				CreateBlanks(word);
				break;
				
			case "Plane":
				
				WordCreation.CreateMovableWord("PLANE",new string[] {"P","L","A","N","E"});
				VocabList.CreateObject("Plane",.12f);
				CreateBlanks(word);
				break;
				
			case "Ship":
				
				WordCreation.CreateMovableWord("SHIP",new string[] {"S","H","I","P"});
				VocabList.CreateObject("Ship",.12f);
				CreateBlanks(word);
				break;
				
			case "Train":
				
				WordCreation.CreateMovableWord("TRAIN",new string[] {"T","R","A","I","N"});
				VocabList.CreateObject("Train",.6f);
				CreateBlanks(word);
				break;
				
				//Bedroom Level
			case "Bed":
				
				WordCreation.CreateMovableWord("BED",new string[] {"B","E","D"});
				VocabList.CreateObject("Bed",1f);
				CreateBlanks(word);
				break;
				
			case "Clock":
				
				WordCreation.CreateMovableWord("CLOCK",new string[] {"C","L","O","C","K"});
				VocabList.CreateObject("Clock",.6f);
				CreateBlanks(word);
				break;
				
			case "Lamp":
				
				WordCreation.CreateMovableWord("LAMP",new string[] {"L","A","M","P"});
				VocabList.CreateObject("Lamp",.5f);
				CreateBlanks(word);
				break;
				
			case "Mirror":
				
				WordCreation.CreateMovableWord("MIRROR",new string[] {"M","I","R","R","O","R"});
				VocabList.CreateObject("Mirror",.3f);
				CreateBlanks(word);
				break;
				
			case "Pillow":
				
				WordCreation.CreateMovableWord("PILLOW",new string[] {"P","I","L","L","O","W"});
				VocabList.CreateObject("Pillow",.5f);
				CreateBlanks(word);
				break;
				
				//Vegetables Level
			case "Bean":
				
				WordCreation.CreateMovableWord("BEAN",new string[] {"B","E","A","N"});
				VocabList.CreateObject("Bean",.6f);
				CreateBlanks(word);
				break;
				
			case "Carrot":
				
				WordCreation.CreateMovableWord("CARROT",new string[] {"C","A","R","R","O","T"});
				VocabList.CreateObject("Carrot",.9f);
				CreateBlanks(word);
				break;
				
			case "Onion":
				
				WordCreation.CreateMovableWord("ONION",new string[] {"O","N","I","O","N"});
				VocabList.CreateObject("Onion",.8f);
				CreateBlanks(word);
				break;
				
			case "Pepper":
				
				WordCreation.CreateMovableWord("PEPPER",new string[] {"P","E","P","P","E","R"});
				VocabList.CreateObject("Pepper",.8f);
				CreateBlanks(word);
				break;
				
			case "Radish":
				
				WordCreation.CreateMovableWord("RADISH",new string[] {"R","A","D","I","S","H"});
				VocabList.CreateObject("Radish",1.4f);
				CreateBlanks(word);
				break;
			}


		}
	}
}
