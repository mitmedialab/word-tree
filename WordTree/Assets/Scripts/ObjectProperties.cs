using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class ObjectProperties : ScriptableObject {

		private string name;

		private string tag;

		private Vector3 initPosn;

		private Vector3 scale;

		private string sprite;

		private string audioFile;


		public void Init (string name, string tag, Vector3 posn, Vector3 scale, string sprite, string audioFile)
		{

			this.name = name;

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


		public string Name()
		{
			return this.name;
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
