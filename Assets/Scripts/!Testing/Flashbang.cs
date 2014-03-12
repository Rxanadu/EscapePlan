using UnityEngine;
using System.Collections;

public class Flashbang : MonoBehaviour {
	public GUITexture flashbangPrefab;
	public float fadeRate;
	public float fadeDelay;

	GUITexture flashbangTexture;
	Color alphaFullColor, alphaNoneColor;

	void Start(){
		flashbangTexture = Instantiate (flashbangPrefab) as GUITexture;
		alphaFullColor= new Color(flashbangPrefab.color.r, flashbangPrefab.color.g,
		                          flashbangPrefab.color.b,flashbangPrefab.color.a);
		alphaNoneColor= new Color(flashbangPrefab.color.r, flashbangPrefab.color.g,
		                          flashbangPrefab.color.b,0);
	}

	void Update(){
		Invoke ("FadeFlashbangTexture", fadeDelay);
	}

	void FadeFlashbangTexture(){
		float fadeStep = fadeRate*Time.deltaTime;
		flashbangTexture.color = Color.Lerp (flashbangTexture.color, alphaNoneColor, fadeStep);
		print ("Flashbang color: "+flashbangTexture.color);

		if(flashbangTexture.color.a<=.05){
			flashbangTexture.color=alphaNoneColor;
		}
	}
}
