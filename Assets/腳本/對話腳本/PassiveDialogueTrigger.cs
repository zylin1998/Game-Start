using UnityEngine;

public class PassiveDialogueTrigger : MonoBehaviour
{
    public DialogueTrigger _dialogueTrigger;
    public string _dialogueID;
    
    private void Start()
    {
        _dialogueTrigger.GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter(Collider collider) 
    {
        int temp = System.Convert.ToInt32(_dialogueID);

        if (FindObjectOfType<EventManager>() == null)
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
