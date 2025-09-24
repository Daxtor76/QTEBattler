using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Scriptable Objects/Effects/DamageEffect")]
public class DamageEffect : Effect
{
    public int amount;
    public override void Apply()
    {
        throw new System.NotImplementedException();
    }
}