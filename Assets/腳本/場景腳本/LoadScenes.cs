using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public static TargetScene _targetScene;

    public float Progress;

    public AsyncOperation _asyncload;

    private void Start()
    {
        if(_targetScene == null) { _targetScene = (TargetScene)Resources.Load(System.IO.Path.Combine("過場資料","Target Scene"),typeof(TargetScene)); }
    }

    public void LoadNewScene(string sceneName) 
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    public void UnLoadScenes(string sceneName) 
    {
        SceneManager.UnloadScene(sceneName);
    }

    private IEnumerator LoadYourAsyncScene(string scene)
    {
        _asyncload = SceneManager.LoadSceneAsync(scene);

        _asyncload.allowSceneActivation = false;

        while (!_asyncload.isDone)
        {
            Progress = Mathf.FloorToInt(Mathf.Clamp01(_asyncload.progress / 0.9f) * 100);
            yield return null;
        }
    }
}
