using UnityEngine;
using System.Collections;

/// <summary>
/// display main menu at start of the game
/// <remarks>place on an empty game object.
/// Ensure the game object has a title and credits child game object</remarks>
/// </summary>
public class MenuScreen : MonoBehaviour
{
    JumpGameReferences jgr;

    public GUISkin menuSkin;
    public GUITexture howToPlayTexture;
    public GUIText bestTime;
    public Camera menuCamera;

    bool howToPlayActive = false;
    GUIText[] textElements;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        textElements = GetComponentsInChildren<GUIText>();
    }

    void Start()
    {
        jgr.jgs.gameState = JumpGameState.GameStateJump.IntroducingGame;

        if (menuCamera == null)
            return;
        else
            menuCamera.depth = 1;

        //display best time on screen
        bestTime.text = PlayerPrefs.GetFloat("bestTime").ToString("{0:00}");
    }

    void Update()
    {
        if (howToPlayTexture == null)
            return;

        if (howToPlayActive)
            howToPlayTexture.enabled = true;
        else if (!howToPlayActive)
            howToPlayTexture.enabled = false;
    }

    void OnGUI()
    {
        GUI.skin = menuSkin;

        if (jgr.jgs.gameState == JumpGameState.GameStateJump.IntroducingGame)
        {
            Rect area = new Rect(0, Screen.height / 3, .3f * Screen.width, Screen.height / 3);
            GUILayout.BeginArea(area);
            GUILayout.BeginVertical();
            if (GUILayout.Button("Play Game"))
            {
                //start the game
                menuCamera.depth = -1;
                foreach (GUIText element in textElements)
                    element.enabled = false;

                jgr.jgs.gameState = JumpGameState.GameStateJump.Starting;
            }

            if (GUILayout.Button("How To Play"))
            {
                howToPlayActive = !howToPlayActive;
            }

            if (Application.platform == RuntimePlatform.WindowsPlayer)
                if (GUILayout.Button("Quit Game")) { Application.Quit(); }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}