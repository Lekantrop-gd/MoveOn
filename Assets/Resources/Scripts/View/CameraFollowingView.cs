using Model;
using UnityEngine;

namespace View
{
    public class CameraFollowingView : MonoBehaviour
    {
        [SerializeField] private HeroView _hero;
        [SerializeField] private float _followingSpeed;

        private CameraFollowing _model;

        private void Awake()
        {
            _model = new CameraFollowing(transform.position, transform.rotation.z, _followingSpeed);
        }

        private void Update()
        {
            _model.MoveTo(_hero.transform.position);

            transform.position = new Vector3(_model.Position.x, _model.Position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
        }
    }
}