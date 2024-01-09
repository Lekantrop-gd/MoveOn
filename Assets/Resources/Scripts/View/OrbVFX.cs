using UnityEngine;

namespace View
{
    public class OrbVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _orbDestroyingVFX;

        private void OnEnable()
        {
            OrbView.Destroyed += OnOrbDestroyed;
        }

        private void OnDisable()
        {
            OrbView.Destroyed -= OnOrbDestroyed;
        }

        private void OnOrbDestroyed(OrbView view)
        {
            var orbVFX = Instantiate(_orbDestroyingVFX, view.transform.position, Quaternion.identity);
            GameObject.Destroy(orbVFX.gameObject, _orbDestroyingVFX.main.duration);
        }
    }
}