using UnityEngine;
using System.Collections;

/// <summary>
/// Object interaction.
/// <remarks>place on player's main camera</remarks>
/// </summary>
public class ObjectInteraction : MonoBehaviour {
	public LayerMask interactiveLayer;
	public float interactionDistance;
	public Texture2D interactCursor;

	bool lookingAtInteractiveObject;

	void Start() {
		lookingAtInteractiveObject = false;
	}

	// Update is called once per frame
	void Update () {
		InteractWithEnvironment ();
	}

	void OnGUI() {
		if(lookingAtInteractiveObject) {
			if(interactCursor!= null) {
				float cursorX = Screen.width/2-interactCursor.width/2;
				float cursorY = Screen.height/2-interactCursor.height/2;
				float cursorWidth = interactCursor.width;
				float cursorHeight = interactCursor.height;
				GUI.DrawTexture(new Rect(cursorX, cursorY, cursorWidth, cursorHeight), interactCursor);
			}
		}
	}

	void InteractWithEnvironment() {
		Ray ray = new Ray(this.transform.position, this.transform.forward);
		RaycastHit hit;
		Debug.DrawRay (ray.origin, ray.direction, Color.green);
		if(Physics.Raycast (ray, out hit, interactionDistance, interactiveLayer)) {
			//display an image in the middle of the screen
			lookingAtInteractiveObject = true;

			if(Input.GetMouseButtonDown(0)) {
				//perform action based on the interaction
				SelectInteractiveObject(hit);
			}
		}

		else {
			lookingAtInteractiveObject=false;
		}
	}

	void SelectInteractiveObject(RaycastHit hit) {
		switch(hit.transform.tag) {
			case TagsAndLayers.alarmBox:
				if(AlarmSystem.alarmSystem.AlarmActive) {
				AlarmSystem.alarmSystem.AlarmActive = false;
				hit.transform.gameObject.GetComponent<Button>().ClickButton ();
				hit.transform.parent.gameObject.GetComponent<AlarmBox>().IsDead = true;
			}
			else if(!AlarmSystem.alarmSystem.AlarmActive) {
				print ("Cannot disable alarm: not currently active");
			}

			break;

			case TagsAndLayers.mapScreenButton:
				MapScreenButton button = hit.transform.gameObject.GetComponent<MapScreenButton>();
			if(button.rightSideButton)
				MapScreen.mapScreen.SelectedFloor++;
			if(!button.rightSideButton)
				MapScreen.mapScreen.SelectedFloor--;
			break;

			case TagsAndLayers.quickStartButton:
				//start the game
				QuickStart.quickStart.StartGame();
			break;
			
			case TagsAndLayers.exitRoomButton:
				//only open door if end room gives player permission
				EndRoom.endRoom.OpenEndRoom();
				break;				
		}
	}
}
