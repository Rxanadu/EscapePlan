using UnityEngine;
using System.Collections;

public class TraverseScene : MonoBehaviour
{

    public int sceneToLoad;

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 80, 120, 30), "Current Scene: " + (Application.loadedLevel + 1));
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50, 120, 40), "Load Scene " + (sceneToLoad + 1)))
        {
            Application.LoadLevel(sceneToLoad);
        }
    }
}