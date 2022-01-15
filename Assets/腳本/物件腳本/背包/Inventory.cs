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

    public int _ballSpace = 3;
    public int _letterSpace = 5;

    public List<Item> _letterList = new List<Item>();
    public List<Item> _ballList = new List<Item>();

    public bool Add(Item item) 
    {
        bool _addState = false;

        if(!item._isDefaultItem) 
        {

            if (item._type.Equals("Ball")) { _addState = SetBallList(item); }

            else if (item._type.Equals("Letter")) { _addState = SetLetterList(item); }

            if(OnItemChangedCallback != null) { OnItemChangedCallback.Invoke(); }
        }

        return true;
    }

    public void Remove(Item item)
    {
        if (item._type.Equals("Ball")) { _ballList.Remove(item); }

        else if (item._type.Equals("Letter")) { _letterList.Remove(item); }

        if (OnItemChangedCallback != null) { OnItemChangedCallback.Invoke(); }
    }

    public bool SetBallList(Item item)
    {
        if (_ballList.Count >= _ballSpace)
        {
            Debug.Log("Not enough space.");
            return false;
        }

        _ballList.Add(item);

        return true;
    }

    public bool SetLetterList(Item item)
    {
        if (_letterList.Count >= _letterSpace)
        {
            Debug.Log("Not enough space.");
            return false;
        }

        _letterList.Add(item);

        return true;
    }
}
