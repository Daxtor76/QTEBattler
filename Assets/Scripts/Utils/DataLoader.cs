using System.Collections.Generic;
using UnityEngine;

public static class DataLoader
{
    private const string SPELLS_PATH = "Spells";

    private static Dictionary<string, Spell> spells = new Dictionary<string, Spell>();
    public static Dictionary<string, Spell> Spells => spells;

    public static void LoadInitData()
    {
        spells = LoadAllResourcesOfTypeAtPath<Spell>(SPELLS_PATH);
    }

    private static Dictionary<string, T> LoadAllResourcesOfTypeAtPath<T>(string path) where T : Object
    {
        Dictionary<string, T> dico = new Dictionary<string, T>();

        foreach (T obj in Resources.LoadAll(path))
            dico.Add(obj.name, obj);

        return dico;
    }
}
