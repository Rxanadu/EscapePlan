using UnityEngine;
using System.Collections;

/// <summary>
/// adds time to game timer when collected
/// </summary>
public class TimeExtension : MonoBehaviour {

    public float addedTime = 10.0f;

    JumpGameReferences jgr;

    void Awake() {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(TagsAndLayers.player)) {
            //add time to game timer
            jgr.gameTimer.timer += addedTime;

            //display added time limit
            jgr.gameTimer.ShowGUI = true;

            //deactivate object
            renderer.enabled = false;
            collider.enabled = false;
        }
    }
}
