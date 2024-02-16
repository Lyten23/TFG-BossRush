using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase<EState> where EState : Enum
{
    public StateBase(EState key)
    {
        StateKey = key;
    }
    public EState StateKey { get; private set; }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public abstract void OntriggerEnter(Collider other);
    public abstract void OntriggerExit(Collider other);
    public abstract void OntrigerStay(Collider other);
}
