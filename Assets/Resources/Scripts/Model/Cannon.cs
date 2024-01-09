using UnityEngine;

namespace Model
{
    public class Cannon : Transformable
    {
        private float _movingSpeed;
        private float _minDistanceToPlayer;

        public Cannon(Vector2 position, float rotation, float movingSpeed, float minDistanceToPlayer) : base(position, rotation)
        {
            _movingSpeed = movingSpeed;
            _minDistanceToPlayer = minDistanceToPlayer;
        }

        public void MoveTo(Vector2 target)
        {
            if (Vector2.Distance(Position, target) > _minDistanceToPlayer)
            {
                Position = Vector2.MoveTowards(Position, target, _movingSpeed * Time.deltaTime);
            }
        }

        public void LookAt(Vector2 target)
        {
            Vector2 direction = target - Position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Rotation = angle;
        }
    }
}

