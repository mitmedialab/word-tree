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

			if (Application.loadedLevelName == "4. Spell Word") {

				if (other.name == gameObject.name) {

					Debug.Log ("Collision on " + other.name);

					gameObject.GetComponent<SpriteRenderer> ().color = other.GetComponent<SpriteRenderer> ().color;
					Color color = gameObject.renderer.material.color;
					color.a = 1.0f;
					gameObject.renderer.material.color = color;

					Debug.Log ("Destroyed draggable letter " + other.gameObject.name);
					Destroy (other.gameObject);

					DisableCollisions (gameObject);

					if (CheckCompletedWord ()) {
						GameObject SpellWordDirector = GameObject.Find ("SpellWordDirector");
						SpellWordDirector swd = SpellWordDirector.GetComponent<SpellWordDirector> ();
						swd.SpellOutWord ();

						AddCompletedWord (GameDirector.currentWord);

					}

				}
			}

			if (Application.loadedLevelName == "5. Spelling Game") {

				Debug.Log ("Collision on " + other.name);

				other.gameObject.GetComponent<GestureManager>().DisableGestures(other.gameObject);

				other.gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-1);



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