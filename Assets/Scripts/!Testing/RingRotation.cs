using UnityEngine;
using System.Collections;

/// <summary>
/// contorls rotation of ring objects
/// <remarks>used to create challenge for the player</remarks>
/// </summary>
public class RingRotation : MonoBehaviour
{

    public float rotateRate = 7.0f;
    public float minSwitchTime = 5.0f;
    public float maxSwitchTime = 15.0f;
    public bool canChangeDirection = true;      //can the ring switch its direction?

    bool rotateClockwise;
    float switchTimer;
    float randomSwitchTimeLimit;

    void Start()
    {
        rotateClockwise = true;
        switchTimer = 0;
        randomSwitchTimeLimit = Random.Range(minSwitchTime, maxSwitchTime);
    }

    // Update is called once per frame
    void Update()
    {
        float curRotateRate = rotateRate;

        //as long as the ring is able to change direction, 
        //  the following is possible
        if (canChangeDirection)
        {
            switchTimer += Time.deltaTime;

            //rotate as long as direction has not been switched
            if (switchTimer > randomSwitchTimeLimit)
            {
                switchTimer = 0;
                randomSwitchTimeLimit = Random.Range(minSwitchTime, maxSwitchTime);
                rotateClockwise = !rotateClockwise;
            }

            //switch rotation direction
            if (!rotateClockwise)
                curRotateRate = -rotateRate;
            else if (rotateClockwise)
                curRotateRate = rotateRate;
        }

        //rotate object on y-axis
        float rotateStep = curRotateRate * Time.deltaTime;
        transform.Rotate(transform.up * rotateStep);
    }
}