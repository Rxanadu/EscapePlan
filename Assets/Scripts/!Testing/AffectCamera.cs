using UnityEngine;
using System.Collections;

public class AffectCamera : MonoBehaviour
{

    bool cameraEffectOn;
    Camera playerCamera;
    float startingFOV = 0.0f;

    public float rotateRate = 3f;
    public float zoomRate = 40.0f;

    void Start()
    {
        cameraEffectOn = false;
        startingFOV = 60.0f;
    }

    void Update()
    {
        if (playerCamera != null)
        {
            if (cameraEffectOn)
            {
                //ZoomInAndOut(playerCamera);                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCamera = other.gameObject.GetComponentInChildren<Camera>();
            MirrorWorld(playerCamera);
            cameraEffectOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraEffectOn = false;
            //StopZoomInAndOut(playerCamera);
            StopMirrorWorld(playerCamera);
            playerCamera = null;
        }
    }

    //status effect #1: zoom camera in/out
    void ZoomInAndOut(Camera playerCamera)
    {
        float zoomStep = zoomRate * Time.time;
        playerCamera.fieldOfView = Mathf.PingPong(zoomStep, startingFOV) + startingFOV / 2;
    }

    void StopZoomInAndOut(Camera playerCamera)
    {
        playerCamera.fieldOfView = startingFOV;
    }

    //status effect #2: mirrored world
    void MirrorWorld(Camera playerCamera)
    {
        playerCamera.projectionMatrix = playerCamera.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }

    void StopMirrorWorld(Camera playerCamera)
    {
        playerCamera.projectionMatrix = playerCamera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, 1, 1));
    }
}