using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image _icon;

    public Item _item;

    public void AddItem(Item item)
    {
        _item = item;

        _icon.sprite = item._icon;
        _icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
    }
}
