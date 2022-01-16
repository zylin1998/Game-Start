using UnityEngine;

public class SceneAwakeDialogue : MonoBehaviour
{

    public DialogueTrigger _dialogueTrigger;
    public string _dialogueID;

    void Start()
    {
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        int temp = System.Convert.ToInt32(_dialogueID);

        if(FindObjectOfType<EventManager>() == null) 
        {
            _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueID = _dialogueID;
            _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        else if (!FindObjectOfType<EventManager>().GetReadDialogue(temp)) 
        { 
            _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueID = _dialogueID;
            _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
