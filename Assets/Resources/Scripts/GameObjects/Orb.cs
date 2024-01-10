using System;
using System.Collections;
using UnityEngine;

namespace GameObjects
{
    public class Orb : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed;

        public static event Action<Orb> Destroyed;

        public void Initialize(Vector2 position, float rotation, Vector2 scale)
        {
            transform.position = position;
            transform.localScale = Vector2.zero;

            StartCoroutine(Appear(scale));
        }

        private IEnumerator Appear(Vector2 finalScale)
        {
            while ((Vector2)transform.localScale != finalScale)
            {
                transform.localScale = Vector2.MoveTowards(transform.localScale, finalScale, Time.deltaTime * _animationSpeed);
                
                yield return null;
            }
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}