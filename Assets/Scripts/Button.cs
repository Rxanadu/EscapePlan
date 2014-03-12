using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Button : MonoBehaviour {
	public void ClickButton(){
		//indicate that button has been pressed visually

		//play sound
		if(!audio.isPlaying&&audio.clip!=null){
			audio.PlayOneShot (audio.clip);
		}
	}
}
