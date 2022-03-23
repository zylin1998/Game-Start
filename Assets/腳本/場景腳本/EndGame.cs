using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    public UnityEvent _endEvent;

    public GameObject _endPage;
    public bool _isEnd = false;
    public bool _isPress = false;

    public static GameSave _gameSave;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        if (_gameSave == null) { _gameSave = Resources.Load<GameSave>(System.IO.Path.Combine("設定檔", "GameSave")); }

        if (_endEvent == null) { _endEvent = new UnityEvent(); }

        _endEvent.AddListener(EndPage);
    }

    private void Update()
    {
        if (!FindObjectOfType<DialogueManager>()._dialogueMode) { _endEvent.Invoke(); }

        if(_isEnd && !_isPress) { CheckKeyPress(); }
    }

    public void EndPage() 
    {
        _endPage.SetActive(true);
        _isEnd = true;
    }

    private void CheckKeyPress() 
    {
        if (Input.anyKey) 
        {
            _isPress = true;

            RefreshSave();

            DelayTitleScene();
        }
    }

    public void DelayTitleScene()
    {
        Invoke("TitleScene", 0.5f);
    }

    private void TitleScene()
    {
        LoadScenes._targetScene._sceneName = "開始畫面";
        FindObjectOfType<LoadScenes>().LoadNewScene("過場畫面");
        FindObjectOfType<LoadScenes>()._asyncload.allowSceneActivation = true;
    }

    private void RefreshSave() 
    {
        GameSaveData gameSaveData = new GameSaveData();

        SaveSystem.SaveGameSaveData(_gameSave.loadFile, gameSaveData);
    }
}
