using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Cube _cubePrefab;

    public Cube Spawn(Vector3 position, Vector3 scale, float splitChance) 
    {
        Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity);

        cube.transform.localScale = scale;

        cube.SetSplitChance(splitChance);

        return cube;
    }
}
