using UnityEngine;
using System.Collections;

public class SpawnDropRelease : MonoBehaviour
{

    public Transform spawnDropHatch;

    GameObject player;
    JumpGameReferences jgr;
    SpawnDrop spawnDrop;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagsAndLayers.player);

        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        spawnDrop = GameObject.FindGameObjectWithTag(TagsAndLayers.spawnDrop).GetComponent<SpawnDrop>();
    }

    // Use this for initialization
    void Start()
    {
        player.transform.position = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawnDropHatch.collider.enabled = false;
                spawnDropHatch.renderer.enabled = false;
                jgr.jgs.gameState = JumpGameState.GameStateJump.Started;
                //spawnDrop.GameStarted = true;
            }
        }
    }
}