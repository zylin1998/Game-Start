using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public GameObject _hint;
    public Text _text;
    public GameObject _target;

    public Item _item;

    private void OnTriggerStay(Collider collider)
    {
        _hint.SetActive(true);
        _text.text = "¬B¨ú";

        if (FindObjectOfType<KeyManager>()._eventState)
        {
            bool _wasPickedUp = Inventory.instance.Add(_item);

            if (_wasPickedUp)
            {
                _hint.SetActive(false);
                Destroy(_target);
            }
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        _hint.SetActive(false);
    }
}
