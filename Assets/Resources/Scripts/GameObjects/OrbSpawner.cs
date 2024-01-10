using Model;
using System.Collections;
using UnityEngine;

namespace GameObjects
{
    public class OrbSpawner : MonoBehaviour
    {
        [SerializeField] private OrbView _orbPrefab;
        [SerializeField] private Transform _spawnCentre;
        [SerializeField] private float _spawnRange;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private int _prewarmedOrbsCount;

        private WaitForSeconds _waitTime;
        private OrbPool _pool;

        private void Awake()
        {
            _pool = new OrbPool(_orbPrefab, _prewarmedOrbsCount);

            _waitTime = new WaitForSeconds(_spawnDelay);
            StartCoroutine(StartSpawning());
        }

        private IEnumerator StartSpawning()
        {
            while (true)
            {
                Vector2 spawnPoint = Random.insideUnitCircle * _spawnRange;

                Vector2 hitPoint = Camera.main.ScreenToWorldPoint((Vector2)_spawnCentre.position + spawnPoint);
                RaycastHit2D hit = Physics2D.Raycast(hitPoint, Vector2.zero);

                if (hit.collider == null)
                    _pool.Get().Initialize((Vector2)_spawnCentre.position + spawnPoint, 0, new Vector2(1, 1));
                
                yield return _waitTime;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_spawnCentre != null)
            {
                Gizmos.DrawWireSphere(_spawnCentre.position, _spawnRange);
            }
        }

        private void OnEnable()
        {
            OrbView.Destroyed += OnOrbDestroyed;
        }

        private void OnDisable()
        {
            OrbView.Destroyed -= OnOrbDestroyed;
        }

        private void OnOrbDestroyed(OrbView orb)
        {
            _pool.Release(orb);
        }
    }
}