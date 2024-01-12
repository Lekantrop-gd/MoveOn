using DG.Tweening;
using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class ScaleAnimator : MonoBehaviour
{
    [SerializeField] private float _maxScale;
    [SerializeField] private float _minScale;
    [SerializeField] private float _animationDuration;

    private RectTransform _rectTransform;
    private Sequence _tweener;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _tweener = DOTween.Sequence()
            .Append(_rectTransform.DOScale(_maxScale, _animationDuration))
            .Append(_rectTransform.DOScale(_minScale, _animationDuration))
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        if (_tweener != null && _tweener.IsActive())
        {
            _tweener.Kill();
        }
    }
}
