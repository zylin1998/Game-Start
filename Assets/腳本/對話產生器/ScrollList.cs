using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollList : MonoBehaviour
{
    #region 欄位

    [Header("使用物件")]
    public GameObject _previewText;
    public Scrollbar _scrollbar;
    [Header("預覽內容")]
    public List<GameObject> _previewTexts;
    
    public List<Chara> charas;

    #endregion

    #region 事件

    private void Start() 
    {
        _previewTexts = new List<GameObject>();
    }

    #endregion

    #region 預覽物件設定

    public void Initialized()
    {
        if (this.gameObject.transform.childCount != 0)
        {
            Transform[] elderList = this.gameObject.GetComponentsInChildren<Transform>();

            foreach (Transform transform in elderList)
            {
                if (transform.name.Equals(this.gameObject.name)) { continue; }

                Destroy(transform.gameObject);
            }
        }

        _previewTexts.Clear();
    }

    public void IncreaseText(Sentence sentence) 
    {
        GameObject _newObject;

        _newObject = Instantiate(_previewText, transform);

        _newObject.GetComponent<PreviewContent>().SetContent(sentence);

        _previewTexts.Add(_newObject);

        _newObject.name = "預覽文字" + " " + (_previewTexts.Count - 1);
    }

    public void InsertText(Sentence sentence)
    {
        GameObject _newObject;
        _newObject = Instantiate(_previewText, transform);
        _previewTexts.Add(_newObject);

        _newObject.name = "預覽文字" + " " + (_previewTexts.Count - 1);

        for (int i = _previewTexts.Count - 2; i >= sentence.id; i--)
        {
            _previewTexts[i].GetComponent<PreviewContent>()._content.id++;
            _previewTexts[i + 1].GetComponent<PreviewContent>().SetContent(_previewTexts[i].GetComponent<PreviewContent>()._content);

            if (i == sentence.id)
            {
                _previewTexts[i].GetComponent<PreviewContent>().SetContent(sentence);
            }
        }
    }

    public void EditText(Sentence sentence)
    {
        _previewTexts[sentence.id].GetComponent<PreviewContent>().SetContent(sentence);
    }

    public void RemoveText(int id)
    {
        Destroy(_previewTexts[id]);
        _previewTexts.RemoveAt(id);

        for(int i = id; i < _previewTexts.Count; i++) 
        {
            if (_previewTexts[i].GetComponent<PreviewContent>()._content.id > id) { _previewTexts[i].GetComponent<PreviewContent>()._content.id--; }
            _previewTexts[i].GetComponent<PreviewContent>().PreviewText();
        }
    }

    #endregion

    #region 預覽文本複製

    public void CopyPreviewList(GameObject newList) 
    {
        if(newList.transform.childCount != 0) 
        {
            Transform[] elderList = newList.GetComponentsInChildren<Transform>();

            foreach(Transform transform in elderList) 
            {
                if (transform.name.Equals(newList.name)) { continue; }

                Destroy(transform.gameObject);
            }
        }

        foreach (GameObject gameObject in _previewTexts) 
        {
            GameObject newObject = Instantiate(gameObject, newList.transform);
        }
    }

    #endregion
}
