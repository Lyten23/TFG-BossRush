using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZephyrStateMachine : StateManager<ZephyrStateMachine.ZephyrStates>
{
    public Animator animator;
    public enum ZephyrStates
    {
        Idle,
        Walk,
        Run,
        BattleIdle,
        Hit,
        Attack,
        Sturn,
        Die,
    }
    private void Awake()
    {
        
    }
}
