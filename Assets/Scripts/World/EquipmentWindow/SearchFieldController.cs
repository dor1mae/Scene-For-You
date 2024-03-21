using UnityEngine;
using UnityEngine.UI;

public class SearchFieldController : MonoBehaviour
{
    public void OnValueSubmit(InputField inputField)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EquipmentWindow.SearchString = inputField.text;
            EquipmentWindow.OnSearch?.Invoke();
        }
    }
}
