using Model;
using System;
using System.Collections;
using UnityEngine;

namespace View
{
    public class OrbView : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed;

        private Orb _model;

        public static event Action<OrbView> Destroyed;

        private void Update()
        {
            if (_model != null)
            {
                transform.position = _model.Position;
                transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
                transform.localScale = _model.Scale;
            }
        }

        public void Initialize(Vector2 position, float rotation, Vector2 scale)
        {
            _model = new Orb(position, rotation, Vector2.zero);

            transform.position = position;
            transform.localScale = Vector2.zero;

            StartCoroutine(Appear(scale));
        }

        private IEnumerator Appear(Vector2 finalScale)
        {
            while (_model.Scale != finalScale)
            {
                _model.ScaleTo(Vector2.MoveTowards(_model.Scale, finalScale, Time.deltaTime * _animationSpeed));
                yield return null;
            }
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}