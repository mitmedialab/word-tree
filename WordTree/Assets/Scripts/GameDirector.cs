using UnityEngine;
using System.Collections;


namespace WordTree
{

	public class GameDirector : MonoBehaviour {


		void Awake () {

		}

		void Start () {

			LevelProperties.CreateLevel ("Fruits",new string[] {"Apple","Banana","Orange","Grape"},new float[,]{{.8f,.8f},{1,1},{1,1},{1,1}},4);
			WordProperties.CreateWord (new string[] {"A","P","P","L","E"},new string[] {"A-long","P","P","LE","LE"},"MovableLetter",5);


		}

		void Update () {
		
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
					Debug.Log ("ERROR: could not load audioclip" + prop.AudioFile ());
				audioSource.clip = clip;
				audioSource.playOnAwake = false;
			}

			PolygonCollider2D pc2d = go.AddComponent<PolygonCollider2D>();
			if (go.tag == "TargetLetter")
				pc2d.isTrigger = true;

			if (go.tag == "MovableLetter")
			{
				Rigidbody2D rb2d = go.AddComponent<Rigidbody2D>();
				rb2d.isKinematic = true;
				rb2d.gravityScale = 0;
			}

			if (go.tag == "TargetLetter") 
			{
				CollisionManager cm = go.AddComponent<CollisionManager> ();
			}


			if (go.tag == "WordObject" || go.tag == "MovableLetter") 
			{	
				GestureManager gm = go.AddComponent<GestureManager> ();
				gm.AddAndSubscribeToGestures (go); 

				PulseBehavior pb = go.AddComponent<PulseBehavior> ();
			}


		}



	}
}