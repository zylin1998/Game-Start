using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class OpenDialogue : MonoBehaviour
{
    [Header("使用物件")]
    public Text _fileNameDisplay;
    [Header("檔案名稱")]
    public string _fileName;

    public void GetFileName(string fileName) 
    {
        _fileName = fileName;
        _fileNameDisplay.text = _fileName;

        string path = Path.Combine("對話資料", _fileName);
        FindObjectOfType<FunctionUI>().Initialized(path);
        FindObjectOfType<DialogueSetting>().Initialized(path);
    }
}
