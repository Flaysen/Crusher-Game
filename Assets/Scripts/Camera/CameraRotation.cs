using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public GameObject player;

    public SphereMovement sphereMovement;

    private float rotationSmooth = 0.02f;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
          
    }

    private void Update()
    {
        Vector3 playerPosition = player.GetComponent<Transform>().position;
        float x = 60;
        float y = 0;
        Vector3 direction = (playerPosition - sphereMovement.desiredPosition);
        if (direction.x > 1) y = -2;
        else if (direction.x < -1) y = 2;
        else y = 0;
        if (direction.z > 1) x = 62;
        else if (direction.z < -1) x = 58;
        else x = 60;
        Quaternion desiredRotation = Quaternion.Euler(x, y, 0);
        Quaternion smoothedPosition = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSmooth);
        transform.rotation = smoothedPosition;

    }
}
