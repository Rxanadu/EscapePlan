using UnityEngine;
using System.Collections;

public class AdjustScript : MonoBehaviour
{

    void Start()
    {
        print(Application.persistentDataPath);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health Up"))
        {
            GameControl.instance.health += 10;
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Health Down"))
        {
            GameControl.instance.health -= 10;
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "Experience Up"))
        {
            GameControl.instance.experience += 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "Experience Down"))
        {
            GameControl.instance.experience -= 10;
        }

        if (GUI.Button(new Rect(130, 100, 100, 30), "Save"))
        {
            GameControl.instance.Save();
            print("Game Saved");
        }
        if (GUI.Button(new Rect(130, 140, 100, 30), "Load"))
        {
            GameControl.instance.Load();
            print("Save Data Loaded");
        }
    }
}