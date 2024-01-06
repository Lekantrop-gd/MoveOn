using Model;
using UnityEngine;

namespace View
{
    public class OrbView : MonoBehaviour
    {
        private Orb _model;

        public OrbView(Vector2 position, float rotation, Vector2 scale)
        {
            _model = new Orb(position, rotation, scale);
        }
    }
}