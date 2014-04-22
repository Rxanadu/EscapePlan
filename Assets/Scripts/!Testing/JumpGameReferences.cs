using UnityEngine;
using System.Collections;

/// <summary>
/// contains all global references for jump game
/// <remarks>jump game currently in development</remarks>
/// </summary>
public class JumpGameReferences : MonoBehaviour
{

    [HideInInspector]
    public JumpGameState jgs;

    [HideInInspector]
    public MusicController musicController;     //controls all background music within game

    [HideInInspector]
    public GameTimer gameTimer;                 //controls time in which the game plays

    [HideInInspector]
    public DeathArea deathArea;                 //ends game if player enters it

    [HideInInspector]
    public SpawnDrop spawnDrop;                 //where player starts the game

    [HideInInspector]
    public MenuScreen menuScreen;               //displays main menu information

    [HideInInspector]
    public Pause pause;                         //pauses the game, controls pause menu

    [HideInInspector]
    public Crosshair crosshair;

    [HideInInspector]
    public GameObject[] objectSpawners;         //game objects where time extension objects will appear

    [HideInInspector]
    public GameObject[] jumppadPillars;         //used for traversing the arena

    [HideInInspector]
    public GameObject player;                   //the main player object

    void Awake()
    {
        jgs = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameState>();
        musicController = GameObject.FindGameObjectWithTag(TagsAndLayers.musicController).GetComponent<MusicController>();
        gameTimer = GameObject.FindGameObjectWithTag(TagsAndLayers.gameTimer).GetComponent<GameTimer>();
        deathArea = GameObject.FindGameObjectWithTag(TagsAndLayers.deathArea).GetComponent<DeathArea>();       
        spawnDrop = GameObject.FindGameObjectWithTag(TagsAndLayers.spawnDrop).GetComponent<SpawnDrop>();
        menuScreen = GameObject.FindGameObjectWithTag(TagsAndLayers.menuController).GetComponent<MenuScreen>();
        pause = Camera.main.GetComponent<Pause>();
        crosshair = Camera.main.GetComponent<Crosshair>();

        objectSpawners = GameObject.FindGameObjectsWithTag(TagsAndLayers.objectSpawner);
        jumppadPillars = GameObject.FindGameObjectsWithTag(TagsAndLayers.jumppadPillar);
        player = GameObject.FindGameObjectWithTag(TagsAndLayers.player);
    }
}