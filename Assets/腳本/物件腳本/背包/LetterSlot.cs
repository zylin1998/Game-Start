using UnityEngine;
using UnityEngine.UI;

public class LetterSlot : InventorySlot
{
    [Header("���~�W�����")]
    public Text _text;

    [Header("�H��s��")]
    public int _id = 0;

    public override void AddItem(Item item)
    {
        base.AddItem(item);

        _text.text = item._name;
    }
}
