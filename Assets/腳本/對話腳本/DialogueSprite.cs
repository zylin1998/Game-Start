using System.Collections.Generic;
using UnityEngine;

public class DialogueSprite : MonoBehaviour
{
    public Transform _spriteParent;

    private CharaSprite[] _inputCharaSprites;
    private CharaSprite[] _outputCharaSprites;

    void Awake()
    {
        _inputCharaSprites = _spriteParent.GetComponentsInChildren<CharaSprite>();
    }

    public void SetCharaSprite(List<Dialogue.Chara> charas) {

        _outputCharaSprites = new CharaSprite[charas.Count - 1];

        int count = 0;
        foreach (Dialogue.Chara chara in charas) 
        {
            if (chara.name.Equals("")) { continue; }

            foreach(CharaSprite charaSprite in _inputCharaSprites)
            {
                if (charaSprite.name.Equals(chara.name)) {
                    _outputCharaSprites[count] = charaSprite;
                    _outputCharaSprites[count].Move(chara.posiX);
                    count++;
                }
            }
        }
    
    }

    public void DispalySprites(int _isSpeakChara) 
    {
        for(int i = 0; i < _outputCharaSprites.Length; i++) 
        {
            if (i == (_isSpeakChara - 1)) { 
                _outputCharaSprites[i]._isSpeak = true;
                _outputCharaSprites[i].IsSpeak();
            }
            else { 
                _outputCharaSprites[i]._isSpeak = false;
                _outputCharaSprites[i].NonSpeak();
            }
        }
    }
}
