using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractScriptableDatabase<T> : ScriptableObject
{
    [SerializeField] protected T[] items;

    protected List<T> itemDatabase = new List<T>();

    public void Init()
    {
        foreach (var item in items)
        {
            itemDatabase.Add(item);
        }
    }

    public abstract T GetItemForKey(string key);
}
