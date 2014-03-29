using UnityEngine;
using System.Collections;
using System;

public class ProjectileWeapon : MonoBehaviour
{

    public GameObject projectilePrefab;
    public GameObject gunshotFlare;
    public Transform projectileEmitter;
    public Transform soulStone;
    public int projectileCache;
    public float rotateRate = 8.0f;
    public float chargeRate = 3.0f;
    public float maxCharge = 2.0f;

    float minRotateRate, maxRotateRate;
    float curCharge;
    AudioSource chargingSound;
    float minPitch,maxPitch;
    GameObject[] projectiles;
    int lastProjectile = -1;
    bool chargingShot = false;
    bool chargeComplete = false;

    void Awake()
    {
        projectiles = new GameObject[projectileCache];

        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i] = Instantiate(projectilePrefab) as GameObject;
            projectiles[i].SetActive(false);
        }

        chargingSound = soulStone.GetComponent<AudioSource>();
        minPitch = chargingSound.pitch;
        maxPitch = minPitch + .9f;
    }

    void Start()
    {
        minRotateRate = 50;
        maxRotateRate = rotateRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            chargingShot = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
            chargingShot = false;
        }

        if (chargingShot)
            ChargeShot();

        else if (!chargingShot)
            RotateSoulStone();
    }

    void ChargeShot()
    {
        float curRotateRate = minRotateRate;
        curRotateRate = Mathf.Lerp(curRotateRate, maxRotateRate, minRotateRate / maxRotateRate);

        float rotateStep = curRotateRate * Time.deltaTime;
        soulStone.Rotate(Vector3.right * rotateStep);

        //charge projectile
        chargingSound.pitch = Mathf.Lerp(chargingSound.pitch, maxPitch, minRotateRate / maxRotateRate);
        curCharge+=chargeRate*Time.deltaTime;

        if (curCharge >= maxCharge)
            chargeComplete = true;
        else
            chargeComplete = false;
    }

    /// <summary>
    /// <remarks>rotates soul stone around when in normal settings</remarks>
    /// </summary>
    void RotateSoulStone() {
        //reset to no-charge state
        curCharge = 0;
        chargingSound.pitch = minPitch;

        float rotateStep = minRotateRate*Time.deltaTime;
        soulStone.Rotate(Vector3.right * rotateStep);
    }

    void Fire()
    {
        Instantiate(gunshotFlare, projectileEmitter.position, projectileEmitter.rotation);

        int currentProjectile = GetNextProjectile();

        projectiles[currentProjectile].SetActive(true);
        projectiles[currentProjectile].transform.position = projectileEmitter.position;
        projectiles[currentProjectile].transform.rotation = projectileEmitter.rotation;

        if (chargeComplete) {
            projectiles[currentProjectile].transform.localScale *= 5;
            projectiles[currentProjectile].GetComponent<ProjectileMovement>().movementRate *= 3;
        }
    }

    int GetNextProjectile()
    {
        lastProjectile++;
        Debug.Log("projectile is now #" + lastProjectile);
        if (lastProjectile >= projectileCache - 1)
            lastProjectile = 0;

        return lastProjectile;
    }
}