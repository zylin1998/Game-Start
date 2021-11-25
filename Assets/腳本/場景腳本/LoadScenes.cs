using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public TargetScene _targetScene;

    public float Progress;

    public AsyncOperation _asyncload;

    public void Start()
    {
        _targetScene = (TargetScene)Resources.Load(System.IO.Path.Combine("過場資料", "Target Scene"), typeof(TargetScene));
    }

    public void LoadNewScene(string sceneName) 
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    private IEnumerator LoadYourAsyncScene(string scene)
    {
        _asyncload = SceneManager.LoadSceneAsync(scene);

        _asyncload.allowSceneActivation = false;

        while (!_asyncload.isDone)
        {
            Progress = Mathf.FloorToInt(Mathf.Clamp01(_asyncload.progress / 0.9f) * 100);
            Debug.Log(Progress + "%");
            yield return null;
        }
    }
}
