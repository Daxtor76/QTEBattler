using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Scriptable Objects/Effects/DamageEffect")]
public class DamageEffect : Effect
{
    private float amount;

    public override float GetAmount() => amount;

    public override void Apply()
    {
        Debug.Log($"I do {amount} damages!");
    }
}