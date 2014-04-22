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
        //set game start to introducing the game
        jgr.jgs.gameState = JumpGameState.GameStateJump.IntroducingGame;

        //place the menu camera's depth in front of player camera
        if (menuCamera == null)
            return;
        else
            menuCamera.depth = 1;

        //display best time on screen
        bestTime.text = PlayerPrefs.GetFloat("bestTime").ToString("{0:00}");

        //disable crosshair
        jgr.crosshair.enabled = false;
    }

    void Update()
    {
        if (howToPlayTexture == null)
            return;

        if (howToPlayActive)
        {
            howToPlayTexture.enabled = true;

            //disable gui text elements
            foreach (GUIText element in textElements)
                element.enabled = false;
        }
        else if (!howToPlayActive)
        {
            howToPlayTexture.enabled = false;

            //enable gui text elements
            foreach (GUIText element in textElements)
                element.enabled = true;
        }

        if (Input.GetMouseButtonDown(0) &&
            jgr.jgs.gameState == JumpGameState.GameStateJump.IntroducingGame)
        {
            if (howToPlayActive)
            {
                howToPlayActive = false;
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = menuSkin;

        if (jgr.jgs.gameState == JumpGameState.GameStateJump.IntroducingGame)
        {
            Rect menuArea = new Rect(0, Screen.height / 3, .3f * Screen.width, Screen.height / 3);
            GUILayout.BeginArea(menuArea);
            GUILayout.BeginVertical();

            if(!howToPlayActive)
                DisplayMainMenu();

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }

    //shows all main menu options on screen
    void DisplayMainMenu() {
        //starts the game
        if (GUILayout.Button("Play Game"))
        {
            StartGame();
        }

        if (GUILayout.Button("How To Play"))
        {
            howToPlayActive = !howToPlayActive;
        }

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (GUILayout.Button("Quit Game"))
            {
                Application.Quit();
            }
        }
    }

    //initializes the game 
    void StartGame() {
        //places menuCamera to the backside
        menuCamera.depth = -1;

        //disable main menu elements
        foreach (GUIText element in textElements)
            element.enabled = false;

        //set game state to starting the game
        jgr.jgs.gameState = JumpGameState.GameStateJump.Starting;

        //enable crosshair
        jgr.crosshair.enabled = true;
    }
}