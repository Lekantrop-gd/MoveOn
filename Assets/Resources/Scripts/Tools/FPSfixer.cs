using UnityEngine;

public class FPSfixer : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }
}