using UnityEngine;
using System.Collections;

public class EndRoom : MonoBehaviour {

	public static EndRoom endRoom;

	public int prisonersLeft;	//amount of prisoners left to open the door
	bool accessDenied;

	public GameObject endRoomDoor, levelEnd;

	public int PrisonersLeft {
		get { return prisonersLeft; }
	}



	public bool AccessDenied {
		get { return accessDenied; }
	}


	void Awake() {
		endRoom = this;
	}


	void Start() {
		accessDenied = true;
		LockdownEndRoom();

		//temporary call for all prisoners
		if(GameObject.FindGameObjectsWithTag(TagsAndLayers.prisonCell).Length !=null)
			prisonersLeft = GameObject.FindGameObjectsWithTag(TagsAndLayers.prisonCell).Length;
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
