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
    public MusicController musicController;
    public GameTimer gameTimer;
    public DeathArea deathArea;    
    public SpawnDrop spawnDrop;
    public GameObject[] objectSpawners;
    public GameObject[] jumppadPillars;

    void Awake()
    {
        jgs = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameState>();
        musicController = GameObject.FindGameObjectWithTag(TagsAndLayers.musicController).GetComponent<MusicController>();
        gameTimer = GameObject.FindGameObjectWithTag(TagsAndLayers.gameTimer).GetComponent<GameTimer>();
        deathArea = GameObject.FindGameObjectWithTag(TagsAndLayers.deathArea).GetComponent<DeathArea>();       
        spawnDrop = GameObject.FindGameObjectWithTag(TagsAndLayers.spawnDrop).GetComponent<SpawnDrop>();

        objectSpawners = GameObject.FindGameObjectsWithTag(TagsAndLayers.objectSpawner);
        jumppadPillars = GameObject.FindGameObjectsWithTag(TagsAndLayers.jumppadPillar);
    }
}