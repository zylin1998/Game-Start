using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private bool inventoryState = false;
    [SerializeField] private bool dialogueState = false;
    [SerializeField] private bool settingState = false;

    private void Awake()
    {
        CursorState(true);
    }

    public void CursorState(bool isLock)
    {
        if(isLock) { Cursor.lockState = CursorLockMode.Locked; }

        if(InventoryState) { return; }

        if (DialogueState) { return; }

        if (SettingState) { return; }

        if (!isLock) { Cursor.lockState = CursorLockMode.Confined; }
    }

    public bool InventoryState
    {
        get { return inventoryState; }

        set { inventoryState = value; }
    }

    public bool DialogueState
    {
        get { return false; }

        //set { dialogueState = value; }
    }

    public bool SettingState
    {
        get { return false; }

        //set { settingState = value; }
    }
}
