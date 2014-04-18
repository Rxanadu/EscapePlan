using UnityEngine;
using System.Collections;

/// <summary>
/// allows player to boost forward and 'hover' around the arena
/// <remarks>place on player game object</remarks>
/// </summary>
public class BoostAndGlide : MonoBehaviour
{

    public float boostForce = 9.0f;
    public float glideForce = .1f;
    public float boostTimeLimit = 1.0f;

    CharacterMotor playerMotor;
    JumpGameReferences jgr;
    float boostTimer;
    bool boostingNow = false;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        playerMotor = GetComponent<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
        {
            if (Input.GetMouseButtonDown(0))
            {

                boostingNow = true;
            }

            if (Input.GetMouseButton(1))
            {
                SetMotorVelocity(-Vector3.up * glideForce);
            }

            if (boostingNow)
            {
                boostTimer += Time.deltaTime;
                Boost();

                if (boostTimer >= boostTimeLimit)
                {
                    boostingNow = false;
                    boostTimer = 0.0f;
                }
            }
        }
    }

    void SetMotorVelocity(Vector3 velocity)
    {
        playerMotor.grounded = false;
        playerMotor.movement.velocity = velocity;
        playerMotor.movement.frameVelocity = Vector3.zero;
    }

    //quickly move player toward Raycast hit position
    void Boost()
    {
        Ray moveRay = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        //when ray hits something...
        if (Physics.Raycast(moveRay, out hit))
        {
            //...boost player towards it
            float boostStep = boostForce * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hit.point, boostStep);
        }
    }
}