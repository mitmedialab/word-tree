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

		public bool allowTouch = true;

		private void OnEnable () {
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("PlayObject");
			foreach (GameObject go in gos) {
				AddAndSubscribeToGestures (go, true);

				StartPulsing(go);

				}
			}

		private void OnDestroy () {
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("PlayObject");
			foreach (GameObject go in gos) {
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
		}

		public void AddAndSubscribeToGestures (GameObject go, bool draggable)
		{
			TapGesture tg = go.GetComponent<TapGesture>();
		
			if(tg != null) {
				tg.Tapped += tappedHandler;
				Debug.Log(go.name + " subscribed to tap events");
			}

			if (draggable) {
				PanGesture pg = go.GetComponent<PanGesture> ();

				if (pg != null) {
					pg.CombineTouchesInterval = 0.2f;
					pg.PanStarted += panStartedHandler;
					pg.Panned += pannedHandler;
					pg.PanCompleted += panCompleteHandler;
					Debug.Log (go.name + " subscribed to pan events");
				}
			}

			PressGesture prg = go.GetComponent<PressGesture> ();

			if (prg != null) {
				prg.Pressed += pressedHandler;
				Debug.Log (go.name + " subscribed to press events");
			}

			ReleaseGesture rg = go.GetComponent<ReleaseGesture> ();

			if (rg != null) {
				rg.Released += releasedHandler;
				Debug.Log (go.name + " subscribed to release events");
			}


		}

		private void tappedHandler (object sender, EventArgs e)
		{
			TapGesture gesture = sender as TapGesture;
			ITouchHit hit;

			if (gesture.GetTargetHitResult (out hit)) { 
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("TAP registered on " + gesture.gameObject.name + " at " + hit2d.Point);
			}


			Debug.Log ("Loading next scene");
			Application.LoadLevel (gesture.gameObject.name);

		}

		private void pressedHandler (object sender, EventArgs e)
		{
			PressGesture gesture = sender as PressGesture;
			ITouchHit hit;

			if (gesture.GetTargetHitResult (out hit)) {
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("PRESS on " + gesture.gameObject.name + " at " + hit2d.Point);
			}

			if(this.allowTouch)

			Debug.Log("going to play a sound for " + gesture.gameObject.name);
			if(this.allowTouch) 
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
				if (this.allowTouch) {
					gesture.gameObject.transform.position = hit2d.Point;
				}
			
			}

		}

		private void panCompleteHandler (object sender, EventArgs e)
		{
			Debug.Log("PAN COMPLETE");
			      
		}




		private bool PlaySound (GameObject go)
		{ 
			AudioSource auds = go.GetComponent<AudioSource>();
			if(auds != null && auds.clip != null) {
				Debug.Log("playing clip for object " + go.name);

				if(!go.audio.isPlaying)
					go.audio.Play();
				
				return true;   
			} else {
				Debug.Log("no sound found for " + go.name + "!");
				return false;
			}
		}


		public void StartPulsing (GameObject go)
		{
			float scaleUpBy = 1.1f; 

			LeanTween.scale(go, new Vector3(go.transform.localScale.x * scaleUpBy, go.transform.localScale.y * scaleUpBy, 
			                                        go.transform.localScale.z * scaleUpBy), 1.0f)
				.setEase(LeanTweenType.easeOutSine).setLoopPingPong();
		}

		
		
	}
}
