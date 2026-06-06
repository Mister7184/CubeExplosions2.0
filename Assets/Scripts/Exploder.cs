using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 500f;
    [SerializeField] private float _baseExplosionRadius = 10f;
    
    public void Explode(Cube cube)
    {
        Debug.Log("Boom");

        float multiplier = 1f / cube.Size;

        float force = _baseExplosionForce * multiplier;

        float radius = _baseExplosionRadius * multiplier;

        Collider[] cubeColliders = Physics.OverlapSphere(cube.transform.position, radius);

        foreach (Collider cubeCollider in cubeColliders)
        {
            Rigidbody cubeRigidbody = cubeCollider.GetComponent<Rigidbody>();

            if (cubeRigidbody == null)
                continue;

            cubeRigidbody.AddExplosionForce(force, cube.transform.position, radius);
        }
    }
}
