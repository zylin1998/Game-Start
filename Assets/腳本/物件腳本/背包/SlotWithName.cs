using UnityEngine;
using UnityEngine.UI;

public class SlotWithName : InventorySlot
{
    [Header("物品名稱顯示")]
    public Text _text;

    public override void AddItem(Item item)
    {
        base.AddItem(item);

        _text.text = item._name;
    }
}
