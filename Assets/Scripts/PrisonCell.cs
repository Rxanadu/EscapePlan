using UnityEngine;
using System.Collections;

///<remarks>place on each prison cell's button</remarks>
public class PrisonCell : MonoBehaviour {

	public GameObject prisonerPrefab, prisonerClone;
	public Transform escapeArea;
	public Transform spawnpoint;
	public float escapeRate = 6f;

	// Use this for initialization
	void Start () {
		if(prisonerPrefab!= null)
		prisonerClone = Instantiate(prisonerPrefab, spawnpoint.position, spawnpoint.rotation) as GameObject;
		escapeArea.collider.enabled = false;
	}


	public void FreePrisoner() {
		float escapeStep = escapeRate*Time.deltaTime;

		//move clone to escape area
		prisonerClone.transform.position = Vector3.MoveTowards(prisonerClone.transform.position,
			escapeArea.position, escapeStep);
		collider.enabled = false;
		EndRoom.endRoom.prisonersLeft--;
	}
}
