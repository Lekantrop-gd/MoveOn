using GameObjects;
using UnityEngine;
using UnityEngine.Pool;

namespace Pools
{
    public class BulletPool
    {
        private ObjectPool<Bullet> _pool;
        private Bullet _prefab;

        public BulletPool(Bullet prefab, int prewarmedBulletsCount)
        {
            _prefab = prefab;
            _pool = new ObjectPool<Bullet>(OnCreateBullet, OnGetBullet, OnRelease, OnBulletDestroy, false, prewarmedBulletsCount);
        }

        public Bullet Get()
        {
            var bullet = _pool.Get();
            return bullet;
        }

        public void Release(Bullet bullet)
        {
            _pool.Release(bullet);
        }

        private void OnBulletDestroy(Bullet bullet)
        {
            GameObject.Destroy(bullet);
        }

        private void OnRelease(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnGetBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private Bullet OnCreateBullet()
        {
            return GameObject.Instantiate(_prefab);
        }
    }
}