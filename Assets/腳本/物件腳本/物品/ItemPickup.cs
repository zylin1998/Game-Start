using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [Header("事件提示")]
    public GameObject _hint;
    public Text _text;
    [Header("目標物件")]
    public GameObject _target;
    [Header("物品")]
    public Item _item;
    [Header("是否觸發對話")]
    public bool _hasDialogue;
    public string _dialogueID;

    private void OnTriggerStay(Collider collider)
    {
        _hint.SetActive(true);
        _text.text = "拾取";

        if (FindObjectOfType<KeyManager>()._eventState)
        {
            bool _wasPickedUp = Inventory.instance.Add(_item);

            if (_wasPickedUp)
            {
                _hint.SetActive(false);
                GameObject.Find("事件管理").GetComponent<EventManager>().ItemPickUp(_target);

                if (_hasDialogue) 
                {
                    FindObjectOfType<DialogueTrigger>()._dialogueID = _dialogueID;
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                }
            }
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        _hint.SetActive(false);
    }
}
