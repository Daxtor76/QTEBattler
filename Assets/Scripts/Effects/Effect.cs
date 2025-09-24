using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string description;

    public abstract void Apply();
}