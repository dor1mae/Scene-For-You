using System.Collections.Generic;
using UnityEngine;

public class ItemSearchController
{
    private Inventory _inventory;

    public ItemSearchController(Inventory inv)
    {
        _inventory = inv;
    }

    public List<RealItem> SearchItems()
    {
        var stringSearch = EquipmentWindow.SearchString;
        var tagSearchList = EquipmentWindow.SearchTagList;

        Debug.Log($"{GetType()}: stringSearch = {stringSearch}, tagSearchList = {tagSearchList}");

        List<RealItem> temp = _inventory.GetItems();
        List<RealItem> newTemp = new List<RealItem>();

        if (stringSearch == "" || stringSearch == null)
        {
            if (tagSearchList.Count == 0)
            {
                return temp;
            }
            else
            {
                foreach (var t in tagSearchList)
                {
                    newTemp.AddRange(temp.FindAll(x => (x.Item._equipmentType == t && !newTemp.Contains(x))));
                }

                return newTemp;
            }
        }
        else
        {
            if (tagSearchList.Count == 0)
            {
                newTemp.AddRange(temp.FindAll(x => x.Item.Name.Contains(stringSearch)));

                return newTemp;
            }
            else
            {
                List<RealItem> newTemp2 = new List<RealItem>();

                newTemp.AddRange(temp.FindAll(x => x.Item.Name.Contains(stringSearch)));

                foreach (var t in tagSearchList)
                {
                    newTemp2.AddRange(newTemp.FindAll(x => (x.Item._equipmentType == t && !newTemp2.Contains(x))));
                }

                return newTemp2;
            }
        }
    }
}

