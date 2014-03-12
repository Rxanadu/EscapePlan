using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;

    public float health, experience;

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);

        GUI.Label(new Rect(10, 40, 100, 30), "Experience: " + experience);
    }

    /// <summary>
    /// Serializes data for all platforms (except Web Player)
    /// </summary>
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        //FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");

        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");
            //file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
        }

        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;

        //writes data container to file
        bf.Serialize(file, data);

        //close file
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            experience = data.experience;
        }
    }
}

/// <summary>
/// <remarks>allows game to write data for game into a file</remarks>
/// </summary>
[Serializable]
class PlayerData {
    public float health, experience;
}