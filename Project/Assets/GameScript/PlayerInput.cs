using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string MoveHorizontal = "Horizontal";
    private string MoveVertical = "Vertical";

    public float _horizontal { get; set; }
    public float _vertical { get; set; }

    void Update()
    {
        _horizontal = Input.GetAxisRaw(MoveHorizontal);
        _vertical = Input.GetAxisRaw(MoveVertical);
    }
}
