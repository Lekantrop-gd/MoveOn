using Model;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletView : MonoBehaviour
    {
        private Bullet _model;
        private Rigidbody2D _rigitBody;

        public void Initialize(Vector2 direction, float rotation, float movingSpeed)
        {
            _model = new Bullet(transform.position, rotation);
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);

            _rigitBody = GetComponent<Rigidbody2D>();
            _rigitBody.velocity = direction * movingSpeed;
        }
    }
}