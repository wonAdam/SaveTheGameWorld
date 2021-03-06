using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManager
{
    private static readonly string path = Path.Combine(Application.persistentDataPath, "SaveData.sav");

    public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        Debug.Log(path);

        bf.Serialize(stream, playerData);
        stream.Close();
    }

    public static bool SaveDataExists()
    {
        return File.Exists(path + "/SaveData.sav");
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }

        return null;
    }

    //public class LevelLock 
    //{
    //    int nowlevel; 
    //    public GameObject stageNumObject;

    //    void Start()
    //    {
    //        Button[] stages = stageNumObject.GetComponentsInChildren<Button>();

    //        nowlevel = PlayerPrefs.GetInt("levelReached");
    //        //print(nowlevel);
    //        for (int i = nowlevel + 1; i < stages.Length; i++)
    //        {
    //            stages[i].interactable = false;
    //        }
    //    }
    //    bool IsCompleteLevel(int nowlevel)
    //    {
    //        if (RewardCompleteList.Count == 0) return false;

    //        for (int i = 0; i < RewardCompleteList.Count; i++)
    //        {
    //            if (nowlevel == RewardCompleteList[i]) return true;
    //        }

    //        return false;
    //    }


    //}
}


[Serializable]
public class PlayerData
{
    public int chapterProgress = 0;

    public PlayerData()
    {
    }

    public PlayerData(int progress)
    {
        chapterProgress = progress;
    }
}
