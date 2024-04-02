using System;
using UnityEngine;

public abstract class AbstractObjectPresenter : MonoBehaviour
{
    [SerializeField] protected GameObject _prefabObject;
    protected Transform _content;

    public AbstractObjectPresenter(GameObject prefabObject, Transform content)
    {
        _prefabObject = prefabObject;
        _content = content;
    }

    public abstract void PresentObjects();

    protected void CleanObjects()
    {
        foreach (Transform m in _content)
        {
            MonoBehaviour.Destroy(m.gameObject);
        }
    }
}
