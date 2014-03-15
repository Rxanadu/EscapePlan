using UnityEngine;
using System.Collections;

/// <summary>
/// Object interaction.
/// <remarks>place on player's main camera</remarks>
/// </summary>
public class ObjectInteraction : MonoBehaviour {
	public LayerMask interactiveLayer;
	public float interactionDistance;

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)) {
			InteractWithEnvironment ();
		}
	}

	void InteractWithEnvironment() {
		Ray ray = new Ray(this.transform.position, this.transform.forward);
		RaycastHit hit;
		Debug.DrawRay (ray.origin, ray.direction, Color.green);
		if(Physics.Raycast (ray, out hit, interactionDistance, interactiveLayer)) {
			if(hit.transform.CompareTag ("AlarmBox")) {
				if(AlarmSystem.alarmSystem.AlarmActive) {
					AlarmSystem.alarmSystem.AlarmActive = false;
					hit.transform.gameObject.GetComponent<Button>().ClickButton ();
					hit.transform.parent.gameObject.GetComponent<AlarmBox>().IsDead = true;
				}
				else if(!AlarmSystem.alarmSystem.AlarmActive) {
					print ("Cannot disable alarm: not currently active");
				}
			}

			if(hit.transform.CompareTag("MapScreenButton")) {
				MapScreenButton button = hit.transform.gameObject.GetComponent<MapScreenButton>();
				if(button.rightSideButton)
					MapScreen.mapScreen.SelectedFloor++;
				if(!button.rightSideButton)
					MapScreen.mapScreen.SelectedFloor--;
			}

			if(hit.transform.CompareTag("QuickStartButton")) {
				//start the game
				QuickStart.quickStart.StartGame();
			}
		}
	}

	void SelectInteractiveObject(){

	}
}
