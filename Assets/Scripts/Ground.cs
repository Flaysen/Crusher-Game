using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private ColliderOverlap _colliderOverlap;

    public Action OnGroundHit;

    private void Awake()
    {
        _colliderOverlap.onCollision += Collide;
    }

    private void Collide(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnGroundHit?.Invoke();
    }



}
