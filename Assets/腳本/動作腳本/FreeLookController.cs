using UnityEngine;
using Cinemachine;

public class FreeLookController : MonoBehaviour
{
    public CinemachineFreeLook _cinemachineFreeLook;
    
    void Awake()
    {
        _cinemachineFreeLook.GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        Camera_State();
    }

    private void Camera_State()
    {
        if(FindObjectOfType<CursorStates>().IsLocked) { _cinemachineFreeLook.enabled = false; }

        else { _cinemachineFreeLook.enabled = true; }
    }
}
