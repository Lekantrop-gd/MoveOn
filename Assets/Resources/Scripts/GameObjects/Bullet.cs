﻿using System;
using UnityEngine;

namespace GameObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigitBody;

        public static event Action<Bullet> Used;

        public void Initialize(Vector2 startPosition, Vector2 direction, Quaternion rotation, float movingSpeed)
        {
            transform.position = startPosition;
            transform.rotation = rotation;

            _rigitBody = GetComponent<Rigidbody2D>();
            _rigitBody.velocity = direction * movingSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Orb>(out var orb)) {
                orb.Destroy();
                Used?.Invoke(this);
            }

            if (collision.gameObject.TryGetComponent<Hero>(out var hero))
            {
                //hero.Kill();
                Used?.Invoke(this);
            }
        }
    }
}