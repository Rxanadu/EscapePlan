using UnityEngine;
using System.Collections;

public class QuickStart : MonoBehaviour {

	public static QuickStart quickStart;

	public GameObject entranceDoor;
	public float startTimeLimit;

	float startTime, remainingTime, timer;

	public float RemainingTime {
		get { return remainingTime; }
	}


	void Awake() {
		quickStart = this;

		startTime = Time.time;
	}


	// Use this for initialization
	void Start () {
		entranceDoor.renderer.enabled = true;
		entranceDoor.collider.enabled = true;
	}


	// Update is called once per frame
	void Update () {
		remainingTime = Mathf.Clamp(remainingTime, 0, startTimeLimit);

		CountdownStartTime();

		if(remainingTime <= 0.0f) {
			StartGame();
		}
	}


	void CountdownStartTime() {
		timer = Time.time-startTime;
		remainingTime = startTimeLimit-timer;
	}


	public void StartGame() {

		//open the door
		entranceDoor.renderer.enabled = false;
		entranceDoor.collider.enabled = false;

		//turn the quick start button off
		collider.enabled = false;

		//start level timer
		GameController.instance.stageStuff.enabled = true;
	}
}