using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableDatabase", menuName = "Items/ScriptableDatabase")]
public class ScriptableDatabase : ScriptableObject, IInit
{
    [SerializeField] private ItemEmpty[] items;
    
    private List<ItemEmpty> itemDatabase = new List<ItemEmpty>();

    public void Init()
    {
        foreach(var item in items)
        {
            itemDatabase.Add(item);
        }
    }

    public ItemEmpty GetItemForKey(string key)
    {
        if(itemDatabase.Count == 0)
        {
            Init();
        }

        return itemDatabase.Find(x => x.ID == key );
    }
}
