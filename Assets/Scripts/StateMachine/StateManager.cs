using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState>: MonoBehaviour where EState: Enum
{
    protected Dictionary<EState, StateBase<EState>> States = new Dictionary<EState, StateBase<EState>>();
    protected StateBase<EState> CurrentState;
    protected bool isTransitioningState = false;

    private void Start()
    {
        CurrentState.EnterState();
    }

    private void Update()
    {
        EState nexStateKey = CurrentState.GetNextState();
        if (!isTransitioningState && nexStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if (!isTransitioningState)
        {
            TransitionState(nexStateKey);
        }
    }

    public void TransitionState(EState stateKey)
    {
        isTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        isTransitioningState = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OntriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CurrentState.OntrigerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentState.OntriggerExit(other);
    }
}
