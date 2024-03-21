using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string _name;
    [SerializeField] private Image _sprite;
    [SerializeField][TextArea(3, 5)] private string _words;

    public string Name
    {
        get { return _name; }
    }

    public Image Sprite
    {
        get
        {
            return _sprite;
        }
    }
    public string Words
    {
        get
        {
            return _words;
        }
    }
}