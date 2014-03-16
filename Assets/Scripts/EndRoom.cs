using UnityEngine;
using System.Collections;

public class EndRoom : MonoBehaviour {

	public static EndRoom endRoom;

	public int prisonersLeft;	//amount of prisoners left to open the door
	bool accessDenied;

	public GameObject endRoomDoor, levelEnd;

	public bool AccessDenied {
		get { return accessDenied; }
	}


	void Awake() {
		endRoom = this;
	}



	void Start() {
		accessDenied = true;
		LockdownEndRoom();
	}


	// Update is called once per frame
	void Update () {
		if(prisonersLeft >0)
		accessDenied = true;
		else if(prisonersLeft <= 0)
		accessDenied = false;
	}

	void LockdownEndRoom() {
		endRoomDoor.renderer.enabled = true;
		endRoomDoor.collider.enabled = true;
		levelEnd.collider.enabled = false;
	}

	public void OpenEndRoom() {
		if(!accessDenied) {
			endRoomDoor.renderer.enabled = false;
			endRoomDoor.collider.enabled = false;
			levelEnd.collider.enabled = true;
		}
	}
}
