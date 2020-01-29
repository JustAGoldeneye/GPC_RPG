using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControl : MonoBehaviour
{
    public float m_MoveSpeed = 6.666f;
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
        MoveWhileTurning();
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(m_AngleX, transform.localEulerAngles.y + turn, m_AngleZ);

        transform.localRotation = rotation;
    }

    private void MoveWhileTurning()
    {
        Vector3 movement = -1 * transform.right * m_TurnInputValue * m_MoveSpeed * Time.deltaTime;

        transform.localPosition = transform.localPosition + movement;
        //huono ratkaisu, kääntyy väärään suuntaan ja pakenee
    }
}
