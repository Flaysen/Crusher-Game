using System;
using UnityEngine;

public class ColliderOverlap : MonoBehaviour
{
    public Action<Collision> onCollision;

    private void OnCollisionEnter(Collision collision)
    {
        onCollision?.Invoke(collision);
    }
}
