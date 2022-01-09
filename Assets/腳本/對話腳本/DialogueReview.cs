using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueReview : MonoBehaviour
{
    [Header("使用物件")]
    public GameObject _previewText;
    public Scrollbar _scrollbar;
    [Header("預覽內容")]
    public List<GameObject> _previewTexts;

    public List<Chara> charas;
}
