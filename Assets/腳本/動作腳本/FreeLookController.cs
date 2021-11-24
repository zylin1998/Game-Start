using UnityEngine;
using Cinemachine;

public class FreeLookController : MonoBehaviour
{
    public CinemachineFreeLook _cinemachineFreeLook;
    
    void Start()
    {
        _cinemachineFreeLook.GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        Camera_State();
    }

    private void Camera_State()
    {
        if (FindObjectOfType<DialogueManager>().GetDialogueMode() || FindObjectOfType<InventoryUI>()._inventoryUI.activeSelf || FindObjectOfType<SettingManager>()._isOpened) { _cinemachineFreeLook.enabled = false; }

        else { _cinemachineFreeLook.enabled = true; }
    }
}
