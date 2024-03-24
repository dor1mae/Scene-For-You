using UnityEngine;
/// <summary>
/// Класс для хранения ссылок на сохранения игрока
/// </summary>
[CreateAssetMenu(fileName = "ScriptableDatabase", menuName = "Items/SaveScriptableDatabase")]
public class SaveScriptableDatabase: AbstractScriptableDatabase<SaveScriptableObject>
{
    public override SaveScriptableObject GetItemForKey(string key)
    {
        if (itemDatabase.Count == 0)
        {
            Init();
        }

        return itemDatabase.Find(x => x.SaveName == key);
    }

    public void Save(string saveName)
    {
        if(GetItemForKey(saveName) == null)
        {
            var save = CreateInstance<SaveScriptableObject>();
            save.SetSave(saveName);

            itemDatabase.Add(save);
        }
    }

    public void Delete(string saveName)
    {
        if (GetItemForKey(saveName) != null)
        {
            var save = CreateInstance<SaveScriptableObject>();

            itemDatabase.Remove(save);
            Destroy(save);
        }
    }
}
