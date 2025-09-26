using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string description;

    public virtual float GetAmount() => 0.0f;

    public abstract void Apply();
}