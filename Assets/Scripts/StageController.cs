using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public static StageController stageController;

	float startTime, timer, remainingTime;

	public float levelTimeLimit;

	public float RemainingTime {
		get { return remainingTime; }
	}


	void Awake() {
		stageController = this;
		startTime = Time.time;
	}


	// Update is called once per frame
	void Update () {
		LevelCountdown();
	}

	void LevelCountdown() {
		timer = Time.time-startTime;
		remainingTime = levelTimeLimit -timer;
	}
}