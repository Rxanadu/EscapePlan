using UnityEngine;
using System.Collections;
using System;

public class ProjectileWeapon : MonoBehaviour
{

    public GameObject projectilePrefab;
    public GameObject gunshotFlare;
    public Transform projectileEmitter;
    public int projectileCache;

    GameObject[] projectiles;
    int lastProjectile = -1;

    void Awake()
    {
        projectiles = new GameObject[projectileCache];

        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i] = Instantiate(projectilePrefab) as GameObject;
            projectiles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
    }

    void Fire()
    {
        Instantiate(gunshotFlare, projectileEmitter.position, projectileEmitter.rotation);

        int currentProjectile = GetNextProjectile();

        projectiles[currentProjectile].SetActive(true);
        projectiles[currentProjectile].transform.position = projectileEmitter.position;
        projectiles[currentProjectile].transform.rotation = projectileEmitter.rotation;        
    }

    int GetNextProjectile()
    {
        lastProjectile++;
        Debug.Log("projectile is now #"+lastProjectile);
        if (lastProjectile >= projectileCache - 1)
            lastProjectile = 0;

        return lastProjectile;
    }
}