using UnityEngine;
using System.Collections;

/// <summary>
/// controls where object spawns
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public int activeObjectCount;       //number of active objects in the world

    float spawnObjectCount;             //number of objects to spawn into the world
    GameObject[] objectSpawnpoints;     //spawnpoints at which objects will spawn at

    void Awake()
    {
        spawnObjectCount = GameObject.FindGameObjectsWithTag(TagsAndLayers.jumppadPillar).Length;
        objectSpawnpoints = GameObject.FindGameObjectsWithTag(TagsAndLayers.objectSpawner);
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < spawnObjectCount; i++)
        {
            GameObject clone = Instantiate(spawnObject, objectSpawnpoints[i].transform.position, Quaternion.identity) as GameObject;
            clone.transform.parent = objectSpawnpoints[i].transform;
        }
    }
}