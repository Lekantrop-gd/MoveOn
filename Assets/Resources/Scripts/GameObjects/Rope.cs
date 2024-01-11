using UnityEngine;

namespace GameObjects
{
    [RequireComponent(typeof(LineRenderer))]
    public class Rope : MonoBehaviour
    {
        [SerializeField] private float _startLenght;
        [SerializeField] private float _recoverySpeed;

        public float Lengh { get; private set; }

        private LineRenderer _lineRenderer;
        private bool _hooked;

        private void Awake()
        {
            Lengh = _startLenght;

            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 2;
        }

        private void Update()
        {
            if (_hooked == false)
                Lengh += _recoverySpeed * Time.deltaTime;
        }

        public void HookTo(Vector2 startPosition, Vector2 endPosition, float movingSpeed)
        {
            _hooked = true;

            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);
            _lineRenderer.enabled = true;

            Lengh = Mathf.Lerp(Lengh, Lengh - Vector2.Distance(startPosition, endPosition), Time.deltaTime * movingSpeed);
        }

        public void UnHook()
        {
            _lineRenderer.enabled = false;
            _hooked = false;
        }
    }
}