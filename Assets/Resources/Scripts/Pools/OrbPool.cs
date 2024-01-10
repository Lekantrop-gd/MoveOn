using GameObjects;
using UnityEngine;
using UnityEngine.Pool;

namespace Pools
{
    public class OrbPool
    {
        private ObjectPool<OrbView> _pool;
        private OrbView _prefab;

        public OrbPool(OrbView prefab, int prewarmedOrbsCount)
        {
            _prefab = prefab;
            _pool = new ObjectPool<OrbView>(OnCreateOrb, OnGetOrb, OnRelease, OnOrbDestroy, false, prewarmedOrbsCount);
        }

        public OrbView Get()
        {
            var orb = _pool.Get();
            return orb;
        }

        public void Release(OrbView orb)
        {
            _pool.Release(orb);
        }

        private void OnOrbDestroy(OrbView orb)
        {
            GameObject.Destroy(orb);
        }

        private void OnRelease(OrbView orb)
        {
            orb.gameObject.SetActive(false);
        }

        private void OnGetOrb(OrbView orb)
        {
            orb.gameObject.SetActive(true);
        }

        private OrbView OnCreateOrb()
        {
            return GameObject.Instantiate(_prefab);
        }
    }
}