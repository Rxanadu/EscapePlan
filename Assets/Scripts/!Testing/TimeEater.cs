using UnityEngine;
using System.Collections;

public class TimeEater : MonoBehaviour
{
    public float moveRate = 7.0f;
    public float depletionRate = 1.5f;

    public Transform exterior, interior;

    JumpGameReferences jgr;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
        {
            MoveToPlayer();

            if (exterior == null || interior == null)
                return;

            //rotate enemy exterior
            exterior.rotation = Random.rotation;

            //have clock face look toward player
            interior.rotation = Quaternion.LookRotation(jgr.player.transform.position);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(TagsAndLayers.player))
        {
            float depletionStep = depletionRate * Time.deltaTime;
            jgr.gameTimer.timer -= depletionStep;

            //alter game sound
            jgr.musicController.audio.pitch = 1.5f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagsAndLayers.player))
            jgr.musicController.audio.pitch = 1.0f;
    }

    /// <summary>
    /// move object toward player's position
    /// </summary>
    void MoveToPlayer()
    {
        Vector3 playerPosition = jgr.player.transform.position;
        float moveStep = moveRate * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, playerPosition, moveStep);
    }
}