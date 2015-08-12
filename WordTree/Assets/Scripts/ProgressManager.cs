using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WordTree
{
	public class ProgressManager : MonoBehaviour {

		public static string chosenKid = "";

		public static string currentWord = "";
		public static string currentLevel = "";
		public static int currentMode = 0;
		
		public static List<string> completedWordsLearn = new List<string>();
		public static List<string> completedWordsSpell = new List<string>();
		public static List<string> completedWordsSound = new List<string>();

		public static List<string> completedLevels = new List<string>();
		public static List<string> unlockedLevels = new List<string> ();

		public static int numLevels = 12;
		public static List<string> levelList = new List<string> ();

		public static string SetLevelOrder(int index)
		{
			if (index == 1)
				return "Animals";
			if (index == 2)
				return "Transportation";
			if (index == 3)
				return "Bathroom";
			if (index == 4)
				return "Kitchen";
			if (index == 5)
				return "Picnic";
			if (index == 6)
				return "Forest";
			if (index == 7)
				return "Bedroom";
			if (index == 8)
				return "School";
			if (index == 9)
				return "Playground";
			if (index == 10)
				return "Clothing";
			if (index == 11)
				return "Garden";
			if (index == 12)
				return "Camping";
			else
				return null;
		}

		public static void InitiateLevelList()
		{
			for (int i=1; i<=numLevels; i++) {
				string level = SetLevelOrder (i);
				levelList.Add (level + "1");
				levelList.Add (level + "2");
				levelList.Add (level + "3");
			}
		}

		public static void UnlockNextLevel(string level)
		{
			int index = -1;

			if (ProgressManager.currentMode == 1)
				index = levelList.IndexOf (level + "1");

			if (ProgressManager.currentMode == 2)
				index = levelList.IndexOf (level + "2");

			if (ProgressManager.currentMode == 3)
				index = levelList.IndexOf (level + "3");

			AddUnlockedLevel (levelList[index+1]);

		}



		public static void AddCompletedWord(string word)
		{
			if (Application.loadedLevelName == "4. Learn Spelling")
				completedWordsLearn.Add (word);
			
			if (Application.loadedLevelName == "5. Spelling Game")
				completedWordsSpell.Add (word);
			
			if (Application.loadedLevelName == "6. Sound Game")
				completedWordsSound.Add (word);
		}


		public static void AddCompletedLevel(string level)
		{
			if (ProgressManager.currentMode == 1)
				completedLevels.Add (level + "1");

			if (ProgressManager.currentMode == 2)
				completedLevels.Add (level + "2");

			if (ProgressManager.currentMode == 3)
				completedLevels.Add (level + "3");

		}

		public static void AddUnlockedLevel(string level)
		{
			if (unlockedLevels.Contains (level)) {
				int index = levelList.IndexOf (level);
				unlockedLevels.Add (levelList [index + 3]);
			}

			else 
				unlockedLevels.Add (level);
		}


		public static bool IsWordCompleted(string word)
		{
			if (ProgressManager.currentMode == 1) {
				if (completedWordsLearn.Contains (word))
					return true;
			}
			if (ProgressManager.currentMode == 2) {
				if (completedWordsSpell.Contains (word))
					return true;
			}
			if (ProgressManager.currentMode == 3) {
				if (completedWordsSound.Contains (word))
					return true;
			}
			return false;
			
		}

		public static bool IsLevelCompleted(string level)
		{
			if (completedLevels.Contains (level))
				return true;
			return false;
			
		}

		public static bool IsLevelUnlocked(string level)
		{
			if (unlockedLevels.Contains (level))
				return true;
			return false;
			
		}

		public static void UnlockAllLevels()
		{
			ProgressManager.unlockedLevels.Add ("Animals1");
			ProgressManager.unlockedLevels.Add ("Transportation1");
			ProgressManager.unlockedLevels.Add ("Bathroom1");
			ProgressManager.unlockedLevels.Add ("Kitchen1");
			ProgressManager.unlockedLevels.Add ("Picnic1");
			ProgressManager.unlockedLevels.Add ("Pond1");
			ProgressManager.unlockedLevels.Add ("Bedroom1");
			ProgressManager.unlockedLevels.Add ("School1");
			ProgressManager.unlockedLevels.Add ("Playground1");
			ProgressManager.unlockedLevels.Add ("Clothing1");
			ProgressManager.unlockedLevels.Add ("Garden1");
			ProgressManager.unlockedLevels.Add ("Camping1");
			
			ProgressManager.unlockedLevels.Add ("Animals2");
			ProgressManager.unlockedLevels.Add ("Transportation2");
			ProgressManager.unlockedLevels.Add ("Bathroom2");
			ProgressManager.unlockedLevels.Add ("Kitchen2");
			ProgressManager.unlockedLevels.Add ("Picnic2");
			ProgressManager.unlockedLevels.Add ("Pond2");
			ProgressManager.unlockedLevels.Add ("Bedroom2");
			ProgressManager.unlockedLevels.Add ("School2");
			ProgressManager.unlockedLevels.Add ("Playground2");
			ProgressManager.unlockedLevels.Add ("Clothing2");
			ProgressManager.unlockedLevels.Add ("Garden2");
			ProgressManager.unlockedLevels.Add ("Camping2");
			
			ProgressManager.unlockedLevels.Add ("Animals3");
			ProgressManager.unlockedLevels.Add ("Transportation3");
			ProgressManager.unlockedLevels.Add ("Bathroom3");
			ProgressManager.unlockedLevels.Add ("Kitchen3");
			ProgressManager.unlockedLevels.Add ("Picnic3");
			ProgressManager.unlockedLevels.Add ("Pond3");
			ProgressManager.unlockedLevels.Add ("Bedroom3");
			ProgressManager.unlockedLevels.Add ("School3");
			ProgressManager.unlockedLevels.Add ("Playground3");
			ProgressManager.unlockedLevels.Add ("Clothing3");
			ProgressManager.unlockedLevels.Add ("Garden3");
			ProgressManager.unlockedLevels.Add ("Camping3");
		}


	}
}
