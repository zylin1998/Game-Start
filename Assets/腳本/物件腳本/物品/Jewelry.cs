using UnityEngine;

public enum JewelryColor 
{
    Red,
    Blue,
    Green,
    None
}

[CreateAssetMenu(fileName = "Jewelry", menuName = "Inventory/Jewelry")]
public class Jewelry : Item
{
    [Header("�_�]�C��")]
    public JewelryColor jewelryColor = JewelryColor.None;

    public override void Used()
    {
        Debug.Log($"Jewelry {_name} is used!");
    }
}
