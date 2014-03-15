using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	public static LevelEnd levelEnd;

	public float loadTime;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () { }

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			EndLevel();
		}
	}


	void OnTriggerStay(Collider other) {
		if(other.CompareTag("Player")) {
			Invoke("LoadNextLevel", loadTime);
		}
	}

	void EndLevel() {
		//close the exit room door

		//stop the timer
	}

	//<remarks>can be called by ObjectInteraction class</remarks>
	public void LoadNextLevel(){
		Application.LoadLevel((Application.loadedLevel) + 1);
	}
}
