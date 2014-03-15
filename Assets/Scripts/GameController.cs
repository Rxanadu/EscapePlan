using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController instance;

	[HideInInspector]
	public StageController stageStuff;

	void Awake() {
		if(instance == null) {
			DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else if(instance!= this) {
			Destroy(gameObject);
		}

		stageStuff = GetComponent<StageController>();
	}

	void Start() {
		stageStuff.enabled = false;
	}
}

