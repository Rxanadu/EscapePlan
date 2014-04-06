using UnityEngine;
using System.Collections;

public class TimeExtension : MonoBehaviour {

    JumpGameReferences jgr;

    void Awake() {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            jgr.gameTimer.timer += 10;
            jgr.gameTimer.ShowGUI = true;

            //deactivate object
            renderer.enabled = false;
            collider.enabled = false;
        }
    }
}
