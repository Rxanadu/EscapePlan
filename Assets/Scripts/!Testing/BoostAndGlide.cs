using UnityEngine;
using System.Collections;

public class BoostAndGlide : MonoBehaviour {

    public float boostForce = 9.0f;
    public float glideForce = .1f;

    CharacterMotor playerMotor;
    JumpGameReferences jgr;

    void Awake() {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
        playerMotor = GetComponent<CharacterMotor>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
        {
            if (Input.GetMouseButton(0))
            {
                Ray moveRay = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                RaycastHit hit;

                if (Physics.Raycast(moveRay, out hit))
                {
                    float boostStep = boostForce * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, boostStep);
                }
            }
            if (Input.GetMouseButton(1))
            {
                SetMotorVelocity(Vector3.forward * glideForce);
            }
        }
	}

    void SetMotorVelocity(Vector3 velocity) {
        playerMotor.grounded = false;
        playerMotor.movement.velocity = velocity;
        playerMotor.movement.frameVelocity = Vector3.zero;
    }
}
