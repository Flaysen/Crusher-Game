using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHoldHeight : MonoBehaviour
{
    private Vector3 _cameraPosition;

    [SerializeField] private float _holdPosition;
    void LateUpdate()
    {
        _cameraPosition = transform.TransformPoint(transform.localPosition);
        if (_cameraPosition.y < _holdPosition)
        {
            Vector3 holdPosition = new Vector3(_cameraPosition.x, 2.5f, _cameraPosition.z);
            transform.position = holdPosition;
        }
    }

}
