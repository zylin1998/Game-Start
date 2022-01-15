using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    public UnityEvent _endEvent;

    public GameObject _endPage;
    public bool _isEnd = false;

    private void Start()
    {
        if(_endEvent == null) { _endEvent = new UnityEvent(); }

        _endEvent.AddListener(EndPage);
    }

    private void Update()
    {
        if (!FindObjectOfType<DialogueManager>()._dialogueMode) { _endEvent.Invoke(); }

        if(_isEnd && Input.anyKeyDown) { DelayTitleScene(); }
    }

    public void EndPage() 
    {
        _endPage.SetActive(true);
        _isEnd = true;
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
