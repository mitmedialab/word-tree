using UnityEngine;
using System.Collections;

//<summary>
//Manages audio events for sound-blending
//Works for words with 3-5 letters
//<//summary>
namespace WordTree
{
	public class AudioManager : MonoBehaviour
	{
		//time allocated to play audio clip for each letter
		static public float clipLength = .9f;
		//time to scale up object once
		public float pulseLength = .15f;
		//how much to scale up object by
		public float scaleUp = 1.3f;
		//<summary>
		//Play each letter's sound and pulse it, then do same for entire word
		//</summary>
		public void SpellOutWord(GameObject[] gos)
		{
			PlaySoundAndPulseLetter(gos[0], 0);
			PlaySoundAndPulseLetter(gos[1], 1);
			PlaySoundAndPulseLetter(gos[2], 2);
			if (gos.Length >= 4) 
			{
				PlaySoundAndPulseLetter(gos[3], 3);
			}
			if (gos.Length >= 5) 
			{
				PlaySoundAndPulseLetter(gos[4], 4);
			}
			PlaySoundAndPulseWord(gos);	
		}

		//<summary>
		//Play audio clip for while pulsing the letter once
		//float index: order/position of the letter in the word
		//Synchronizes the pulse and sound for each letter
		//</summary>
		void PlaySoundAndPulseLetter(GameObject go, int index)
		{
			//find word, the letters are part of
			GameObject word = GameObject.FindGameObjectWithTag(Constants.Tags.TAG_WORD_OBJECT);
			if (word != null) 
			{
				//get the phonemes for the word in the scene
				WordProperties prop = WordProperties.GetWordProperties(word.transform.name);
				if (prop != null) 
				{
					// phonemes in word
					string[] phonemes = prop.Phonemes(); 
					//create an audio source
					AudioSource audioSource = gameObject.AddComponent<AudioSource>();
					//load and play audio file attached to the letters
					string file = "Audio" + "/Phonemes/" + phonemes[index];
					audioSource.clip = Resources.Load(file) as AudioClip;
					if (audioSource != null) 
					{
						audioSource.PlayDelayed(index * clipLength);  
						StartCoroutine(PulseLetter(go, index * clipLength));
					} 
					else 
					{
						Debug.LogWarning("Cannot find" + file + " audio component");
					}
				} 
				else 
				{
					Debug.LogError("Cannot find" + prop.name + "properties component" );
				}
			}
			else
			{
				Debug.LogError("Cannot find" + word.name + " in scene");
			}
		}

		//<summary>
		//Play audio clip for while pulsing the word once
		//Synchronizes the pulse and sound for the word
		//</summary>
		void PlaySoundAndPulseWord(GameObject[] gos)
		{	
			// get properties of current word in game
			GameObject word = GameObject.FindGameObjectWithTag(Constants.Tags.TAG_WORD_OBJECT);
			//check if word is null
			if (word != null) 
			{
				//create audio source for the word
				AudioSource audioSource = gameObject.AddComponent<AudioSource>();
				//load and play the audio file attached to the word
				string file = "Audio" + "/Words/" + word.name;
				audioSource.clip = Resources.Load(file) as AudioClip;
				if (audioSource.clip != null) 
				{
					audioSource.PlayDelayed((gos.Length) * clipLength);
				} 
				else 
				{
					Debug.LogWarning("Cannot load " + file + " for game object " + gameObject.name);
				}
				
			} 
			else 
			{
				Debug.LogError("Cannot find the word in the scene");
			}
			//Wait for all letters to complete before pulsing
			StartCoroutine(PulseWord(gos, (gos.Length) * clipLength));
		}

		//<summary>
		//Pulse letter once, i.e. grow and then shrink the letter back to original size
		//</summary>
		IEnumerator PulseLetter(GameObject go, float delayTime)
		{
			//Wait for specified seconds, want to time it so that letter pulses right after previous letter finishes
			yield return new WaitForSeconds(delayTime);

			//if object is a letter
			if (go.tag == Constants.Tags.TAG_TARGET_LETTER || 
					go.tag == Constants.Tags.TAG_MOVABLE_LETTER)
			{
				// scale up letter
				LeanTween.scale(go, new Vector3(scaleUp * WordCreation.letterScale, 
					scaleUp * WordCreation.letterScale, 1), pulseLength).setDelay(.2f);
				// then scale down letter back to original size
				LeanTween.scale(go, new Vector3(1f * WordCreation.letterScale, 
					1f * WordCreation.letterScale, 1), clipLength * .5f).setDelay(clipLength * .5f);
			}
			//if object is a blank
			if (go.tag == Constants.Tags.TAG_TARGET_BLANK) 
			{
				//Set desired initial (default) scale of blank
				float xScale = .7f; // horizontal scale of blank
				float yScale = 1.5f; // vertical scale of blank
				//Scale up blank
				LeanTween.scale(go, new Vector3(1.15f * xScale, 1.15f * yScale, 1),
					pulseLength).setDelay(.2f);
				//Then scale down blank back to original size
				LeanTween.scale(go, new Vector3(xScale, yScale, 1), clipLength * 
					.5f).setDelay(clipLength * .5f);
			}
			Debug.Log("Pulse on " + go.name);
		}

		//<summary>
		//Pulse word once, i.e. grown and then shrink all the letters of the word at the same time
		//</summary>
		IEnumerator PulseWord(GameObject[] gos, float delayTime)
		{	
			//Wait for pulsing of all letters to complete
			yield return new WaitForSeconds(delayTime);
			//if object is a letter
			if (gos[0].tag == Constants.Tags.TAG_TARGET_LETTER || 
				gos[0].tag == Constants.Tags.TAG_MOVABLE_LETTER) 
			{
				for (int i = 0; i < gos.Length; i++) 
				{
					// scale up letter
					LeanTween.scale(gos[i], new Vector3(scaleUp * WordCreation.letterScale,
						scaleUp * WordCreation.letterScale, 1), pulseLength).setDelay(.2f);
					// then scale down letter to original size
					LeanTween.scale(gos[i], new Vector3(1f * WordCreation.letterScale, 
						1f * WordCreation.letterScale, 1), clipLength * .5f).setDelay(clipLength * .5f);
				}
			}
			//if object is a blank
			if (gos[0].tag == Constants.Tags.TAG_TARGET_BLANK) 
			{
				//Set desired initial (default) scale of blank
				float xScale = .7f; // horizontal scale of blank
				float yScale = 1.5f; // vertical scale of blank
				for (int i = 0; i < gos.Length; i++) 
				{
					//Scale up blank
					LeanTween.scale(gos[i], new Vector3(1.15f * xScale, 1.15f * yScale, 1),
						pulseLength).setDelay(.2f);
					//Then scale down blank back to original size
					LeanTween.scale(gos[i], new Vector3(xScale, yScale, 1), clipLength
						* .5f).setDelay(clipLength * .5f);
				}
			}
			Debug.Log("Pulse on word");	
		}
			
	}
}
