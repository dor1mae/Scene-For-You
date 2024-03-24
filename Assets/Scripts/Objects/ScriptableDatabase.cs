using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableDatabase", menuName = "Items/ScriptableDatabase")]
public class ScriptableDatabase : AbstractScriptableDatabase<ItemEmpty>, IInit
{

    public override ItemEmpty GetItemForKey(string key)
    {
        if(itemDatabase.Count == 0)
        {
            Init();
        }

        return itemDatabase.Find(x => x.ID == key );
    }
}
