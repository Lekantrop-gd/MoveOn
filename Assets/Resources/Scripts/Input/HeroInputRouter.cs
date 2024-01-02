using Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class HeroInputRouter
    {
        private Hero _hero;
        private HeroInput _input;
        private Camera _camera;
        private Vector2 _target;

        public HeroInputRouter(Hero hero, Camera camera)
        {
            _input = new HeroInput();
            _hero = hero;
            _camera = camera;
        }

        private void OnTouch(InputAction.CallbackContext context)
        {
            _target = _camera.ScreenToWorldPoint(_input.Hero.Position.ReadValue<Vector2>());
        }

        public void Update()
        {
            _hero.MoveTo(_target);
        }

        public void OnEnable()
        {
            _input.Enable();

            _input.Hero.Touch.started += OnTouch;
        }

        public void OnDisable()
        {
            _input.Disable();

            _input.Hero.Touch.started -= OnTouch;
        }
    }

}