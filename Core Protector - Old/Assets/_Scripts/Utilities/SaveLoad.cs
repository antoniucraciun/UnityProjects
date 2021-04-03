using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    static string pathPlayerData = Application.persistentDataPath + "/CoreData.gm";
    static string pathPlayerInventory = Application.persistentDataPath + "/CoreInventory.gm";

    #region CoreData
    public static void SavePlayer(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(pathPlayerData, FileMode.Create);
        Data playerData = new Data(data);
        bf.Serialize(file, playerData);
        file.Close();
    }

    public static void SaveInventory(Inventory data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(pathPlayerInventory, FileMode.Create);
        InventoryData id = new InventoryData(data);
        bf.Serialize(file, id);
        file.Close();
    }

    public static Data LoadPlayerData()
    {
        if (File.Exists(pathPlayerData))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(pathPlayerData, FileMode.Open);
            Data playerData = bf.Deserialize(file) as Data;
            file.Close();
            return playerData;
        }
        else
        {
            Data playerData = new Data();
            return playerData;
        }
    }
    #endregion

    public static InventoryData LoadInventoryData()
    {
        if (File.Exists(pathPlayerInventory))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(pathPlayerInventory, FileMode.Open);
            InventoryData invData = bf.Deserialize(file) as InventoryData;
            file.Close();
            return invData;
        }
        else
        {
            InventoryData invData = new InventoryData();
            return invData;
        }
    }
}
