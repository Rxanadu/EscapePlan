using UnityEngine;
using System.Collections;

/// <summary>
/// Alarm timer.
/// <remarks>time has to come alarm system</remarks>
/// </summary>
public class AlarmTimer : MonoBehaviour {

	TextMesh timerDisplay;

	// Use this for initialization
	void Start () {
		timerDisplay = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		string timerText = string.Format ("{0:00}",AlarmSystem.alarmSystem.RemainingTime);
		timerDisplay.text = timerText;
	}
}
