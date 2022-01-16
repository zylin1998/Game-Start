using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    public UnityEvent _endEvent;

    public GameObject _endPage;
    public bool _isEnd = false;
    public bool _isPress = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        if(_endEvent == null) { _endEvent = new UnityEvent(); }

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
        if (Input.anyKey) {
            _isPress = true;
            DelayTitleScene();
        }
    }

    public void DelayTitleScene()
    {
        Invoke("TitleScene", 0.5f);
    }

    private void TitleScene()
    {
        LoadScenes._targetScene._sceneName = "�}�l�e��";
        FindObjectOfType<LoadScenes>().LoadNewScene("�L���e��");
        FindObjectOfType<LoadScenes>()._asyncload.allowSceneActivation = true;
    }
}
