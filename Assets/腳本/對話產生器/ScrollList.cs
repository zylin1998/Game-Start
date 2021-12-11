using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollList : MonoBehaviour
{
    public GameObject _previewText;
    public Scrollbar _scrollbar;

    public int _createCount;
    public List<GameObject> _previewTexts;

    private void Start() 
    {
        _previewTexts = new List<GameObject>();
    }

    public void IncreaseText(string text) 
    {
        GameObject _newObject;

        _newObject = (GameObject)Instantiate(_previewText, transform);

        _newObject.GetComponent<Text>().text = text;

        _previewTexts.Add(_newObject);
    }

    public void InsertText(int id,string text)
    {
        GameObject _newObject;
        _newObject = (GameObject)Instantiate(_previewText, transform);
        _newObject.GetComponent<Text>().text = text;

        _previewTexts.Add(_newObject);

        for (int i = _previewTexts.Count - 2; i >= id; i--)
        {
            string temp = _previewTexts[i + 1].GetComponent<Text>().text;
            _previewTexts[i + 1].GetComponent<Text>().text = _previewTexts[i].GetComponent<Text>().text;
            _previewTexts[i].GetComponent<Text>().text = temp;
        }
    }

    public void EditText(int id, string text)
    {
        _previewTexts[id].GetComponent<Text>().text = text;
    }

    public void RemoveText(int id)
    {
        Destroy(_previewTexts[id]);
        _previewTexts.RemoveAt(id);
    }

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
}
