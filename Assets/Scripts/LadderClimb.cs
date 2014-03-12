using UnityEngine;
using System.Collections;

/// <summary>
/// <remarks>place on player character with FPSInputController script</remarks>
/// </summary>
public class LadderClimb : MonoBehaviour
{

    public Transform CharController;
    public bool inside;
    public float heightFactor = 3.2f;

    FPSInputController FPSInput;

    void Start()
    {
        FPSInput = GetComponent<FPSInputController>();
        inside = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = false;
            inside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = true;
            inside = false;
        }
    }

    void Update()
    {
        ClimbLadder();   
    }

    void ClimbLadder()
    {
        if (inside && Input.GetKey(KeyCode.W))
            CharController.transform.position += Vector3.up / heightFactor;
    }
}