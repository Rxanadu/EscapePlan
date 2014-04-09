using UnityEngine;
using System.Collections;

public class SpawnDrop : MonoBehaviour
{

    public float moveRate = 7.0f;
    public float gyroSpinRate = 50.0f;
    public Transform spawnDropGyro;

    JumpGameReferences jgr;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        //jgr.jgs.gameState = JumpGameState.GameStateJump.Starting;
    }

    // Update is called once per frame
    void Update()
    {
        //spin gyro for visual effect
        float gyroSpinStep = gyroSpinRate * Time.deltaTime;
        spawnDropGyro.Rotate(transform.up * gyroSpinStep);

        //fly away when game starts/ends
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
        {
            //move spawn drop to a location...
            float moveStep = moveRate * Time.deltaTime;
            transform.Translate(transform.up * moveStep);
        }
    }
}