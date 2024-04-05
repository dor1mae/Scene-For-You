using System;
using UnityEngine;

public abstract class AbstractObjectPresenter : MonoBehaviour
{
    [SerializeField] protected GameObject _prefabObject;
    [SerializeField] protected Transform _content;

    public abstract void PresentObjects();

    protected void CleanObjects()
    {
        foreach (Transform m in _content)
        {
            MonoBehaviour.Destroy(m.gameObject);
        }
    }
}
