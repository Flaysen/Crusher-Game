﻿using System;
using UnityEngine;

public abstract class BaseState 
{
    protected GameObject gameObject;
    protected Transform transform;

    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;

    }

    public abstract Type Tick();
}
