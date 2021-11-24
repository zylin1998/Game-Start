using UnityEngine;
using UnityEngine.UI;

public class DialogueMenu : MonoBehaviour
{
    public bool _autoState = false;
    public bool _skipState = false;

    public void MenuButton() { Debug.Log("Menu is out."); }

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

    public void LogButton() { Debug.Log("Log is not ready."); }
}
