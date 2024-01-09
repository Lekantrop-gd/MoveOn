using View;
using UnityEngine;
using UnityEngine.Pool;

namespace Model
{
    public class BulletPool
    {
        private ObjectPool<BulletView> _pool;
        private BulletView _prefab;

        public BulletPool(BulletView prefab, int prewarmedBulletsCount)
        {
            _prefab = prefab;
            _pool = new ObjectPool<BulletView>(OnCreateBullet, OnGetBullet, OnRelease, OnBulletDestroy, false, prewarmedBulletsCount);
        }

        public BulletView Get()
        {
            var bullet = _pool.Get();
            return bullet;
        }

        public void Release(BulletView bullet)
        {
            _pool.Release(bullet);
        }

        private void OnBulletDestroy(BulletView bullet)
        {
            GameObject.Destroy(bullet);
        }

        private void OnRelease(BulletView bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnGetBullet(BulletView bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private BulletView OnCreateBullet()
        {
            return GameObject.Instantiate(_prefab);
        }
    }
}