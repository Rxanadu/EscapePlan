using UnityEngine;
using System.Collections;

public class DeathArea : MonoBehaviour
{
    JumpGameReferences jgr;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsAndLayers.player))
        {
            jgr.jgs.gameState = JumpGameState.GameStateJump.Ended;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}