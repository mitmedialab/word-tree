using UnityEngine;
using System.Collections;

//Manage audio events for sound-blending
namespace WordTree
{
	public class AudioManager : MonoBehaviour {


		static public float clipLength = .9f; //time allocated to play audio clip for each letter
		public float pulseLength = .15f; //time to complete single scale up
		public float scaleUp = 1.3f; //scale object up by this much, only for letters (not blanks)

		//Play audio for each letter of word one after another, then play audio for actual word
		//Supports words of length 3-5 letters
		public void SpellOutWord(GameObject[] gos)
		{
			
			PlaySoundAndPulseLetter (gos[0], 0);
			PlaySoundAndPulseLetter (gos[1], 1);
			PlaySoundAndPulseLetter (gos[2], 2);
			if (gos.Length >= 4)
				PlaySoundAndPulseLetter (gos[3], 3);
			if (gos.Length >= 5)
				PlaySoundAndPulseLetter (gos[4], 4);
			
			PlaySoundAndPulseWord (gos);
			
		}

		//Play audio clip for while pulsing the letter once
		//float index: order of the letter in the word
		void PlaySoundAndPulseLetter(GameObject go, float index)
		{
			//Check if object has audio clip attached
			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				//Delay playing audio clip for (index * clipLength) seconds
				go.audio.PlayDelayed (index*clipLength);  
			}

			//Wait for (index * clipLength) seconds before pulsing
			StartCoroutine(PulseLetter (go,index*clipLength));
		}

		//Play audio clip for while pulsing the word once
		void PlaySoundAndPulseWord(GameObject[] gos)
		{	
			//Check if word object has audio clip attached
			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");
			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				//Delay playing audio clip for (index * clipLength) seconds
				go.audio.PlayDelayed ((gos.Length) * clipLength);
			}

			//Wait for (gos.Length * clipLength) seconds before pulsing
			StartCoroutine (PulseWord (gos,(gos.Length)*clipLength));

		}

		//Pulse letter once, i.e. grow and then shrink the letter back to original size
		IEnumerator PulseLetter(GameObject go, float delayTime)
		{
			//Delay the pulsing by delayTime seconds
			yield return new WaitForSeconds (delayTime);

			//if object is a letter
			if (go.tag == "TargetLetter" || go.tag == "MovableLetter") {
				LeanTween.scale (go, new Vector3 (scaleUp * WordCreation.letterScale, scaleUp * WordCreation.letterScale, 1), pulseLength).setDelay (.2f);
				LeanTween.scale (go, new Vector3 (1f * WordCreation.letterScale, 1f * WordCreation.letterScale, 1), clipLength * .5f).setDelay (clipLength * .5f);
			}

			//if object is a rectangle blank
			if (go.tag == "TargetBlank") {
				//Set desired scale size of rectangle blank
				float xScale = .7f; // horizontal scale of rectangle blank
				float yScale = 1.5f; // vertical scale of rectangele blank

				//Scale up rectangle blank by 1.15 times its original size
				LeanTween.scale (go, new Vector3 (1.15f * xScale, 1.15f * yScale, 1), pulseLength).setDelay (.2f);
				//Scale down rectangle blank back to original size
				LeanTween.scale (go, new Vector3 (xScale, yScale, 1), clipLength * .5f).setDelay (clipLength * .5f);
			}
			Debug.Log ("Pulse on " + go.name);

		}

		//Pulse word once, i.e. grown and then shrink all the letters of the word at the same time
		IEnumerator PulseWord(GameObject[] gos, float delayTime)
		{	
			//Delay the pulsing by delayTime seconds
			yield return new WaitForSeconds (delayTime);

			//if object is a letter
			if (gos [0].tag == "TargetLetter" || gos [0].tag == "MovableLetter") {
				for (int i=0; i < gos.Length; i++) {
					LeanTween.scale (gos [i], new Vector3 (scaleUp * WordCreation.letterScale, scaleUp * WordCreation.letterScale, 1), pulseLength).setDelay(.2f);
					LeanTween.scale (gos [i], new Vector3 (1f * WordCreation.letterScale, 1f * WordCreation.letterScale, 1), clipLength * .5f).setDelay (clipLength * .5f);
				}
			}

			//if object is a rectangle blank
			if (gos [0].tag == "TargetBlank") {
				//Set desired scale size of rectangle blank
				float xScale = .7f; // horizontal scale of rectangle blank
				float yScale = 1.5f; // vertical scale of rectangle blank

				for (int i=0; i < gos.Length; i++) {
					//Scale up rectangle blank by 1.15 times its original size
					LeanTween.scale (gos [i], new Vector3 (1.15f * xScale, 1.15f * yScale, 1), pulseLength).setDelay (.2f);
					//Scale down rectangle blank back to original size
					LeanTween.scale (gos [i], new Vector3 (xScale, yScale, 1), clipLength * .5f).setDelay (clipLength * .5f);
				}
			}
			Debug.Log ("Pulse on word");
			
		}


	}
}
