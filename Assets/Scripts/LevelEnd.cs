using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	public static LevelEnd levelEnd;

	public float loadTime;

	GameObject endDoor;

	// Use this for initialization
	void Awake (){
		levelEnd=this;
		
		endDoor = EndRoom.endRoom.endRoomDoor;
	}

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

	void EndLevel(){
		
		//close the exit room door
		endDoor.collider.enabled = true;
		endDoor.renderer.enabled = true;
		
		//stop the timer
	}

	//<remarks>can be called by ObjectInteraction class</remarks>
	public void LoadNextLevel(){
		Application.LoadLevel((Application.loadedLevel) + 1);
	}
}
