using Pools;
using UnityEngine;

namespace GameObjects
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _bulletsSpeed;
        [SerializeField] private int _prewarmedBulletsCount;
        [SerializeField] private Hero _hero;
        [SerializeField] private float _followingSpeed;
        [SerializeField] private float _minDistanceToPlayer;

        private BulletPool _pool;

        private void Awake()
        {
            _pool = new BulletPool(_bulletPrefab, _prewarmedBulletsCount);
            InvokeRepeating(nameof(SpawnBullet), 1, 1);
        }

        private void Update()
        {
            Vector2 position = transform.position;
            Vector2 target = _hero.transform.position;

            if (Vector2.Distance(position, target) > _minDistanceToPlayer)
            {
                transform.position = Vector2.MoveTowards(position, target, Time.deltaTime * _followingSpeed);
            }

            Vector2 direction = target - position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void SpawnBullet()
        {
            _pool.Get().Initialize(transform.position, _hero.transform.position - transform.position, transform.rotation, _bulletsSpeed);
        }

        private void OnEnable()
        {
            Bullet.Used += OnBulletUsed;
        }

        private void OnDisable()
        {
            Bullet.Used -= OnBulletUsed;
        }

        private void OnBulletUsed(Bullet bullet)
        {
            _pool.Release(bullet);
        }
    }
}