using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManager
{
    public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    public static void SavePlayer(SavePos player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path + "/PlayerPos.txt", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static float LoadPlayer()
    {

        if (File.Exists(path + "/PlayerPos.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path + "/PlayerPos.txt", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            return data.stats;
        }
        return 0;
    }
}

[Serializable]
public class PlayerData
{
    public float stats = 0;

    public PlayerData(SavePos player)
    {
        stats = SavePos.posX;
    }
}
