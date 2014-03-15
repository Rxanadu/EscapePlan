using UnityEngine;
using System.Collections;

public class EndRoom : MonoBehaviour {

	public static EndRoom endRoom;

	public int prisonersLeft;	//amount of prisoners left to open the door

	public GameObject endRoomDoor, endRoomButton, levelEnd;

	void Awake() {
		endRoom = this;
		AccessDenied();
	}

	
	// Update is called once per frame
	void Update () {
		if(prisonersLeft >0)
		AccessDenied();
		if(prisonersLeft == 0)
		AccessGranted(); }

	void AccessDenied(){
		endRoomDoor.renderer.enabled = true;
		endRoomDoor.collider.enabled = true;
		endRoomButton.collider.enabled = false;
		levelEnd.collider.enabled = false; }

	void AccessGranted(){
		endRoomDoor.renderer.enabled = false;
		endRoomDoor.collider.enabled = false;
		endRoomButton.collider.enabled = true;
		levelEnd.collider.enabled = true;
		}
}
