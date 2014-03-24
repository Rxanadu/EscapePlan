using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController instance;

	[HideInInspector]
	public StageController stageControl;

	void Awake() {
		if(instance == null) {
			DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else if(instance!= this) {
			Destroy(gameObject);
		}

		stageControl = GetComponent<StageController>();
	}

    void Start()
    {
        stageControl.enabled = false;
    }
}

