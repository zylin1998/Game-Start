using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Button _slotButton;
    public string _slotFor = "everything";
    public Image _icon;
    public Item _item;

    public virtual void AddItem(Item item)
    {
        _item = item;

        _icon.sprite = item._icon;
        _icon.preserveAspect = true;
        _icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
    }

    public void CheckSlot()
    {
        Debug.Log("Slot item (" + _item + ") is Checked.");

        if(_item == null) { _slotButton.enabled = false; }

        else { _slotButton.enabled = true; }
    }
}
