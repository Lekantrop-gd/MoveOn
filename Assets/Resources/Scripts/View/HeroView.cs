using Input;
using Model;
using UnityEngine;

namespace View
{
    public class HeroView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _speed;

        [SerializeField] private LineRenderer _rope;
        [SerializeField] private float _startRopeLenght;
        [SerializeField] private float _ropeIncreaseDelta;

        private Hero _model;
        private HeroInputRouter _heroInput;

        private void Awake()
        {
            _model = new Hero(transform.position, transform.rotation.z, _speed);
            _heroInput = new HeroInputRouter(_camera, _model, _startRopeLenght, _ropeIncreaseDelta);
        }

        private void Update()
        {
            _heroInput.Update();
            
            transform.position = _model.Position;
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
        }

        private void OnEnable()
        {
            _heroInput.OnEnable();
        }

        private void OnDisable()
        {
            _heroInput.OnDisable();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<OrbView>(out var orb))
            {
                orb.Destroy();
            }
        }
    }
}