using Input;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameObjects
{
    public class Hero : MonoBehaviour
    {
        public static event Action OrbDestroyed;

        [SerializeField] private Camera _camera;
        [SerializeField] private Rope _rope;
        [SerializeField] private float _speed;

        private HeroInput _heroInput;
        private bool _moving;
        
        private void Awake()
        {
            _heroInput = new HeroInput();
        }

        private void OnEnable()
        {
            _heroInput.Enable();

            _heroInput.Hero.Touch.started += OnTouchStarted;
            _heroInput.Hero.Touch.canceled += OnTouchCanceled;
        }

        private void OnDisable()
        {
            _heroInput.Disable();

            _heroInput.Hero.Touch.started -= OnTouchStarted;
            _heroInput.Hero.Touch.canceled -= OnTouchCanceled;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Orb>(out var orb))
            {
                orb.Destroy();
                OrbDestroyed?.Invoke();
            }
        }

        private void OnTouchStarted(InputAction.CallbackContext context)
        {
            Vector2 cursorPosition = _heroInput.Hero.Position.ReadValue<Vector2>();

            Vector2 hitPoint = _camera.ScreenToWorldPoint(cursorPosition);
            RaycastHit2D hit = Physics2D.Raycast(hitPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent<Orb>(out var orb))
                {
                    if (Vector2.Distance(transform.position, orb.transform.position) <= _rope.Lengh)
                    {
                        _moving = true;
                        StartCoroutine(MoveTo(hitPoint));
                    }
                }
            }
        }

        private void OnTouchCanceled(InputAction.CallbackContext context)
        {
            _moving = false;
            _rope.UnHook();
        }

        private IEnumerator MoveTo(Vector2 target)
        {
            while ((Vector2)transform.position != target && _moving) 
            {
                transform.position = Vector2.Lerp(transform.position, target, _speed * Time.deltaTime);
                _rope.HookTo(transform.position, target, _speed);

                yield return null;
            }
        }
    }
}