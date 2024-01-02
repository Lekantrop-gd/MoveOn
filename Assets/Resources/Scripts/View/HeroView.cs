using Input;
using Model;
using UnityEngine;

public class HeroView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;  

    private Hero _model;
    private HeroInputRouter _heroInput;

    private void Awake()
    {
        _model = new Hero(Vector2.zero, 0, _speed);
        _heroInput = new HeroInputRouter(_model, _camera);
    }

    private void Update()
    {
        _heroInput.Update();

        transform.position = _model.Position;
    }

    private void OnEnable()
    {
        _heroInput.OnEnable();
    }

    private void OnDisable()
    {
        _heroInput.OnDisable();
    }
}
