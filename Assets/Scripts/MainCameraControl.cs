using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControl : MonoBehaviour
{
    public float m_TurnSpeed = 200f;
    public float m_AngleX = 15f;
    public float m_AngleZ = 0f;
    private float m_TurnInputValue;

    private void Update()
    {
        m_TurnInputValue = Input.GetAxis("Horizontal Camera");
    }

    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(m_AngleX, transform.localEulerAngles.y + turn, m_AngleZ);

        transform.localRotation = turnRotation;
    }
}
