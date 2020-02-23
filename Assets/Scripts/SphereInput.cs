using System;
using UnityEngine;

public class SphereInput : MonoBehaviour, IMovementInputGetter, ISphereInputGetter
{
    public Vector3 MousePosition { get; private set; }

    public bool Smash { get; private set; }

    public  Action OnSmash { get; set; }

    private void Update()
    {
        GetInput();
        if (Smash) OnSmash?.Invoke();
    }

    private void GetInput()
    {
        Smash = Input.GetKeyDown(KeyCode.Space);
        MousePosition = Input.mousePosition;
    }
}
