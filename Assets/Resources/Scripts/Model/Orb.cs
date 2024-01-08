using UnityEngine;

namespace Model
{
    public class Orb : Transformable
    {
        public Vector2 Scale { get; private set; }

        public Orb(Vector2 position, float rotation, Vector2 scale) : base(position, rotation) 
        {
            Scale = scale;
        }

        public void ScaleTo(Vector2 scale)
        {
            Scale = scale;
        }
    }
}