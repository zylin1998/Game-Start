using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenDialogue : MonoBehaviour
{
    #region 欄位

    [Header("使用物件")]
    public Text _fileNameDisplay;
    public GameObject _warning;
    [Header("檔案名稱")]
    public string _fileName;
    public static Dialogue _dialogue;

    private string _dialoguePath;

    #endregion

    #region 事件

    private void Awake()
    {
        _dialogue = (Dialogue)Resources.Load(Path.Combine("對話資料", "Dialogue"), typeof(Dialogue));
    }

    #endregion

    #region 開啟對話資料

    public void GetFileName(string fileName) 
    {
        _fileName = fileName;
        
        string path = Path.Combine("DialogueData", _fileName);

        _dialoguePath = Path.Combine(Application.dataPath, path + ".dialogue");

        if(File.Exists(_dialoguePath))
        {
            SetDefaultDialogue();
        }

        else 
        {
            _warning.SetActive(true);
        }

    }

    public void SetDefaultDialogue() 
    {
        _fileNameDisplay.text = _fileName;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;

        if (!File.Exists(_dialoguePath)) { stream = new FileStream(_dialoguePath, FileMode.Create); }
        
        else 
        { 
            stream = new FileStream(_dialoguePath, FileMode.Open);

            DialogueData data = formatter.Deserialize(stream) as DialogueData;
            
            _dialogue = new Dialogue(data.charas, data.sentences);
        }

        stream.Close();
        FindObjectOfType<FunctionUI>().Initialized(_dialogue);
        FindObjectOfType<DialogueSetting>().Initialized(_dialogue);
    }

    public void SaveDialogue(DialogueData data) 
    {   
        string path = Path.Combine(Application.dataPath, "DialogueData");
        
        BinaryFormatter formatter = new BinaryFormatter();
        DirectoryInfo saveDir = new DirectoryInfo(path);

        if (!saveDir.Exists) { saveDir.Create(); }

        FileStream stream = new FileStream(Path.Combine(path, _fileName + ".dialogue"), FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    #endregion
}
