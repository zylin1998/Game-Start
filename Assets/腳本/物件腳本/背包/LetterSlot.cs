using UnityEngine;
using UnityEngine.UI;

public class LetterSlot : InventorySlot
{
    [Header("物品名稱顯示")]
    public Text _text;

    [Header("信件編號")]
    public int _id = 0;

    public override void AddItem(Item item)
    {
        base.AddItem(item);

        _text.text = item._name;
    }
}
