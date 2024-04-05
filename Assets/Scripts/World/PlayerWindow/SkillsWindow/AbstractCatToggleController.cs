using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractCatToggleController<Object, ENUMType> : MonoBehaviour
{
    [SerializeField] protected Object _target;
    [SerializeField] protected ENUMType _type;

    public abstract void OnToggleValueChanged(Toggle change);
}
