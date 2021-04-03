//using System.Xml.Serialization;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveVars vars;

    private void Awake()
    {
        //Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
        //LoadInSave.Instace.Load();
    }
    
    //Save the state to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveVars>(vars));
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("save"));
    }

    //Load data
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            Debug.Log("Loaded");
            vars = Helper.Deserialize<SaveVars>(PlayerPrefs.GetString("save"));
        }
        else
        {
            vars = (SaveVars)ScriptableObject.CreateInstance(typeof(SaveVars));
            Save();
        }
    }

    private void OnDestroy()
    {
        Save();
    }

    public void SaveBinary()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "playerInfo.dat");
        bf.Serialize(file, vars);
        file.Close();
    }

    public void LoadBinary()
    {
        if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.Open);
            vars = (SaveVars)bf.Deserialize(file);
            LoadInSave.Instace.Load();
        }
        else
        {
            SaveBinary();
        }
    }
}
