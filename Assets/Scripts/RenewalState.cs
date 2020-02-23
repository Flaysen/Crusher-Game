using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewalState : BaseState
{
    private SphereController _controller;

    public RenewalState(SphereController controller) : base(controller.gameObject)
    {
        _controller = controller;
    }

    public override Type Tick()
    {
        _controller.SphereSmash.AddLiftingVelocity(
            _controller.SphereSmash._renewalSpeed);

        if (_controller.gameObject.transform.position.y > 3.0f)
            return typeof(MoveState);

        return null;
    }
}
