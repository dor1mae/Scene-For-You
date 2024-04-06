using System.Collections.Generic;
using UnityEngine;

public class EffectsController : InitClass
{
    [SerializeField] private GameObject _effectsBar;

    private List<IEffect> _effectsList;

    public override void Init()
    {
        EventBus.TurnEnded += OnEndTurn;
    }

    private void OnEndTurn()
    {
        foreach(var effect in _effectsList)
        {
            var answer = effect.Effect();

            if(answer)
            {
                effect.EndEffect();
                _effectsList.Remove(effect);
            }
        }
    }

    public void AddEffect(IEffect effect)
    {
        _effectsList.Add(effect);
    }
}

