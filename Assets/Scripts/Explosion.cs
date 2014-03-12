using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour {

	public AudioClip[] explosionSounds;
	public float timeLimit;
	
	// Use this for initialization
	void Start () {
		audio.PlayOneShot (explosionSounds[Random.Range (0,explosionSounds.Length)]);
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying){
			Destroy (gameObject, timeLimit);
		}
	}
}
