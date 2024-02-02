﻿using UnityEngine;
using UnityEngine.Events;

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
        [SerializeField] private UnityEvent _onShoot;

        private CustomUnityPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new CustomUnityPool<Bullet>(_bulletPrefab, _prewarmedBulletsCount);
            InvokeRepeating(nameof(Shoot), 1, 1);
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

        private void Shoot()
        {
            _pool.Get().Initialize(transform.position, (_hero.transform.position - transform.position).normalized, transform.rotation, _bulletsSpeed);
            _onShoot?.Invoke();
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