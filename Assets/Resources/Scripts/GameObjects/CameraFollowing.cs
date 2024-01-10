using UnityEngine;

namespace GameObjects
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(_hero.transform.position.x, _hero.transform.position.y, transform.position.z), 
                _speed * Time.deltaTime
                );
        }
    }
}