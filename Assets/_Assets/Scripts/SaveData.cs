using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    
    public static void SavePlayer(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sv";
        Data data = new Data(gameManager);
        
        //Creating A File in the directory "path"
        FileStream file = new FileStream(path, FileMode.Create);
        
        //Write Data In The File
        formatter.Serialize(file, data);
        
        file.Close(); 
    }

    public static Data Load()
    {
        string path = Application.persistentDataPath + "/player.sv";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            Data data = formatter.Deserialize(file) as Data;
            file.Close();
            
            return data;
        }
        else
        {
            Debug.LogError("File Not Found");
            return null;
        }
    }
}
