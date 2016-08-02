using UnityEngine;
using System.Collections;

//<summary>
//Keep list of names for tags
//</summary>
namespace WordTree
{
	public class Constants : MonoBehaviour
	{
		//<summary>
		//Names for tags of gameObjects
		//</summary>
		public static class Tags
		{
			public const string TAG_MAIN_CAMERA = "MainCamera";
			public const string TAG_LOCK = "Lock";
			public const string TAG_KID = "Kid";
			public const string TAG_GESTURE_MANAGER = "GestureManager";
			public const string TAG_BUTTON = "Button";
			public const string TAG_LEVEL_ICON = "LevelIcon";
			public const string TAG_WORD_OBJECT = "WordObject";
			public const string TAG_TARGET_LETTER = "TargetLetter";
			public const string TAG_MOVABLE_LETTER = "MovableLetter";
			public const string TAG_TARGET_BLANK = "TargetBlank";
			public const string TAG_MOVABLE_BLANK = "MovableBlank";
			public const string TAG_JAR = "Jar";
			public const string TAG_HINT = "Hint";
			public const string TAG_AUDIO_MANAGER = "AudioManager";
		}

		//<summary>
		//Names of folders
		//</summary>
		public static class Filenames
		{
			public const string PHONEME = AUDIO + "Phonemes/";
			public const string AUDIO = "Audio/";
			public const string WORD =AUDIO + "Words/";
			public const string INCORRECT = AUDIO + "IncorrectSound";
			public const string CONGRATS = AUDIO + "CongratsSound";
			public const string BACKGROUND_MUSIC = AUDIO +"BackgroundMusic/";
			public const string WORD_TREE =  BACKGROUND_MUSIC + "WordTree";
			public const string KID_SPEAKING = AUDIO + "KidSpeaking/";
			public const string INTRO =  AUDIO + "KidSpeaking/Intro";
			public const string TUMBLE = AUDIO +"TumbleSound";
		}
	}
}
