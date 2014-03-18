using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public static StageController stageController;

	bool gameActive;
	float startTime, timer, remainingTime;
	GameObject player;

	public float levelTimeLimit;

	public bool GameActive {
		get { return gameActive; }
	}



	public float RemainingTime {
		get { return remainingTime; }
	}


	void Awake() {
		stageController = this;
		startTime = Time.time;
		player = GameObject.FindGameObjectWithTag(TagsAndLayers.player);

		gameActive = true;
	}


	// Update is called once per frame
	void Update () {
		LevelCountdown();

		if(remainingTime <= 0||
			AlarmSystem.alarmSystem.RemainingTime<= 0) {
			StopGame();
		}
	}


	void LevelCountdown() {
		timer = Time.time-startTime;
		remainingTime = levelTimeLimit -timer;
	}

	///<remarks>acts as 'Game Over' function
	///	only run when either level timer or alarm timer ends</remarks>
	
	void StopGame() {
		//disable exit room
		gameActive = false;

		//disable player's movement, look movement
		player.GetComponent<CharacterMotor>().enabled=false;
		player.GetComponent<MouseLook>().enabled=false;
		Camera.main.GetComponent<MouseLook>().enabled=false;

		//fade out screen
		
		//reload scene after fade
	}
}