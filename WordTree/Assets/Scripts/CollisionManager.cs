using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;
using TouchScript.Behaviors;
using TouchScript.Hit;


namespace WordTree
{
	public class CollisionManager : MonoBehaviour {


		
		void OnTriggerEnter2D (Collider2D other)
		{

			if (other.name == gameObject.name) {
			

				Debug.Log ("Collision on " + other.name);

				gameObject.GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
				Color color = gameObject.renderer.material.color;
				color.a = 1.0f;
				gameObject.renderer.material.color = color;

				Debug.Log ("Destroyed draggable letter " + other.gameObject.name);
				Destroy (other.gameObject);

				DisableCollisions(gameObject);

				if (CheckCompletedWord ()) {
					GameObject SpellWordDirector = GameObject.Find("SpellWordDirector");
					SpellWordDirector swd = SpellWordDirector.GetComponent<SpellWordDirector>();
					swd.SpellOutWord();

					AddCompletedWord(GameDirector.currentWord);

				}

			}

		}


		bool CheckCompletedWord ()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("MovableLetter");
			Debug.Log ("Letters left: " + (gos.Length-1));

			if (gos.Length == 1) {
				Debug.Log ("Word Completed: " + GameDirector.currentWord);
				return true;
			}

			return false;

		}

		public static void AddCompletedWord(string word)
		{
			GameDirector.completedWords.Add (word);
		}

		void DisableCollisions(GameObject go)
		{
			Destroy (go.GetComponent<CollisionManager>());
			Debug.Log ("Disabled Collisions for " + go.name);
		}



	}
	
}