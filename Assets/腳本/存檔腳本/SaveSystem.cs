using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    #region 系統資訊

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

    #endregion

    #region 事件資訊

    public static void SaveGameSaveData(string fileName, GameSaveData data)
    {
        string path = Path.Combine(Application.dataPath, "SaveData");

        DirectoryInfo saveDir = new DirectoryInfo(path);

        if (!saveDir.Exists) { saveDir.Create(); }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path.Combine(path, fileName + ".save"), FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameSaveData LoadGameSaveData(string fileName)
    {
        string path = Path.Combine(Application.dataPath, "SaveData", fileName + ".save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameSaveData data = formatter.Deserialize(stream) as GameSaveData;
            stream.Close();

            return data;
        }
        else
        {
            //Debug.LogError("File not found in " + path);
            return null;
        }
    }

    #endregion

    #region 對話資訊

    public static void SaveDialogueData(string fileName, DialogueData data)
    {
        string path = Path.Combine(Application.dataPath, "DialogueData");

        DirectoryInfo saveDir = new DirectoryInfo(path);

        if (!saveDir.Exists) { saveDir.Create(); }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path.Combine(path, fileName + ".dialogue"), FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Dialogue SetDefaultDialogue(string dialoguePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;

        if (File.Exists(dialoguePath))
        {
            stream = new FileStream(dialoguePath, FileMode.Open);

            DialogueData data = formatter.Deserialize(stream) as DialogueData;

            Dialogue dialogue = new Dialogue(data.charas, data.sentences);

            stream.Close();

            return dialogue;
        }

        else { return null; }

    }
    #endregion
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
