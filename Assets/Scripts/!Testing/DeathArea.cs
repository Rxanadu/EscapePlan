using UnityEngine;
using System.Collections;

public class DeathArea : MonoBehaviour
{
    JumpGameReferences jgr;
    float timeLimit = 2.0f;
    bool hasEnteredArea = false;

    GUITexture deathScreen;

    public bool HasEnteredArea { get { return hasEnteredArea; } }

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        deathScreen = GetComponentInChildren<GUITexture>();
    }

    void Update() {
        if (deathScreen == null)
            return;

        if (jgr.jgs.gameState != JumpGameState.GameStateJump.Ended)
            deathScreen.enabled = false;            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsAndLayers.player))
        {
            EndGame();
        }
    }

    void ReplayGame() {
        Application.LoadLevel(Application.loadedLevel);
    }

    void EndGame() {
        //end game if not ended already
        if (jgr.jgs.gameState != JumpGameState.GameStateJump.Ended)
            jgr.jgs.gameState = JumpGameState.GameStateJump.Ended;

        //confirm that player has entered death area trigger
        hasEnteredArea = true;

        //enable death screen
        deathScreen.enabled = true;

        //disable player movement
        jgr.player.GetComponent<CharacterMotor>().enabled = false;
        jgr.player.GetComponent<MouseLook>().enabled = false;
        Camera.main.GetComponent<MouseLook>().enabled = false;

        //reload level
        Invoke("ReplayGame", (jgr.musicController.DeathClip.length));
    }
}