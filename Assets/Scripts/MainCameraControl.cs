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

    private void LateUpdate()
    {   
        if (Input.GetButtonDown("Reset Camera")) {
            ResetCamera();
        }
        RoateCamera();
    }

    private void RoateCamera()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, -1 * m_TurnInputValue * m_TurnSpeed * Time.deltaTime);
    }

    private void ResetCamera()
    {
        transform.localPosition = new Vector3(0f, 2.5f, -4f);
        transform.localRotation = Quaternion.Euler(15f, 0f, 0f);
    }
}
