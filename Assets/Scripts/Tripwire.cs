using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Tripwire : MonoBehaviour {

	LineRenderer tripwireLine;

	// Use this for initialization
	void Start () {
		tripwireLine = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		tripwireLine.SetPosition(0, this.transform.position);
		tripwireLine.SetPosition (1, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+50));

		Ray tripwireRay = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.Raycast (tripwireRay, out hit)){
			if(hit.collider.CompareTag ("Player")){
				AlarmSystem.alarmSystem.AlarmActive=true;
			}
		}
	}
}
