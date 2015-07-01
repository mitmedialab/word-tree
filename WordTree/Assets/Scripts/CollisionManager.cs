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
				Debug.Log ("Collision occurred");

				PanGesture pg = other.GetComponent<PanGesture>();
				if (pg != null){
					pg.enabled = false;
					Debug.Log ("Pan disabled for" + other.name);
				}

				other.transform.position = gameObject.transform.position;


			}
		}
		
	}
}