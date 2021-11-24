using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossScene : MonoBehaviour
{
    public string _sceneIndex;
    public int Progress;

    private AsyncOperation _asyncload;

    private void Start()
    {   
        string _sceneIndex = "¶}ÀY";
        StartCoroutine(LoadYourAsyncScene(_sceneIndex));
    }

    void Update()
    {
        if(_asyncload.isDone) { SceneManager.LoadScene(_sceneIndex); }
    }

    IEnumerator LoadYourAsyncScene(string scene) 
    {
        _asyncload = SceneManager.LoadSceneAsync(scene);

        while(!_asyncload.isDone)
        {
            Progress = Mathf.FloorToInt(Mathf.Clamp01(_asyncload.progress / 0.9f) * 100);
            Debug.Log(Progress);
            yield return null;
        }
    }
}
