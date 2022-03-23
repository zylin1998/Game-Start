using UnityEngine;

[CreateAssetMenu(fileName = "Letter", menuName = "Inventory/Letter")]
public class Letter : Item
{
    public int _id = 0;

    public override void Used()
    {
        Debug.Log($"Letter {_name} is used!");
    }
}
