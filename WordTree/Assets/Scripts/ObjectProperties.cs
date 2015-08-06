using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class ObjectProperties : ScriptableObject {

		private string objName;

		private string tag;

		private Vector3 initPosn;

		private Vector3 scale;

		private string sprite;

		private string audioFile;


		public void Init (string name, string tag, Vector3 posn, Vector3 scale, string sprite, string audioFile)
		{

			this.objName = name;

			this.tag = tag;

			this.initPosn = posn;

			this.scale = scale;

			this.sprite = sprite;

			this.audioFile = audioFile;

		}


		public static ObjectProperties CreateInstance(string name, string tag, Vector3 posn, Vector3 scale, string sprite, string audioFile)
		{
			ObjectProperties prop = ScriptableObject.CreateInstance<ObjectProperties> ();
			prop.Init (name, tag, posn, scale, sprite, audioFile);
			return prop;
		}

		public static void InstantiateObject (ObjectProperties prop)
		{
			GameObject go = new GameObject();
			
			go.name = prop.Name();
			
			Debug.Log ("Created new object " + go.name);
			
			go.tag = prop.Tag ();
			
			go.transform.position = prop.InitPosn ();
			
			go.transform.localScale = prop.Scale ();
			
			SpriteRenderer spriteRenderer = go.AddComponent<SpriteRenderer>();
			Sprite sprite = Resources.Load<Sprite>("Graphics/" + prop.Sprite ());
			if (sprite == null)
				Debug.Log("ERROR: could not load sprite " + prop.Name ());
			spriteRenderer.sprite = sprite;
			
			if (prop.AudioFile() != null)
			{
				AudioSource audioSource = go.AddComponent<AudioSource>();
				AudioClip clip = Resources.Load("Audio/" + prop.AudioFile ()) as AudioClip;
				if (clip == null)
					Debug.Log ("ERROR: could not load audioclip " + prop.AudioFile ());
				audioSource.clip = clip;
				audioSource.playOnAwake = false;
			}

			if (go.tag != "TargetLetter" && go.tag != "TargetBlank" && go.tag != "Jar") 
			{
				go.AddComponent<PolygonCollider2D> ();
			}

			if (go.tag == "TargetLetter" || go.tag == "TargetBlank")
			{
				CircleCollider2D cc2d = go.AddComponent<CircleCollider2D>();
				cc2d.isTrigger = true;
				if (go.tag == "TargetLetter"){
					if (ProgressManager.currentMode == 1)
						cc2d.radius = .1f;
					if (ProgressManager.currentMode == 3)
						cc2d.radius = 3f;
				}
				if (go.tag == "TargetBlank")
					cc2d.radius = .3f;
			}

			if (go.tag == "Jar") {
				CircleCollider2D cc2d = go.AddComponent<CircleCollider2D> ();
				cc2d.radius = .5f;
			}
			
			if (go.tag == "MovableLetter" || go.tag == "MovableBlank")
			{
				Rigidbody2D rb2d = go.AddComponent<Rigidbody2D>();
				rb2d.isKinematic = true;
				rb2d.gravityScale = 0;
			}
	
			GestureManager gm = go.AddComponent<GestureManager> ();
			gm.AddAndSubscribeToGestures (go); 

			go.AddComponent<PulseBehavior> ();


			if (go.tag == "Hint") 
			{
				go.GetComponent<SpriteRenderer>().color = Color.black;
				go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 3);
			}
				
			
		}


		public string Name()
		{
			return this.objName;
		}

		public string Tag()
		{
			return this.tag;
		}

		public Vector3 InitPosn()
		{
			return this.initPosn;
		}

		public Vector3 Scale()
		{
			return this.scale;
		}

		public string Sprite()
		{
			return this.sprite;
		}

		public string AudioFile()
		{
			return this.audioFile;
		}


	}
}
