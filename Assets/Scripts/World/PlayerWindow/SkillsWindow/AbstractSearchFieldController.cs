using UnityEngine;
using TMPro;

public abstract class AbstractSearchFieldController<Object>: MonoBehaviour
{
    [SerializeField] protected Object _target;

    public abstract void OnValueSubmit(TMP_InputField tMP_InputField);
}
