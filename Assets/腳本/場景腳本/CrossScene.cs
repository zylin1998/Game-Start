using UnityEngine;
using UnityEngine.UI;

public class CrossScene : MonoBehaviour
{
    public LoadScenes _loadScenes;
    public TargetScene _targetScene;
    public int Progress;
    public Text _text;

    private void Start()
    {
        _targetScene = (TargetScene)Resources.Load(System.IO.Path.Combine("過場資料", "Target Scene"), typeof(TargetScene));
        _loadScenes.LoadNewScene(_targetScene._sceneName);
    }

    private void Update()
    {
        _text.text = "Is Loading......\n" + _loadScenes.Progress;
        if(_loadScenes.Progress >= 100) { _loadScenes._asyncload.allowSceneActivation = true; }
    }
}
