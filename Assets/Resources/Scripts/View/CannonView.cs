using Model;
using UnityEngine;

namespace View
{
    public class CannonView : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _followingSpeed;
        [SerializeField] private float _minDistanceToPlayer;

        private Cannon _model;

        private void Awake()
        {
            _model = new Cannon(transform.position, transform.rotation.z, _followingSpeed, _minDistanceToPlayer);
        }

        private void Update()
        {
            _model.MoveTo(_player.position);
            _model.LookAt(_player.position);

            transform.position = _model.Position; 
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
        }
    }
}