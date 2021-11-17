using UnityEngine;

public class CharaSprite : MonoBehaviour
{
    public RectTransform _transform;
    public SpriteRenderer _spriteRenderer;
    public string name;
    public bool _isSpeak;

    public void IsSpeak() { _spriteRenderer.color = Color.white; }

    public void NonSpeak() { _spriteRenderer.color = Color.gray; }

    public void Move(int posiX) {
        _transform.localPosition = new Vector3(posiX , _transform.localPosition.y, 0f);
    }
}
