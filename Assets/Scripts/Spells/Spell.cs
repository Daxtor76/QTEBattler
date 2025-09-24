using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Scriptable Objects/Spell")]
public class Spell : ScriptableObject
{
    [SerializeField] private string spellName;
    [SerializeField] private List<Effect> effects;

    public string SpellName => spellName;
    public List<Effect> Effects => effects;

    public virtual void Launch()
    {
        foreach (Effect e in effects)
            e.Apply();
    }
}
