using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;

    private int _minChildrensCount = 2;
    private int _maxChildrensCount = 6;
    private float _halfFactor = 0.5f;

    private void OnEnable()
    {
        CubeClicker.Clicked += ProcessCube;
    }

    private void OnDisable()
    {
        CubeClicker.Clicked -= ProcessCube;
    }

    private void ProcessCube(Cube cube) 
    {
        if (Random.value > cube.SplitChance)
        {
            _exploder.Explode(cube);

            Destroy(cube.gameObject);
            
            return;
        }

        int cubesCount = Random.Range(_minChildrensCount, _maxChildrensCount);

        List<Rigidbody> createdCubes = new List<Rigidbody>();

        for (int i = 0; i < cubesCount; i++)
        {
            Cube child = _spawner.Spawn(cube.transform.position, cube.transform.localScale * _halfFactor, cube.SplitChance * _halfFactor);

            _colorChanger.SetRandomColor(child);

            createdCubes.Add(child.GetComponent<Rigidbody>());
        }

        Destroy(cube.gameObject);
    }
}
