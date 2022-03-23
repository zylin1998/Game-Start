using UnityEngine;

public class CursorStates : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject DialogueUI;
    public GameObject SettingUI;

    [SerializeField] private bool inventoryState = false;
    [SerializeField] private bool dialogueState = false;
    [SerializeField] private bool settingState = false;
    [SerializeField] private bool isLocked;
    
    private void Awake()
    {
        CursorState(false);
    }

    private void Update()
    {
        if(FindObjectOfType<KeyManager>()._escapeState) { SettingState = !SettingState; }
        
        if(FindObjectOfType<KeyManager>()._inventoryState) { InventoryState = !InventoryState; }

        if(inventoryState) { return; }
        
        if(dialogueState) { return; }

        if(settingState) { return; }
        
        CursorState(false);
    }

    public bool InventoryState
    {
        get { return inventoryState; }

        set 
        { 
            inventoryState = value;
            InventoryUI.SetActive(value) ;
            if (value) { CursorState(value); }
        }
    }

    public bool DialogueState
    {
        get { return dialogueState; }

        set 
        { 
            dialogueState = value;

            if (!value) { Invoke("CloseDialogueUI", 1.1f); }

            if (value) 
            {
                DialogueUI.SetActive(dialogueState); 
                CursorState(value); 
            }
        }
    }

    public bool SettingState
    {
        get { return settingState; }

        set 
        { 
            settingState = value;

            if (!value)
            {
                FindObjectOfType<SettingManager>().SetSettingUI();
                Invoke("CloseSettingUI", 1.1f);
            }

            if (value) 
            { 
                CursorState(value);
                SettingUI.SetActive(value);
                FindObjectOfType<SettingManager>().SetSettingUI();
            }
        }
    }

    public void CursorState(bool newState)
    {
        IsLocked = newState;

        if (!newState) { Cursor.lockState = CursorLockMode.Locked; }

        if (newState) { Cursor.lockState = CursorLockMode.Confined; }
    }

    public bool IsLocked
    {
        get { return isLocked; }

        private set { isLocked = value; }
    }

    private void CloseDialogueUI() 
    {
        DialogueUI.SetActive(dialogueState);
    }

    private void CloseSettingUI()
    {
        SettingUI.SetActive(settingState);
    }
}
