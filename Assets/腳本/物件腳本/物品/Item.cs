using UnityEngine;

[System.Serializable]
public enum Category
{
    letter,
    jewelry,
    other
}

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("物品基本資訊")]
    public string _name = "Item";
    public Category _category = Category.other;
    public Sprite _icon = null;
    public string _detail = "Detail";
    
    public bool _isDefaultItem = false;

    
    public virtual void Used ()
    {
         Debug.Log(_name + " is using.");
    }

    public virtual void PickUp() 
    {
        Debug.Log($"{_name} picked up.");
    }
}
