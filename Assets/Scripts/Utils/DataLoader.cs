using System.Collections.Generic;
using UnistrokeGestureRecognition;
using UnityEngine;

public static class DataLoader
{
    private const string SPELLS_PATH = "Spells";
    private const string GESTURE_PATTERNS_PATH = "GesturePatterns";

    private static Dictionary<string, Spell> spells = new Dictionary<string, Spell>();
    public static Dictionary<string, Spell> Spells => spells;

    private static List<GesturePattern> gesturePatterns = new List<GesturePattern>();
    public static List<GesturePattern> GesturePatterns => gesturePatterns;

    public static void LoadInitData()
    {
        spells = LoadAllResourcesOfTypeAtPathAsDico<Spell>(SPELLS_PATH);
        gesturePatterns = LoadAllResourcesOfTypeAtPathAsList<GesturePattern>(GESTURE_PATTERNS_PATH);
    }

    private static List<T> LoadAllResourcesOfTypeAtPathAsList<T>(string path) where T : Object
    {
        List<T> list = new List<T>();

        foreach (T obj in Resources.LoadAll(path))
            list.Add(obj);

        return list;
    }

    private static Dictionary<string, T> LoadAllResourcesOfTypeAtPathAsDico<T>(string path) where T : Object
    {
        Dictionary<string, T> dico = new Dictionary<string, T>();

        foreach (T obj in Resources.LoadAll(path))
        {
            if (!dico.ContainsKey(obj.name))
                dico.Add(obj.name, obj);
            else
                throw new System.Exception($"{obj.name} already exist in collection");
        }

        return dico;
    }
}
