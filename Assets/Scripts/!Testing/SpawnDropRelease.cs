using UnityEngine;
using System.Collections;

public class SpawnDropRelease : MonoBehaviour
{

    public Transform spawnDropHatch;
    public float releaseTimeLimit = 2.0f;

    float releaseTimer;
    GameObject player;
    JumpGameReferences jgr;
    SpawnDrop spawnDrop;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagsAndLayers.player);
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    // Use this for initialization
    void Start()
    {
        player.transform.position = transform.position;
        releaseTimer = 0.0f;
    }

    void Update() {
        //only countdown time if game is starting
        if(jgr.jgs.gameState==JumpGameState.GameStateJump.Starting)
            releaseTimer += Time.deltaTime;

        if (releaseTimer >= releaseTimeLimit) {
            spawnDropHatch.collider.enabled = false;
            spawnDropHatch.renderer.enabled = false;
            jgr.jgs.gameState = JumpGameState.GameStateJump.Started;
            releaseTimer = 0.0f;
        }
    }
}