using UnityEngine;

public class DialogueMenu : MonoBehaviour
{
    [Header("��ܪ��A")]
    public bool _autoState = false;
    public bool _skipState = false;
    [Header("��檬�A")]
    public bool _menuState = false;
    public Animator _animator;
    public GameObject _backGroundImage;

    private void Start()
    {
        _animator.GetComponent<Animator>();
    }

    public void MenuButton() 
    { 
        _menuState = !_menuState;
        _animator.SetBool("isOpen", _menuState);
        _backGroundImage.SetActive(_menuState);
    }

    public void AutoButton() 
    {
        _autoState = !_autoState;
        FindObjectOfType<DialogueManager>().Auto(); 
    }

    public void SkipMenu() 
    {
        _skipState = !_skipState;
        FindObjectOfType<DialogueManager>().Skip();
    }

    public void LogButton() 
    {
        //Debug.Log("Log is not ready."); 
        FindObjectOfType<DialogueManager>().SetLogText();
    }
}
