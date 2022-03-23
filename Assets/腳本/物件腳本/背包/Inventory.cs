using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public List<Item> _itemList = new List<Item>();

    public bool Add(Item item) 
    {
        if(item._isDefaultItem) { return false; } 
        
        _itemList.Add(item);

        if(OnItemChangedCallback != null) { OnItemChangedCallback.Invoke(); }
        
        return true;
    }

    public void Remove(Item item)
    {
        _itemList.Remove(item);

        if (OnItemChangedCallback != null) { OnItemChangedCallback.Invoke(); }
    }
}
