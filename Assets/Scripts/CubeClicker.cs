using System;
using UnityEngine;

public class CubeClicker : MonoBehaviour
{
    private Cube _cube;

    public static event Action<Cube> Clicked;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(_cube);
    }
}
