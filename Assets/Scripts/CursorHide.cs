using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CursorHide : MonoBehaviour
{
    private void Awake() => Cursor.visible = false;
}
