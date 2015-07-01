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
				SpriteRenderer sprite = other.GetComponent<SpriteRenderer> ();
				sprite.color = Color.gray;
				Debug.Log ("Collision on " + other.name);

				PanGesture pg = other.GetComponent<PanGesture>();
				pg.enabled = false;
				Debug.Log ("Disabled touch for " + other.name);
		

				other.transform.position = gameObject.transform.position;

			}
		}
		
	}
}