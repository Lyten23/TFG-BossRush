using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZephyrStateMachine : StateManager<ZephyrStateMachine.ZephyrStates>
{
    public static ZephyrStateMachine instane;
    public Animator animator;
    public enum ZephyrStates
    {
        Idle,
        Walk,
        Die,
        Hit,
    }
    private void Awake()
    {
        instane = this;
        States.Add(ZephyrStates.Idle, new IdleState());
        States.Add(ZephyrStates.Walk,new WalkState());
        States.Add(ZephyrStates.Hit,new HitState());
        States.Add(ZephyrStates.Die,new DieState());
        CurrentState = States[ZephyrStates.Idle];
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeToState(ZephyrStates.Die);
        }
    }
    private class IdleState: StateBase<ZephyrStates>
    {
        public IdleState():base(ZephyrStates.Idle){}
        public override void EnterState()
        {
            instane.animator.Play("battleidle");
        }
        public override void ExitState()
        {
            
        }
        public override void UpdateState()
        {
            
        }
        public override ZephyrStates GetNextState()
        {
            return ZephyrStates.Idle;
        }
        public override void OntriggerEnter(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                instane.ChangeToState(ZephyrStates.Hit);
            }
        }
        public override void OntriggerExit(Collider other)
        {
            
        }
        public override void OntrigerStay(Collider other)
        {
            
        }
    }
    private class WalkState : StateBase<ZephyrStates>
    {
        public WalkState() : base(ZephyrStates.Walk) { }
        public override void EnterState()
        {
            Debug.Log("Estoy en el estado de caminar");
            instane.animator.Play("walk");
        }
        public override void ExitState()
        {
            
        }
        public override void UpdateState()
        {
            
        }
        public override ZephyrStates GetNextState()
        {
            return ZephyrStates.Walk;
        }
        public override void OntriggerEnter(Collider other)
        {
           
        }
        public override void OntriggerExit(Collider other)
        {
            
        }
        public override void OntrigerStay(Collider other)
        {
            
        }
    }
    private class HitState:StateBase<ZephyrStates>
    {
        public HitState() : base(ZephyrStates.Hit){}
        public override void EnterState()
        {
            instane.animator.Play("hit");
        }
        public override void ExitState()
        {
            
        }
        public override void UpdateState()
        {
            
        }
        public override ZephyrStates GetNextState()
        {
            return ZephyrStates.Idle;
        }
        public override void OntriggerEnter(Collider other)
        {
            
        }
        public override void OntriggerExit(Collider other)
        {
            
        }
        public override void OntrigerStay(Collider other)
        {
            
        }
    }
    private class DieState:StateBase<ZephyrStates>
    {
        public DieState() : base(ZephyrStates.Die){}

        public override void EnterState()
        {
            instane.animator.Play("die");
        }

        public override void ExitState()
        {
            
        }
        public override void UpdateState()
        {
            
        }
        public override ZephyrStates GetNextState()
        {
            return ZephyrStates.Idle;
        }

        public override void OntriggerEnter(Collider other)
        {
            
        }
        public override void OntriggerExit(Collider other)
        {
        }

        public override void OntrigerStay(Collider other)
        {
        }
    }
    #region Cambio de estados
    public void ChangeToState(ZephyrStates state) => TransitionState(state);

    #endregion
}
