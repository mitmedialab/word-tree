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

			case "Apple":
				return CreateInstance(new string[] {"A","P","P","L","E"}, 1f);
				
			case "Banana":
				
				return CreateInstance(new string[] {"B","A","N","A","N","A"}, 1f);
				
			case "Cherry":
				
				return CreateInstance(new string[] {"C","H","E","R","R","Y"}, 1f);
				
			case "Grape":
				
				return CreateInstance(new string[] {"G","R","A","P","E"}, 1f);
				
			case "Orange":
				
				return CreateInstance(new string[] {"O","R","A","N","G","E"}, 1f);
							
			default:

				return null;

			}
		}

	}
}
