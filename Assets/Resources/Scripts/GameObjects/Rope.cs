using UnityEngine;

namespace GameObjects
{
    [RequireComponent(typeof(LineRenderer))]
    public class Rope : MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 2;
        }

        public void HookTo(Vector2 startPosition, Vector2 endPosition)
        {
            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);
            _lineRenderer.enabled = true;
        }

        public void UnHook()
        {
            _lineRenderer.enabled = false;
        }
    }
}