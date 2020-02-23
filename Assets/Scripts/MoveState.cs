using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveState : BaseState
{
    private SphereController _controller;

    public MoveState(SphereController controller) : base(controller.gameObject)
    {
        _controller = controller;
    }

    public override Type Tick()
    {
        _controller.SphereMovement.Move();

        if (_controller.IsSmashing) return typeof(SmashState);

        return null;
    }

}

