using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTrigger : MonoBehaviour
{
    public DialogueTrigger _dialogueTrigger;
    public string _dialogueTXT;
    public GameObject _hint;
    public Text _text;

    private void Start()
    {
        _dialogueTrigger.GetComponent<DialogueTrigger>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!FindObjectOfType<DialogueManager>()._dialogueMode) { _hint.SetActive(true); }
        _text.text = "¹ï¸Ü";

        if (FindObjectOfType<KeyManager>()._eventState){

            _dialogueTrigger._dialogueTXT = _dialogueTXT;
            _dialogueTrigger.TriggerDialogue();
            _hint.SetActive(false);

        }

    }

    private void OnTriggerExit(Collider collider)
    {
        _hint.SetActive(false);
    }
}
