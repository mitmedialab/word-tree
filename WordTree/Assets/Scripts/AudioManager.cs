using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class AudioManager : MonoBehaviour {

		static public float clipLength = .7f;
		public float pulseLength = .1f;
		public float scaleUp = 1.3f;


		public void SpellOutWord(GameObject[] gos)
		{
			
			PlaySoundAndPulseLetter (gos[0], 0);
			PlaySoundAndPulseLetter (gos[1], 1);
			PlaySoundAndPulseLetter (gos[2], 2);
			if (gos.Length >= 4)
				PlaySoundAndPulseLetter (gos[3], 3);
			if (gos.Length >= 5)
				PlaySoundAndPulseLetter (gos[4], 4);
			if (gos.Length >= 6)
				PlaySoundAndPulseLetter (gos[5], 5);
			
			PlaySoundAndPulseWord (gos);
			
		}
		
		void PlaySoundAndPulseLetter(GameObject go, float index)
		{
			
			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				go.audio.PlayDelayed (index*clipLength);  
			}
			
			StartCoroutine(PulseLetter (go,index*clipLength));
		}
		
		void PlaySoundAndPulseWord(GameObject[] gos)
		{
			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");
			if (go.audio != null && go.audio.clip != null) {
				Debug.Log ("Playing clip for " + go.name);
				go.audio.PlayDelayed ((gos.Length) * clipLength);
			}
			
			StartCoroutine (PulseWord (gos,(gos.Length)*clipLength));

		}

		
		IEnumerator PulseLetter(GameObject go, float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			if (go.tag == "TargetLetter" || go.tag == "MovableLetter") {
				LeanTween.scale (go, new Vector3 (scaleUp * WordCreation.letterScale, scaleUp * WordCreation.letterScale, 1), pulseLength);
				LeanTween.scale (go, new Vector3 (1f * WordCreation.letterScale, 1f * WordCreation.letterScale, 1), clipLength * .5f).setDelay (clipLength * .5f - .1f);
			}

			if (go.tag == "TargetBlank") {
				LeanTween.scale (go, new Vector3 (1.1f * .2f, 1.1f * .3f, 1), pulseLength);
				LeanTween.scale (go, new Vector3 (.2f, .3f, 1), clipLength * .5f).setDelay (clipLength * .5f - .1f);
			}
			Debug.Log ("Pulse on " + go.name);

		}

		IEnumerator PulseWord(GameObject[] gos, float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			if (gos [0].tag == "TargetLetter" || gos [0].tag == "MovableLetter") {
				for (int i=0; i < gos.Length; i++) {
					LeanTween.scale (gos [i], new Vector3 (scaleUp * WordCreation.letterScale, scaleUp * WordCreation.letterScale, 1), pulseLength);
					LeanTween.scale (gos [i], new Vector3 (1f * WordCreation.letterScale, 1f * WordCreation.letterScale, 1), clipLength * .5f).setDelay (clipLength * .5f - .1f);
				}
			}

			if (gos [0].tag == "TargetBlank") {
				for (int i=0; i < gos.Length; i++) {
					LeanTween.scale (gos [i], new Vector3 (1.1f * .2f, 1.1f * .3f, 1), pulseLength);
					LeanTween.scale (gos [i], new Vector3 (.2f, .3f, 1), clipLength * .5f).setDelay (clipLength * .5f - .1f);
				}
			}
			Debug.Log ("Pulse on word");
			
		}


	}
}
