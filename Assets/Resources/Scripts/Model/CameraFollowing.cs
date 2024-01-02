using UnityEngine;

namespace Model
{
    public class CameraFollowing : Transformable
    {
        private float _movingSpeed;

        public CameraFollowing(Vector2 position, float rotation, float movingSpeed) : base(position, rotation)
        {
            _movingSpeed = movingSpeed;
        }

        public void MoveTo(Vector2 target)
        {
            Position = Vector2.Lerp(Position, target, _movingSpeed * Time.deltaTime);
        }
    }
}