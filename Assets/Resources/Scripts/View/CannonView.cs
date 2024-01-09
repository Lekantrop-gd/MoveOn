using Model;
using System;
using UnityEngine;

namespace View
{
    public class CannonView : MonoBehaviour
    {
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private float _bulletsSpeed;
        [SerializeField] private int _prewarmedBulletsCount;
        [SerializeField] private Transform _player;
        [SerializeField] private float _followingSpeed;
        [SerializeField] private float _minDistanceToPlayer;

        private Cannon _model;
        private BulletPool _pool;

        private void Awake()
        {
            _model = new Cannon(transform.position, transform.rotation.z, _followingSpeed, _minDistanceToPlayer);
            _pool = new BulletPool(_bulletPrefab, _prewarmedBulletsCount);
            InvokeRepeating(nameof(SpawnBullet), 1, 1);
        }

        private void Update()
        {
            _model.MoveTo(_player.position);
            _model.LookAt(_player.position);

            transform.position = _model.Position; 
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
        }

        private void SpawnBullet()
        {
            _pool.Get().Initialize(transform.position, (Vector2)_player.position - _model.Position, _model.Rotation, _bulletsSpeed);
        }

        private void OnEnable()
        {
            BulletView.Used += OnBulletUsed;
        }

        private void OnDisable()
        {
            BulletView.Used -= OnBulletUsed;
        }

        private void OnBulletUsed(BulletView bullet)
        {
            _pool.Release(bullet);
        }
    }
}