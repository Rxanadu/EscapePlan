using UnityEngine;
using System.Collections;

public class PlayerStatusEffects : MonoBehaviour {

    Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        player = other.GetComponent<CharacterController>().transform;

        if (player == null) {
            return;
        }

        
    }
}
