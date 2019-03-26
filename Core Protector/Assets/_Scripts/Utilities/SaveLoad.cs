using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{

    public static List<int> dataToSave = new List<int>();

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/CoreData.gm");
        bf.Serialize(file, SaveLoad.dataToSave);
        file.Close();
        Debug.Log("Data saved.");
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/CoreData.gm"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/CoreData.gm", FileMode.Open);
            SaveLoad.dataToSave = (List<int>)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Data.Save();
            Save();
        }
        Debug.Log("Data Loaded Succesfully");
    }
}
