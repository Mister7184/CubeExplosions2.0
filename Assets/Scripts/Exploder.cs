using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 5f;
    [SerializeField] private float _baseExplosionRadius = 2f;
    
    public void Explode(Cube cube)
    {
        float multiplier = 1f / cube.Size;

        float force = _baseExplosionForce * multiplier;

        float radius = _baseExplosionRadius * multiplier;

        Collider[] cubeColliders = Physics.OverlapSphere(cube.transform.position, radius);

        foreach (Collider cubeCollider in cubeColliders)
        {
            Rigidbody cubeRigidbody = cubeCollider.GetComponent<Rigidbody>();

            if (cubeRigidbody != null)
                continue;

            cubeRigidbody.AddExplosionForce(force, cube.transform.position, radius);
        }
    }
}
