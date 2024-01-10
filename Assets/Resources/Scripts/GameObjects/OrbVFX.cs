using UnityEngine;

namespace GameObjects
{
    public class OrbVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _orbDestroyingVFX;

        private void OnEnable()
        {
            Orb.Destroyed += OnOrbDestroyed;
        }

        private void OnDisable()
        {
            Orb.Destroyed -= OnOrbDestroyed;
        }

        private void OnOrbDestroyed(Orb view)
        {
            var orbVFX = Instantiate(_orbDestroyingVFX, view.transform.position, Quaternion.identity);
            GameObject.Destroy(orbVFX.gameObject, _orbDestroyingVFX.main.duration);
        }
    }
}