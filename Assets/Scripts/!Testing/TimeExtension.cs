using UnityEngine;
using System.Collections;

/// <summary>
/// adds time to game timer when collected
/// </summary>
public class TimeExtension : MonoBehaviour
{

    public float addedTime = 10.0f;
    public float activationTime = 30.0f;
    public GameObject timeCollectionExplosion;

    JumpGameReferences jgr;
    float activationTimer;
    bool extensionCollected = false;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void Update()
    {
        if (extensionCollected)
        {
            DisableTimeExension();
        }

        if (!extensionCollected)
        {
            EnableTimeExtension();
        }

        if (activationTimer >= activationTime)
        {
            extensionCollected = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsAndLayers.player))
        {
            //add time to game timer
            jgr.gameTimer.timer += addedTime;

            //display added time limit
            jgr.gameTimer.ShowAddTime = true;

            //set time extension as collected
            extensionCollected = true;

            if (timeCollectionExplosion == null)
                return;

            //make explosion appear to indicate player has collected time
            Instantiate(timeCollectionExplosion, transform.position, Quaternion.identity);
        }
    }

    void DisableTimeExension() {
        //deactivate object
        renderer.enabled = false;
        collider.enabled = false;

        //count time for activation
        activationTimer += Time.deltaTime;
    }

    void EnableTimeExtension() {
        //activate extension object
        renderer.enabled = true;
        collider.enabled = true;

        //reset timer
        activationTimer = 0.0f;
    }
}