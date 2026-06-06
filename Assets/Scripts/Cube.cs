using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;

    public float Size => transform.localScale.x;

    public float SplitChance => _splitChance;

    public float SetSplitChance(float chance) => _splitChance = chance;
}