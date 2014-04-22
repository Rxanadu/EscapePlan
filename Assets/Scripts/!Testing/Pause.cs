using UnityEngine;
using System.Collections;

/// <summary>
/// <remarks>place on Main Camera object</remarks>
/// </summary>
public class Pause : MonoBehaviour
{

    JumpGameReferences jgr;
    bool gamePaused = false;

    public GUITexture pauseTexture;
    public GUISkin menuSkin;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("game is paused: " + gamePaused);
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Starting ||
            jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
        {
            if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Escape))
            {
                gamePaused = !gamePaused;
            }

            if (gamePaused)
            {
                //stop things in game from moving
                Time.timeScale = 0.0f;

                //disabe player camera movement
                jgr.player.GetComponent<MouseLook>().enabled = false;
                Camera.main.GetComponent<MouseLook>().enabled = false;

                //display pause screen
                pauseTexture.enabled = true;

                //allow player to move cursor
                Screen.showCursor = true;

                //stop music from playing
                AudioListener.pause = true;
            }
            if (!gamePaused)
            {
                //get things going (again)
                Time.timeScale = 1.0f;

                //get player moving
                jgr.player.GetComponent<MouseLook>().enabled = true;
                Camera.main.GetComponent<MouseLook>().enabled = true;

                //hide pause screen
                pauseTexture.enabled = false;

                //stop cursor from moving
                Screen.showCursor = false;

                //let music play
                AudioListener.pause = false;
            }
        }

        if (jgr.jgs.gameState == JumpGameState.GameStateJump.IntroducingGame) {
            pauseTexture.enabled = false;
            Screen.showCursor = true;
        }
    }

    void OnGUI()
    {

        float pauseWidth = Screen.width * .33f;
        float pauseHeight = Screen.height / 7;
        float pausePosX = Screen.width / 2 - pauseWidth / 2;
        float pausePosY = Screen.height / 2 - pauseHeight / 2;

        Rect pauseArea = new Rect(pausePosX, pausePosY, pauseWidth, pauseHeight);

        GUI.skin = menuSkin;

        GUILayout.BeginArea(pauseArea);
        GUILayout.BeginVertical();
        if (gamePaused)
        {
            if (GUILayout.Button("To Main Menu"))
            {
                //un-pause game
                gamePaused = false;

                Application.LoadLevel(Application.loadedLevel);                
            }
            if (Application.platform == RuntimePlatform.WindowsPlayer ||
                Application.platform == RuntimePlatform.OSXPlayer)
            {
                if (GUILayout.Button("Quit To Desktop"))
                {
                    Application.Quit();
                }
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}