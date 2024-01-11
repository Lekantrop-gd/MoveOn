using GameObjects;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RopeText : MonoBehaviour
{
    [SerializeField] private Rope _rope;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        _text.text = "Rope: " + _rope.Lengh.ToString("n1") + "m";
    }
}
