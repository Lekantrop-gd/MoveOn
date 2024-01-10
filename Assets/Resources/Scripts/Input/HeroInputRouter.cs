using Model;
using UnityEngine;
using UnityEngine.InputSystem;
using View;

namespace Input
{
    public class HeroInputRouter
    {
        private Hero _model;
        private HeroInput _input;
        private Camera _camera;
        private Vector2 _target;

        public HeroInputRouter(Camera camera, Hero hero)
        {
            _input = new HeroInput();
            _camera = camera;
            _model = hero;
        }

        private void OnTouchStarted(InputAction.CallbackContext context)
        {
            Vector2 hitPoint = _camera.ScreenToWorldPoint(_input.Hero.Position.ReadValue<Vector2>());
            RaycastHit2D hit = Physics2D.Raycast(hitPoint, Vector2.zero);

            if (hit.collider != null)
                if (hit.collider.gameObject.TryGetComponent<OrbView>(out var orb))
                    _target = _camera.ScreenToWorldPoint(_input.Hero.Position.ReadValue<Vector2>());
        }

        private void OnTouchCanceled(InputAction.CallbackContext context)
        {
            _target = _model.Position;
        }

        public void Update()
        {
            _model.MoveTo(_target);
        }

        public void OnEnable()
        {
            _input.Enable();

            _input.Hero.Touch.started += OnTouchStarted;
            _input.Hero.Touch.canceled += OnTouchCanceled;
        }

        public void OnDisable()
        {
            _input.Disable();

            _input.Hero.Touch.started -= OnTouchStarted;
            _input.Hero.Touch.canceled -= OnTouchCanceled;
        }
    }

}