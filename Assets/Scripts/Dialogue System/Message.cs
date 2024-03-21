using UnityEngine;
using UnityEngine.UI;

//Скрипт для заполнения элементов компонента сообщения в текстовой области
public class Message : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _text;

    public void SetData(string n, string m)
    {
        _name.text = n;
        _text.text = m;
    }
}
