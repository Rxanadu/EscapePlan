using UnityEngine;
using System.Collections;

public class SpawnDrop : MonoBehaviour
{

    public float moveRate = 7.0f;
    public float detectionDistance = 7.0f;
    public float rotAngle = 40.0f;
    public float gyroSpinRate = 50.0f;
    public LayerMask barrierMask;
    public Transform spawnDropGyro;

    JumpGameReferences jgr;
    Transform startingTransform;    //refernces random transform among jumppad pillars
    Vector3 startingPosition;       //position for spawn drop to travel to when game starts

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        jgr.jgs.gameState = JumpGameState.GameStateJump.Starting;
    }

    // Use this for initialization
    void Start()
    {
        transform.Rotate(Vector3.up * Random.Range(0, 360));
        startingTransform = jgr.jumppadPillars[Random.Range(0, jgr.jumppadPillars.Length)].transform;
        startingPosition = new Vector3(startingTransform.position.x, transform.position.y, startingTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //spin gyro for visual effect
        float gyroSpinStep = gyroSpinRate * Time.deltaTime;
        spawnDropGyro.Rotate(transform.up * gyroSpinStep);

        //move spawn drop to a location...
        float moveStep = moveRate * Time.deltaTime;

        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Starting)
        {
            //transform.Translate(transform.forward * moveStep);
            transform.position = Vector3.Lerp(transform.position, startingPosition, moveStep);

            //Ray detectionRay = new Ray(transform.position, transform.forward);
            //RaycastHit hit;

            //if (Physics.Raycast(detectionRay, out hit, detectionDistance, barrierMask))
            //{
            //    float rotStep = rotAngle * Time.deltaTime;
            //    transform.Rotate(transform.up * rotStep);
            //}
        }

        //fly away when game starts/ends
        if (jgr.jgs.gameState != JumpGameState.GameStateJump.Starting) {
            transform.Translate(transform.up * moveStep);
        }
    }
}