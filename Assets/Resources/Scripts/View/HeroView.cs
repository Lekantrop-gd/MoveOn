using Input;
using Model;
using UnityEngine;

namespace View
{
    public class HeroView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _speed;

        private Hero _model;
        private HeroInputRouter _heroInput;

        private void Awake()
        {
            _model = new Hero(transform.position, transform.rotation.z, _speed);
            _heroInput = new HeroInputRouter(_camera, _model);
        }

        private void Update()
        {
            _heroInput.Update();

            transform.position = _model.Position;
        }

        private void OnEnable()
        {
            _heroInput.OnEnable();
        }

        private void OnDisable()
        {
            _heroInput.OnDisable();
        }
    }
}