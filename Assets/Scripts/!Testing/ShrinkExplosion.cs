using UnityEngine;
using System.Collections;

public class ShrinkExplosion : MonoBehaviour {

    JumpGameReferences jgr;

    void Awake() {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit a pillar");
        if (other.CompareTag(TagsAndLayers.jumppadPillar))
        {
            
            Jumppad contactedJumppad = other.GetComponentInChildren<Jumppad>();

            if (contactedJumppad == null)
                return;

            Debug.Log("I'm hitting " + contactedJumppad.name);

            contactedJumppad.transform.localScale = Vector3.Lerp(contactedJumppad.transform.localScale, contactedJumppad.LowScale, 3 * Time.deltaTime);
        }
    }
}
