using UnityEngine;

namespace GameObjects
{
    [RequireComponent(typeof(LineRenderer))]
    public class Rope : MonoBehaviour
    {
        [SerializeField] private float _startLenght;

        public float Lenght { get; private set; }

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            Lenght = _startLenght;

            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 2;
        }

        public void HookTo(Vector2 target)
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, target);
            _lineRenderer.enabled = true;
        }

        public void UnHook()
        {
            _lineRenderer.enabled = false;
        }
    }
}