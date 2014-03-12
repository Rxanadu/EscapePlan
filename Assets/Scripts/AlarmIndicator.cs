using UnityEngine;
using System.Collections;

public class AlarmIndicator : MonoBehaviour {

	TextMesh indicatorDisplay;

	// Use this for initialization
	void Start () {
		indicatorDisplay = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(AlarmSystem.alarmSystem.AlarmActive){
			indicatorDisplay.text = "ON";
		}
		else if(!AlarmSystem.alarmSystem.AlarmActive)
			indicatorDisplay.text="OFF";
	}
}
