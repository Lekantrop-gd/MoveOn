using DG.Tweening;
using GameObjects;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent (typeof(RectTransform))]
public class Score : MonoBehaviour
{
    [SerializeField] private float _textAnimationUpYPosition;
    [SerializeField] private float _textAnimationDownYPosition;
    [SerializeField] private float _textAnimationDuration;
    public int Amount {  get; private set; }
    
    private TextMeshProUGUI _text;
    private RectTransform _rectTransform;
    private Sequence _tweener;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponent<TextMeshProUGUI>();
        Amount = 0;
        _text.text = "0";
    }

    private void OnEnable()
    {
        Hero.OrbDestroyed += OnOrbDestroyed;
    }

    private void OnDisable()
    {
        Hero.OrbDestroyed -= OnOrbDestroyed;

        if (_tweener != null && _tweener.IsActive())
        {
            _tweener.Kill();
        }
    }

    private void OnOrbDestroyed()
    {
        _tweener = DOTween.Sequence()
            .Append(_rectTransform.DOAnchorPosY(_textAnimationUpYPosition, _textAnimationDuration, false).SetEase(Ease.InOutFlash))
            .AppendInterval(0.1f)
            .Append(_rectTransform.DOAnchorPosY(_textAnimationDownYPosition, _textAnimationDuration, false).SetEase(Ease.InOutFlash));

        Amount++; 
        _text.text = Amount.ToString();
    }
}
