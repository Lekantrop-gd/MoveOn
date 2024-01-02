using Model;
using UnityEngine;

namespace View
{
    public class OrbView : MonoBehaviour
    {
        private Orb _model;

        private void Update()
        {
            transform.position = _model.Position;
            transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
        }
    }
}