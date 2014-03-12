using UnityEngine;
using System.Collections;

/// <summary>
/// <remarks>Place on a game object used to display information 
///     on top of another related object (e.g. a health bar on top
///     of an enemy)
/// This was NOT made by me; this is a modification of a script I found in this tutorial video:
/// https://www.youtube.com/watch?v=rNeIj1Ll4_k </remarks>
/// </summary>
[RequireComponent(typeof(GUIText))]
[RequireComponent(typeof(GUITexture))]
public class HoveringText : MonoBehaviour
{
    /// <summary>
    /// <remarks>used to select displayed elements on screen</remarks>
    /// </summary>
    public enum DisplayElement
    {
        TextElement, TextureElement, Both
    }

    public DisplayElement displayElement;

    public Transform target;		        // Object that this label should follow
    public Vector3 offset = Vector3.up;	    // Units in world space to offset; 1 unit above object by default
    public bool clampToScreen = false;	    // If true, label will be visible even if object is off screen
    public float clampBorderSize = .05f;	// viewport space left around borders when a label is being clamped
    public bool useMainCamera = true;	    // Used on camera tagged 'MainCamera'
    public Camera cameraToUse;	            // Only used if 'useMainCamera' is false

    private Camera displayCamera;
    private Transform displayElementTransform;  //transform for this element
    private Transform displayCameraTransform;   //transform for camera in use

    //references for display elements
    GUIText displayText;
    GUITexture displayTexture;

    void Start()
    {
        displayElementTransform = transform;

        if (useMainCamera)
            displayCamera = Camera.main;
        else
            displayCamera = cameraToUse;

        displayCameraTransform = displayCamera.transform;

        displayText = GetComponent<GUIText>();
        displayTexture = GetComponent<GUITexture>();
    }

    void Update()
    {
        SetElementPositionRespectCamera();
        //SetElementPositionIgnoreCamera();
        SwitchActiveElements();
    }

    /// <summary>
    /// <remarks>element position will display if camera is turned off, 
    ///     but will not respond to target's position properly</remarks>
    /// </summary>
    void SetElementPositionRespectCamera()
    {
        if (clampToScreen)
        {
            Vector3 relativePosition = displayCameraTransform.InverseTransformPoint(target.position);

            float cameraMiddleGroundZ = 1.0f;     //used as middle ground for camera's relative position

            relativePosition.z = Mathf.Max(relativePosition.z, cameraMiddleGroundZ);

            //set position for element's transform
            Vector3 displayTransformPoint = displayCameraTransform.TransformPoint(relativePosition + offset);
            displayElementTransform.position = displayCamera.WorldToViewportPoint(displayTransformPoint);
        }
        else
        {
            displayElementTransform.position = displayCamera.WorldToViewportPoint(target.position + offset);
        }
    }

    /// <summary>
    /// <remarks>element position ignores whether camera is turned off</remarks>
    /// </summary>
    void SetElementPositionIgnoreCamera()
    {
        if (clampToScreen)
        {
            float maxBorderSize = 1.0f - clampBorderSize;

            //x, y positions for display element
            float transformPosX = Mathf.Clamp(displayElementTransform.position.x, clampBorderSize, maxBorderSize);
            float transformPosY = Mathf.Clamp(displayElementTransform.position.y, clampBorderSize, maxBorderSize);

            //set position for element's transform
            displayElementTransform.position = new Vector3(transformPosX, transformPosY, displayElementTransform.position.z);
        }
        else
        {
            displayElementTransform.position = displayCamera.WorldToViewportPoint(target.position + offset);
        }
    }

    /// <summary>
    /// <remarks>used to show how this script works with 
    ///     both GUIText and GUITexture elements</remarks>
    /// </summary>
    void SwitchActiveElements()
    {
        switch (displayElement)
        {
            case DisplayElement.TextElement:
                displayText.enabled = true;
                displayTexture.enabled = false;
                break;
            case DisplayElement.TextureElement:
                displayText.enabled = false;
                displayTexture.enabled = true;
                break;
            case DisplayElement.Both:
                displayText.enabled = true;
                displayTexture.enabled = true;
                break;
        }
    }
}