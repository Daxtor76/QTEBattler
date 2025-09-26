using UnityEngine;

[CreateAssetMenu(fileName = "HealingEffect", menuName = "Scriptable Objects/Effects/HealingEffect")]
public class HealingEffect : Effect
{
    public float amount;
    public override float GetAmount() => amount;

    public override void Apply()
    {
        Debug.Log($"I do {amount} healing!");
    }
}