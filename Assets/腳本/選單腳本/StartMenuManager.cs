using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    [Header("過場目標")]
    public LoadScenes _loadScenes;
    [Header("設定介面")]
    public GameObject _settingPage;
    public Animator _settingAnimator;

    private void Start()
    {
        _settingAnimator.GetComponent<Animator>();
    }

    public void StartButton(float delay) 
    {
        Invoke("DelayStartButton", delay);
    }

    public void SettingButton()
    {
        _settingPage.SetActive(true);
        _settingAnimator.SetBool("isOpen", true);
    }

    public void GalleryButton(float delay) 
    {
        Invoke("DelayGalleryButton", delay);
    }

    public void QuitButton(float delay) 
    {
        Invoke("DelayQuitButton", delay);
    }

    public void DelayStartButton()
    {
        _loadScenes._targetScene._sceneName = "開頭";
        _loadScenes._asyncload.allowSceneActivation = true;
    }

    public void DelayQuitButton() 
    {
        Application.Quit();
    }

    public void DelayGalleryButton()
    {
        _loadScenes.LoadNewScene("畫廊");
        _loadScenes._asyncload.allowSceneActivation = true;
    }
}
