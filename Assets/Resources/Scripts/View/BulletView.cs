using Model;
using System;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletView : MonoBehaviour
    {
        private Bullet _model;
        private Rigidbody2D _rigitBody;

        public static event Action<BulletView> Used;

        public void Initialize(Vector2 startPosition, Vector2 direction, float rotation, float movingSpeed)
        {
            _model = new Bullet(startPosition, rotation);
            transform.position = _model.Position;
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);

            _rigitBody = GetComponent<Rigidbody2D>();
            _rigitBody.velocity = direction * movingSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<OrbView>(out var orb)) {
                orb.Destroy();
                Used?.Invoke(this);
            }

            if (collision.gameObject.TryGetComponent<HeroView>(out var hero))
            {
                //hero.Kill();
                Used?.Invoke(this);
            }
        }
    }
}