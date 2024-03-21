using UnityEngine;

public class ClassicBootstrap : MonoBehaviour
{
    [SerializeField] private InitClass[] _monobehs;

    public void Start()
    {
        foreach (var v in _monobehs)
        {
            v.Init();
        }
    }
}
