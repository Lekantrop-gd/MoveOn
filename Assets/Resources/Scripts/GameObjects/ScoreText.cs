using DG.Tweening;
using GameObjects;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent (typeof(RectTransform))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private float _textAnimationUpYPosition;
    [SerializeField] private float _textAnimationDownYPosition;
    [SerializeField] private float _textAnimationDuration;
    public int Score {  get; private set; }
    
    private TextMeshProUGUI _text;
    private RectTransform _rectTransform;

    private void Awake()
    {
        Score = 0;
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Hero.OrbDestroyed += OnOrbDestroyed;
    }

    private void OnDisable()
    {
        Hero.OrbDestroyed -= OnOrbDestroyed;
    }

    private void OnOrbDestroyed()
    {
        DOTween.Sequence()
            .Append(_rectTransform.DOAnchorPosY(_textAnimationUpYPosition, _textAnimationDuration, false).SetEase(Ease.InOutFlash))
            .AppendInterval(0.1f)
            .Append(_rectTransform.DOAnchorPosY(_textAnimationDownYPosition, _textAnimationDuration, false).SetEase(Ease.InOutFlash));
        
        Score++; 
        _text.text = Score.ToString();
    }
}
