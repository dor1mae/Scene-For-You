using UnityEngine;
using UnityEngine.UI;

public class SearchCatToggle : MonoBehaviour
{
    [SerializeField] private EquipmentType _category;

    public void OnToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            EquipmentWindow.SearchTagList.Add(_category);
            EquipmentWindow.OnSearch?.Invoke();
        }
        else
        {
            EquipmentWindow.SearchTagList?.RemoveAll(x => x == _category);
            EquipmentWindow.OnSearch?.Invoke();
        }
    }
}
