﻿using UnityEngine;
using System.Collections;

/// <summary>
/// controls aspects of all jumpads, movement of parent pillars
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class Jumppad : MonoBehaviour
{

    public float jumpForce = 50.0f;         //force at which player jumps
    public float inactiveTimeLimit = 7.0f;
    public AudioClip[] bounceNoises;

    bool pillarInactive;
    float inactiveTimer;
    JumpGameReferences jgr;

    //used for scaling pillar to a small amount
    Vector3 initScale, lowScale;

    public Vector3 LowScale {
        get { return lowScale; }
    }

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void Start()
    {
        audio.playOnAwake = false;
        initScale = transform.parent.transform.localScale;
        lowScale = new Vector3(2, initScale.y, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (pillarInactive)
        {
            //deactivate jumppad
            collider.enabled = false;
            renderer.enabled = false;

            //deactivate pillar
            transform.parent.renderer.enabled = false;
            transform.parent.collider.enabled = false;

            if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
                inactiveTimer += Time.deltaTime;
        }

        if (!pillarInactive)
        {
            //reactivate jumppad/keep jumppad active
            collider.enabled = true;
            renderer.enabled = true;

            //reactivate pillar/keep pillar active
            transform.parent.renderer.enabled = true;
            transform.parent.collider.enabled = true;
        }

        if (inactiveTimer >= inactiveTimeLimit )
        {
            //reactivate pillar, jumppad
            pillarInactive = false;

            //reset timer for inactivation
            inactiveTimer = 0.0f;
        }


        //deactivate pillars, jumppads if game has ended
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Ended) {
            pillarInactive = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //play bounce sound
        if (!audio.isPlaying)
            audio.PlayOneShot(bounceNoises[Random.Range(0, bounceNoises.Length)]);

        //bounce player upwards
        CharacterMotor charMotor = other.GetComponent<CharacterMotor>();
        SetUpwardVelocity(charMotor, Vector3.up * jumpForce);
        pillarInactive = true;
    }

    /// <summary>
    /// pushes player upward for player based on velocity
    /// </summary>
    /// <param name="charMotor">object of CharacterMotor</param>
    /// <param name="velocity">object for Vector3</param>
    void SetUpwardVelocity(CharacterMotor charMotor, Vector3 velocity)
    {
        charMotor.grounded = false;
        charMotor.movement.velocity = velocity;
        charMotor.movement.frameVelocity = Vector3.zero;
    }
}