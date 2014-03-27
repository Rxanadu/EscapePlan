using UnityEngine;
using System.Collections;

/// <summary>
/// draws crosshair at middle of the screen 
/// @Author: Edgar Onukwugha
/// <remarks>can place on any game object
/// primarily used for setting up weapon crosshairs</remarks>
/// </summary>
public class Crosshair : MonoBehaviour
{

    Transform[] childTransforms;
    float crosshairX, crosshairY, crosshairWidth, crosshairHeight;
    Rect crosshairRect;

    public Texture2D defaultCrosshair, itemCrosshair;

    void Awake()
    {
        childTransforms = GetComponentsInChildren<Transform>();
    }

    void OnGUI()
    {
        //GetComponentsInChildren<Transform>() will allways have a length of at least 1
        //  since every GameObject has a Transform component
        if (defaultCrosshair != null && childTransforms.Length == 1)
        {
            DrawCrosshair(defaultCrosshair);
        }
        else if (itemCrosshair != null && childTransforms.Length > 1)
            DrawCrosshair(itemCrosshair);
    }

    /// <summary>
    /// draws crosshair texture in middle of the screen
    /// </summary>
    /// <param name="crosshairTexture"></param>
    void DrawCrosshair(Texture2D crosshairTexture)
    {
        //setup crosshair rect parameters
        crosshairX = Screen.width / 2 - crosshairTexture.width / 2;
        crosshairY = Screen.height / 2 - crosshairTexture.height / 2;
        crosshairWidth = crosshairTexture.width;
        crosshairHeight = crosshairTexture.height;
        crosshairRect = new Rect(crosshairX, crosshairY, crosshairWidth, crosshairHeight);

        //draw crosshair
        GUI.DrawTexture(crosshairRect, crosshairTexture);
    }
}