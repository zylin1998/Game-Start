using UnityEngine;

public class PassiveDialogueTrigger : MonoBehaviour
{
    public DialogueTrigger _dialogueTrigger;
    public string _dialogueID;
    public bool isUsed = false;

    private void Start()
    {
        _dialogueTrigger.GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (!isUsed) 
        { 
            _dialogueTrigger._dialogueID = _dialogueID;
            _dialogueTrigger.TriggerDialogue();
            isUsed = true;
        }
    }
}
