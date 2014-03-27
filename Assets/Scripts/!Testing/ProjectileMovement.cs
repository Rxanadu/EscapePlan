using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{

    public float movementRate;
    public float hitForce;
    public GameObject projectileExplosion;

    void Start()
    {
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementRate * Time.deltaTime;
        rigidbody.velocity = transform.forward * movementStep;
    }

    void OnTriggerEnter(Collider other)
    {
        //disable projectile
        gameObject.SetActive(false);

        //place an explosion at collision point
        Vector3 hitDirection = other.ClosestPointOnBounds(transform.position);
        Instantiate(projectileExplosion, hitDirection, Quaternion.identity);

        //check whether collider was a rigidbody
        Rigidbody body = other.attachedRigidbody;

        //don't do anything if no non-kinematic rigidbody is found
        if (body == null || body.isKinematic)
            return;

        //place positional force on rigidbody
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized * hitForce, transform.position);

    }
}