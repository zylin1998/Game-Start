using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string _name = "New Item";
    public string _type = "New Type";
    public string _detail = "New Detail";
    public Sprite _icon = null;
    public bool _isDefaultItem = false;

    public virtual void Used (){

        Debug.Log(_name + " is using.");

    }

}
