﻿using UnityEngine;
using System.Collections;

/// <summary>
/// moves rigidbody objects around with Character Controller object
/// <remarks>place on Character Controller object</remarks>
/// </summary>

public class ObjectPhysics : MonoBehaviour {

    public float pushForce = 2.0f;

    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        //checking whether rigidbody is either non-existant or kinematic
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -.3f)
            return;

        //set up push direction for object
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        
        //apply push force to object
        body.velocity = pushForce * pushDirection;
    }
}
