using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControl : MonoBehaviour
{
    public float m_TurnSpeed = 200f;
    private float m_TurnInputValue;

    private void Update()
    {
        m_TurnInputValue = Input.GetAxis("Horizontal Camera");
    }

    private void FixedUpdate()
    {   
        RoateCamera();
    }

    private void RoateCamera()
    {
        transform.RotateAround(transform.parent.position ,Vector3.up, -1 * m_TurnInputValue * m_TurnSpeed * Time.deltaTime);
    }

    private void ResetCamera()
    {
        //TODO
    }
}
