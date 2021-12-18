using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveSystemData(SystemDataCollect data)
    {
        string path = Path.Combine(Application.dataPath, "SaveData");

        DirectoryInfo saveDir = new DirectoryInfo(path);

        if (!saveDir.Exists) { saveDir.Create(); }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path.Combine(path, "SystemSave.save"), FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SystemDataCollect LoadSystemData()
    {
        string path = Path.Combine(Application.dataPath, "SaveData", "SystemSave.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SystemDataCollect data = formatter.Deserialize(stream) as SystemDataCollect;
            stream.Close();

            return data;
        }
        else
        {
            //Debug.LogError("File not found in " + path);
            return null;
        }
    }
}



/*public static void SaveData(Object @object) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.dataPath, "SaveData", "Save.save");
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, @object);
        stream.Close();
    }

    public static Object LoadData() 
    {
        string path = Path.Combine(Application.dataPath, "SaveData", "Save.save");
        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Object @object = formatter.Deserialize(stream) as Object;
            stream.Close();

            return @object;
        }
        else 
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }*/