using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class VocabList : MonoBehaviour {
		
		static void CreateObject(string word, float scale)
		{
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, 2, 0), new Vector3 (scale, scale, 1), GameDirector.currentLevel + "/" + word, word);
			GameDirector.InstantiateObject (Obj);
		}
		
		public static void CreateWordsAndObjectSwitch(string word)
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
				
			case "Grape":
				
				WordCreation.CreateMovableAndTargetWords("GRAPE",new string[] {"G","R","A","P","E"});
				CreateObject("Grape",1);
				break;
			
			case "Orange":
				
				WordCreation.CreateMovableAndTargetWords("ORANGE",new string[] {"O","R","A","N","G","E"});
				CreateObject("Orange",1);
				break;

			case "Peach":
				
				WordCreation.CreateMovableAndTargetWords("PEACH",new string[] {"P","E","A","C","H"});
				CreateObject("Peach",1.4f);
				break;

				
			//Animals Level
			case "Bird":
				
				WordCreation.CreateMovableAndTargetWords("BIRD",new string[] {"B","I","R","D"});
				CreateObject("Bird",.6f);
				break;
				
			case "Camel":
				
				WordCreation.CreateMovableAndTargetWords("CAMEL",new string[] {"C","A","M","E","L"});
				CreateObject("Camel",.7f);
				break;
				
			case "Fish":
				
				WordCreation.CreateMovableAndTargetWords("FISH",new string[] {"F","I","S","H"});
				CreateObject("Fish",1.1f);
				break;
				
			case "Goat":
				
				WordCreation.CreateMovableAndTargetWords("GOAT",new string[] {"G","O","A","T"});
				CreateObject("Goat",.05f);
				break;

			case "Horse":
				
				WordCreation.CreateMovableAndTargetWords("HORSE",new string[] {"H","O","R","S","E"});
				CreateObject("Horse",.8f);
				break;
				
			}
		}
	}
}
