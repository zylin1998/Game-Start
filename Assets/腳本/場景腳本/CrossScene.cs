using UnityEngine;
using UnityEngine.UI;

public class CrossScene : MonoBehaviour
{
    public LoadScenes _loadScenes;
    public static TargetScene _targetScene;
    public int Progress;
    public Text _text;

    private void Start()
    {
        if (_targetScene == null) { _targetScene = (TargetScene)Resources.Load(System.IO.Path.Combine("過場資料", "Target Scene"), typeof(TargetScene)); }
        _loadScenes.LoadNewScene(_targetScene._sceneName);
    }

    private void Update()
    {
        _text.text = "Is Loading......" + _loadScenes.Progress + "%";
        if(_loadScenes.Progress >= 100) 
        {
            //_loadScenes.UnLoadScenes("過場畫面");
            _loadScenes._asyncload.allowSceneActivation = true;
        }
    }
}
