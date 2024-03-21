using System;
using System.Collections;
using UnityEngine;

public abstract class AbstractActionPoint : InitClass, IActionPoint
{
    [SerializeField] protected bool _isBusy;
    [SerializeField] protected float _costOfAction;
    [SerializeField] protected int _sizeOfUpgrade;
    [SerializeField] protected TimeStates[] _statesList;

    public Action ActionDone;
    public bool IsBusy => _isBusy;
    public float CostOfAction => _costOfAction;

    public int SizeOfUpgrade => _sizeOfUpgrade;

    public override void Init()
    {
        EventBus.onActionReady?.Invoke(this);
        Debug.Log($"{GetType()}: is initialized");
    }

    public bool IsAvailable()
    {
        bool flag = false;
        var state = TimeManager.onTestTime.Invoke();

        foreach (var t in _statesList)
        {
            if (state == t)
            {
                flag = true;
            }
        }

        return flag;
    }

    public abstract IEnumerator OnAction(Player pl);

    public abstract void OnNpcAction();
    public bool CanItAction(Player pl, float c)
    {
        if (pl.Endurance.Value - c < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                StartCoroutine(OnAction(collision.GetComponentInParent<Player>()));
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log($"{this.GetType()}:OnTriggerStay2D: body is staying");
        }
    }
}
