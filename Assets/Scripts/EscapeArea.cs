using UnityEngine;
using System.Collections;

public class EscapeArea : MonoBehaviour {

	public GameObject prisonCellButton;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag(TagsAndLayers.prisoner)) {
			//stop player from appearing
			other.gameObject.collider.enabled = false;
			other.gameObject.renderer.enabled = false;
			
			//for flair: make something appear to indicate the prisoner has escaped
			
			//make stop prison cell from running same function indefinitely
			prisonCellButton.GetComponent<PrisonCell>().PrisonerReleased = false;
		}
	}
}
