using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashState : BaseState
{
    private SphereController _controller;

    public string TargetTag { get; set; }

    public SmashState(SphereController controller) : base(controller.gameObject)
    {
        _controller = controller;
    }
    public override Type Tick()
    {
        _controller.SphereSmash.AddLoweringVelocity(
            _controller.SphereSmash._smashForce);

        if (TargetTag == "Ground")
        {
            TargetTag = null;
            return typeof(ReturnState);
        }
            
        if (TargetTag == "Deep")
        {
            TargetTag = null;
            SoundManager.Instance.PlaySound(SoundManager.Sound.ChainLift);
            return typeof(RenewalState);
        }
      
        return null;
    }
}
