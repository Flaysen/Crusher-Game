using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnState : BaseState
{
    private SphereController _controller;

    public ReturnState(SphereController controller) : base(controller.gameObject)
    {
        _controller = controller;
    }
    public override Type Tick()
    {
        _controller.SphereSmash.AddLiftingVelocity(
            _controller.SphereSmash._liftingSpeed);

        if (_controller.gameObject.transform.position.y > 6.0f)
            return typeof(MoveState);

        return null;
    }
}
