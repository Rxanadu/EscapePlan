using UnityEngine;
using System.Collections;

/// <summary>
/// spawns a set amount of random enemies at a set rate during gameplay
/// </summary>
public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyTypes;
    public float maxTimeLimit = 15.0f;

    float timer;
    float randomTimeLimit;
    SphereCollider spawnTrigger;
    Vector3 spawnPosition;
    JumpGameReferences jgr;

    void Awake()
    {
        spawnTrigger = GetComponent<SphereCollider>();
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
        randomTimeLimit = Random.Range(0, maxTimeLimit);
        spawnPosition = new Vector3(Random.insideUnitSphere.x * spawnTrigger.radius, 
            transform.position.y, Random.insideUnitSphere.z * spawnTrigger.radius);
    }

    // Update is called once per frame
    void Update()
    {
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
            timer += Time.deltaTime;

        if (timer >= randomTimeLimit)
        {
            timer = 0.0f;
            randomTimeLimit = Random.Range(0, maxTimeLimit);

            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPosition, Quaternion.identity);

            //reset spawn position to random Vector3 position
            spawnPosition = new Vector3(Random.insideUnitSphere.x * spawnTrigger.radius, 
                transform.position.y, Random.insideUnitSphere.z * spawnTrigger.radius);
    
        }
    }
}