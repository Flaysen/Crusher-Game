using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SphereStateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> _availableStates;

    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _availableStates = states;
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = _availableStates[typeof(MoveState)];
        }

        var nextState = CurrentState?.Tick();

        if (nextState != null &&
            nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    private void SwitchToNewState(Type nextState)
    {
        CurrentState = _availableStates[nextState];
        OnStateChanged?.Invoke(CurrentState);
    }
}
