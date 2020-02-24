using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 0.01f;
    [SerializeField] private float _height;
    [SerializeField] private float _maxSpeed;

    public Vector3 desiredPosition;

    private Camera _camera;

    private Rigidbody _rigidbody;

    private SphereInput _sphereInput;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _rigidbody = GetComponent<Rigidbody>();
        _sphereInput = GetComponent<SphereInput>();
        transform.position += Vector3.up * _height;
    }

    public void Move()
    {
        Ray cameraRay = _camera.ScreenPointToRay(_sphereInput.MousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out float rayLenght))
        {
            desiredPosition = cameraRay.GetPoint(rayLenght) + Vector3.up * _height;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            _rigidbody.MovePosition(smoothedPosition);

            float speed = Vector3.Magnitude(_rigidbody.velocity);  
            if (speed > _maxSpeed)

            {
                float brakeSpeed = speed - _maxSpeed; 

                Vector3 normalisedVelocity = _rigidbody.velocity.normalized;
                Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  

                _rigidbody.AddForce(-brakeVelocity);  
            }

            Debug.DrawLine(cameraRay.origin, desiredPosition, Color.blue);
        }
    }
}
