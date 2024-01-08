using Model;
using System.Collections;
using UnityEngine;

namespace View
{
    public class OrbView : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed;

        private Orb _model;
        private Vector2 _scale;

        public void Initialize(Vector2 position, float rotation, Vector2 scale)
        {
            _model = new Orb(position, rotation, Vector2.zero);
            _scale = scale;

            transform.position = position;
            transform.localScale = Vector2.zero;

            StartCoroutine(Appear());
        }

        private IEnumerator Appear()
        {
            while (_model.Scale != _scale)
            {
                _model.ScaleTo(Vector2.MoveTowards(_model.Scale, _scale, Time.deltaTime * _animationSpeed));
                yield return null;
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (_model != null)
            {
                transform.position = _model.Position;
                transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
                transform.localScale = _model.Scale;
            }
        }
    }
}