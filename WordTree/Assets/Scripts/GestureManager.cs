using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;
using TouchScript.Behaviors;
using TouchScript.Hit;

namespace WordTree
{
	public class GestureManager : MonoBehaviour {


		public void AddAndSubscribeToGestures (GameObject go)
		{
			if (go.tag == "WordObject") {

				TapGesture tg = go.AddComponent<TapGesture> ();
				tg.Tapped += tappedHandler;
				Debug.Log (go.name + " subscribed to tap events");
			}

			if (go.tag == "MovableLetter") {

				PanGesture pg = go.AddComponent<PanGesture> ();
				pg.CombineTouchesInterval = 0.2f;
				pg.PanStarted += panStartedHandler;
				pg.Panned += pannedHandler;
				pg.PanCompleted += panCompleteHandler;
				Debug.Log (go.name + " subscribed to pan events");

				PressGesture prg = go.AddComponent<PressGesture> ();
				prg.Pressed += pressedHandler;
				Debug.Log (go.name + " subscribed to press events");

				ReleaseGesture rg = go.AddComponent<ReleaseGesture> ();
				rg.Released += releasedHandler;
				Debug.Log (go.name + " subscribed to release events");

				Transformer2D t2d = go.AddComponent<Transformer2D>();

			}
		}

		public void UnsubscribeFromGestures (GameObject go)
		{
			TapGesture tg = go.GetComponent<TapGesture> ();
			if (tg != null) {
				tg.Tapped -= tappedHandler;
				Debug.Log (go.name + " unsubscribed from tap events");
			}
			PanGesture pg = go.GetComponent<PanGesture> ();
			if (pg != null) {
				pg.Panned -= pannedHandler;
				pg.PanCompleted -= panCompleteHandler;
				pg.PanStarted -= panStartedHandler;
				Debug.Log (go.name + " unsubscribed from pan events");
			}
			PressGesture prg = go.GetComponent<PressGesture> ();
			if (prg != null) {
				prg.Pressed -= pressedHandler;
				Debug.Log (go.name + " unsubscribed from press events");
			}
			ReleaseGesture rg = go.GetComponent<ReleaseGesture> ();
			if (rg != null) {
				rg.Released -= releasedHandler;
				Debug.Log (go.name + " unsubscribed from release events");
			}
		}

		public void DisableGestures (GameObject go)
		{
			TapGesture tg = go.GetComponent<TapGesture> ();
			if (tg != null) {
				tg.enabled = false;
			}
			PanGesture pg = go.GetComponent<PanGesture> ();
			if (pg != null) {
				pg.enabled = false;
			}
			PressGesture prg = go.GetComponent<PressGesture> ();
			if (prg != null) {
				prg.enabled = false;
			}
			ReleaseGesture rg = go.GetComponent<ReleaseGesture> ();
			if (rg != null) {
				rg.enabled = false;
			}
		}


		private void tappedHandler (object sender, EventArgs e)
		{
			TapGesture gesture = sender as TapGesture;
			ITouchHit hit;

			if (gesture.GetTargetHitResult (out hit)) { 
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("TAP on " + gesture.gameObject.name + " at " + hit2d.Point);
			}

			if (gesture.gameObject.tag == "LevelSymbol")
				Application.LoadLevel ("3. Choose Word");
			if (gesture.gameObject.tag == "WordObject")
				Application.LoadLevel ("4. Spell Word");


		}

		private void pressedHandler (object sender, EventArgs e)
		{
			PressGesture gesture = sender as PressGesture;
			ITouchHit hit;

			if (gesture.GetTargetHitResult (out hit)) {
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("PRESS on " + gesture.gameObject.name + " at " + hit2d.Point);
			}

			PlaySound(gesture.gameObject);
		}
		
		private void releasedHandler (object sender, EventArgs e)
		{
			Debug.Log ("PRESS COMPLETE");

		}
			
		private void panStartedHandler (object sender, EventArgs e)
		{
			PanGesture gesture = sender as PanGesture;
			ITouchHit hit;

			if (gesture.GetTargetHitResult (out hit)) {
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("PAN STARTED on " + gesture.gameObject.name + " at " + hit2d.Point);
			
			}

		}

		private void pannedHandler (object sender, EventArgs e)
		{
			PanGesture gesture = sender as PanGesture;
			ITouchHit hit;
			
			if (gesture.GetTargetHitResult (out hit)) {
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("PAN on " + gesture.gameObject.name + " at " + hit2d.Point);

				gesture.gameObject.transform.position = hit2d.Point;

			
			}

		}

		private void panCompleteHandler (object sender, EventArgs e)
		{
			Debug.Log("PAN COMPLETE");
			      
		}


		public void PlaySound (GameObject go)
		{ 
			AudioSource auds = go.GetComponent<AudioSource>();
			if (auds != null && auds.clip != null) {
				Debug.Log("Playing clip for " + go.name);
				go.audio.Play ();  
			} 
			else {
				Debug.Log ("No clip found for " + go.name);
			}
		}

		
		
	}
}
