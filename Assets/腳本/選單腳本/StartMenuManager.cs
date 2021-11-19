using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void StartButton(float delay) 
    {
        Invoke("DelayStartGame", delay);
    }

    public void DelayStartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void SettingButton()
    { 
        //Not using.
    }

    public void QuitButton(float delay) 
    {
        Invoke("DelayQuitButton", delay);
    }

    public void DelayQuitButton() 
    {
        Application.Quit();
    }
}
