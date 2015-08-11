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
			if (go.tag == "LevelIcon" || go.tag == "WordObject" || go.tag == "Button" || go.tag == "Kid") {

				TapGesture tg = go.AddComponent<TapGesture> ();
				tg.Tapped += tappedHandler;
				Debug.Log (go.name + " subscribed to tap events");
			}

			if (go.tag == "MovableLetter" || go.tag == "MovableBlank") {

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

				go.AddComponent<Transformer2D>();

			}

			if (go.tag == "TargetLetter" || go.tag == "TargetBlank") {

				PressGesture prg = go.AddComponent<PressGesture> ();
				prg.Pressed += pressedHandler;
				Debug.Log (go.name + " subscribed to press events");
			}
		}

		public void EnableGestures (GameObject go)
		{
			TapGesture tg = go.GetComponent<TapGesture> ();
			if (tg != null) {
				tg.enabled = true;
			}
			PanGesture pg = go.GetComponent<PanGesture> ();
			if (pg != null) {
				pg.enabled = true;
			}
			PressGesture prg = go.GetComponent<PressGesture> ();
			if (prg != null) {
				prg.enabled = true;
			}
			ReleaseGesture rg = go.GetComponent<ReleaseGesture> ();
			if (rg != null) {
				rg.enabled = true;
			}
			
			Debug.Log ("Enabled gestures for " + go.name);
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

			Debug.Log ("Disabled gestures for " + go.name);
		}


		private void tappedHandler (object sender, EventArgs e)
		{
			TapGesture gesture = sender as TapGesture;
			ITouchHit hit;
			GameObject go = gesture.gameObject;

			if (gesture.GetTargetHitResult (out hit)) { 
				ITouchHit2D hit2d = (ITouchHit2D)hit; 
				Debug.Log ("TAP on " + gesture.gameObject.name + " at " + hit2d.Point);
			}

			if (go.tag == "Kid") {
				go.GetComponent<PulseBehavior>().StopPulsing(go);
				BounceKid(go);
				go.AddComponent<AudioSource>().clip = Resources.Load ("Audio/Intro") as AudioClip;
				if (go.audio.clip != null)
					go.audio.Play ();

				ProgressManager.chosenKid = go.name;
				StartCoroutine(LoadLevel ("2. Word Tree",2.5f));
			}

			if (go.tag == "LevelIcon") {
				ShrinkKid(go.transform.position);

				ProgressManager.currentLevel = go.name.Substring(0,go.name.Length-1);
				StartCoroutine(LoadLevel ("3. Choose Object",1f));
			}

			if (go.name.Substring(go.name.Length-1).Equals ("1"))
				ProgressManager.currentMode = 1;

			if (go.name.Substring(go.name.Length-1).Equals ("2"))
				ProgressManager.currentMode = 2;

			if (go.name.Substring(go.name.Length-1).Equals ("3"))
				ProgressManager.currentMode = 3;

			if (go.tag == "WordObject" && Application.loadedLevelName == "3. Choose Object") {
				if (ProgressManager.currentMode == 1)
					Application.LoadLevel ("4. Learn Spelling");
				if (ProgressManager.currentMode == 2)
					Application.LoadLevel ("5. Spelling Game");
				if (ProgressManager.currentMode == 3)
					Application.LoadLevel ("6. Sound Game");
				ProgressManager.currentWord = gesture.gameObject.name;
			}

			if (go.tag == "WordObject" && Application.loadedLevelName != "3. Choose Object")
				go.audio.Play ();

			if (go.name == "HomeButton") {
				ShrinkKid(go.transform.position);

				StartCoroutine(LoadLevel ("2. Word Tree",1f));
			}

			if (go.name == "BackButton")
				Application.LoadLevel ("3. Choose Object");

			if (go.name == "SoundButton")
				GameObject.FindGameObjectWithTag ("WordObject").audio.Play ();

			if (go.name == "HintButton") {
				if (Application.loadedLevelName == "5. Spelling Game")
					CollisionManager.ShowLetterHint ();
				if (Application.loadedLevelName == "6. Sound Game")
					CollisionManager.ShowSoundHint ();
			}




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

			if (Application.loadedLevelName == "5. Spelling Game") {
				CollisionManager.EnableCollisions(gesture.gameObject,"TargetBlank");
			}

			if (Application.loadedLevelName == "6. Sound Game") {
				CollisionManager.EnableCollisions(gesture.gameObject,"TargetLetter");
			}
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

				gesture.gameObject.transform.position = new Vector3(hit2d.Point.x,hit2d.Point.y,-2);

			
			}

		}

		private void panCompleteHandler (object sender, EventArgs e)
		{
			Debug.Log("PAN COMPLETE");
			      
		}

		IEnumerator LoadLevel (string level, float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			Application.LoadLevel (level);
		}

		void ShrinkKid(Vector3 posn)
		{
			GameObject kid = GameObject.FindGameObjectWithTag ("Kid");

			LeanTween.rotateAround (kid, Vector3.forward, 360f, 1f);
			LeanTween.scale (kid, new Vector3 (.1f, .1f, 1f), 1f);
			LeanTween.move (kid, posn, 1f);
			LeanTween.alpha (kid, 0f, .1f).setDelay (.9f);

			kid.AddComponent<AudioSource> ().clip = Resources.Load ("Audio/TumbleSound") as AudioClip;
			if (kid.audio.clip != null)
				kid.audio.Play ();
		}

		void BounceKid(GameObject kid)
		{
			float time = .5f;

			LeanTween.moveY (kid, 0, time);
			LeanTween.moveY (kid, -1.5f, time).setDelay (time);
			LeanTween.moveY (kid, 0, time).setDelay (2*time);
			LeanTween.moveY (kid, -1.5f, time).setDelay(3*time);

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
