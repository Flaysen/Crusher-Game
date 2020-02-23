using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereInput))]
public class SphereSmash : MonoBehaviour
{
    public float _smashForce = 10f;
    public float _liftingSpeed = 10f;
    public float _renewalSpeed = 2f;
    public SphereInput SphereInput { get; set; }
    
    private Rigidbody rb;

    private void Awake()
    {
        SphereInput = GetComponent<SphereInput>();
        rb = GetComponent<Rigidbody>();
    }

    public void AddLoweringVelocity(float smashForce) => rb.velocity = Vector3.down * smashForce;

    public void AddLiftingVelocity(float liftingSpeed)
    {
        if (transform.position.y < 3.0f)
            rb.velocity = Vector3.up * liftingSpeed;
        else rb.velocity = Vector3.zero;
    }
}
