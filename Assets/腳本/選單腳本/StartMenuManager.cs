using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject _buttons;

    private string _crossScene = "過場畫面";
    private AsyncOperation _asyncload;

    private void Start()
    {
        ButtonStates(false);
        StartCoroutine(LoadYourAsyncScene(_crossScene));
    }

    private void Update()
    {
        if(_asyncload.progress >= 0.9f) { ButtonStates(true); }
    }

    public void StartButton(float delay) 
    {
        Invoke("DelayStartGame", delay);
    }

    public void SettingButton()
    { 
        //Not using.
    }

    public void GalleryButton() 
    {
        Debug.Log("Gallery is not ready yet.");
    }

    public void QuitButton(float delay) 
    {
        Invoke("DelayQuitButton", delay);
    }

    public void DelayStartGame()
    {
        _asyncload.allowSceneActivation = true;
    }

    public void DelayQuitButton() 
    {
        Application.Quit();
    }

    private void ButtonStates(bool active) 
    {
        _buttons.SetActive(active);
    }

    private IEnumerator LoadYourAsyncScene(string scene)
    {
        _asyncload = SceneManager.LoadSceneAsync(scene);
        _asyncload.allowSceneActivation = false;

        while (!_asyncload.isDone)
        {
            //Debug.Log("Loading progress: " + (_asyncload.progress * 100) + "%");
            yield return null;
        }
    }
}
