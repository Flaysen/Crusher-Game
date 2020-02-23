using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class SphereController : MonoBehaviour
{
    public SphereMovement SphereMovement { get; private set; }

    public SphereSmash SphereSmash { get; private set; }

    private SphereStateMachine _stateMachine;

    private SphereInput _sphereInput;

    private ColliderOverlap _colliderOverlap;

    private CameraShaker _cameraShaker;

    public bool IsSmashing { get; private set; }

    private void Awake()
    {
        _stateMachine = GetComponent<SphereStateMachine>();
        InitializeStateMachine();

        SphereMovement = GetComponent<SphereMovement>();
        SphereSmash = GetComponent<SphereSmash>();

        _sphereInput = GetComponent<SphereInput>();
        _colliderOverlap = GetComponent<ColliderOverlap>();

         _colliderOverlap.onCollision += SphereCollide;
        _sphereInput.OnSmash += Smash;
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(MoveState), new MoveState(this) },
            { typeof(SmashState), new SmashState(this) },
            { typeof(ReturnState), new ReturnState(this) },
            { typeof(RenewalState), new RenewalState(this) }

        };

        _stateMachine.SetStates(states);
    }

    public void InitializeCameraShaker(CameraShaker cameraShaker)
    {
        _cameraShaker = cameraShaker;
    }

    private void Smash() => IsSmashing = true;

    private void SphereCollide(Collision collision)
    {
        _cameraShaker.ShakeOnce(4f, 2f, .1f, 1f);
        if(_stateMachine.CurrentState.GetType() == typeof(SmashState))
        {
            SmashState smash = (SmashState)_stateMachine.CurrentState;
            smash.TargetTag = collision.gameObject.tag;
            IsSmashing = false;
        }           
    }

}
