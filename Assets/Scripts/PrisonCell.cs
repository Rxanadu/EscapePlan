using UnityEngine;
using System.Collections;

///<remarks>place on each prison cell's button</remarks>
public class PrisonCell : MonoBehaviour {

	public GameObject prisonerPrefab;
	GameObject prisonerClone;
	public Transform escapeArea;
	public Transform spawnpoint;
	public float escapeRate = 6f;

	bool prisonerReleased;

	public bool PrisonerReleased {
		get { return prisonerReleased; }
		set { prisonerReleased = value; }
	}



	// Use this for initialization
	void Start () {
		if(prisonerPrefab!= null) {
			prisonerClone = Instantiate(prisonerPrefab, spawnpoint.position, spawnpoint.rotation) as GameObject;
			prisonerClone.tag = TagsAndLayers.prisoner;
		}


		escapeArea.collider.enabled = false;

		prisonerReleased = false;
	}


	void Update() {
		if(prisonerReleased)
		FreePrisoner();
	}



	void FreePrisoner() {
		float escapeStep = escapeRate*Time.deltaTime;

		//move clone to escape area
		prisonerClone.transform.position = Vector3.MoveTowards(prisonerClone.transform.position,
			escapeArea.position, escapeStep);

		escapeArea.collider.enabled = true;
		spawnpoint.collider.enabled=false;
		collider.enabled = false;
		EndRoom.endRoom.prisonersLeft--;

	}
}
