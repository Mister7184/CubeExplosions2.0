using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandomColor(Cube cube) 
    {
        Renderer renderer = cube.GetComponent<Renderer>();

        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
