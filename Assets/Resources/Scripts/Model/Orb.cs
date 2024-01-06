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

        public void ResizeTo(Vector2 scale, float resizingSpeed)
        {
            Scale = Vector2.MoveTowards(Scale, scale, resizingSpeed);
        }
    }
}