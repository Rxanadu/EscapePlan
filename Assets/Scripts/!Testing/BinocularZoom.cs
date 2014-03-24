using UnityEngine;
using System.Collections;

public class BinocularZoom : MonoBehaviour
{
    public float zoomedFOV = 20f;
    public float smooth = 5f;
    public GUITexture binocularsImage;

    float normalFOV = 10f;
    bool zoomedIn = false;

    // Use this for initialization
    void Start()
    {
        if (binocularsImage != null)
            binocularsImage.enabled = false;

        normalFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            zoomedIn = !zoomedIn;

        ControlCameraZoom();
    }

    void ControlCameraZoom()
    {
        float smoothStep = smooth * Time.deltaTime;

        if (zoomedIn)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomedFOV, smoothStep);
            binocularsImage.enabled = true;
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normalFOV, smoothStep);
            binocularsImage.enabled = false;
        }
    }
}