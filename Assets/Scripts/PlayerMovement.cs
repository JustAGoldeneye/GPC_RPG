using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 10f;
    public float m_TurnSpeed = 300f;
    
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(VerticalInput) >= Mathf.Abs(HorizontalInput)) {
            m_MovementInputValue = VerticalInput;
        } else {
            m_MovementInputValue = Mathf.Abs(HorizontalInput);
        }
        
        //m_MovementInputValue = Mathf.Max(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotatiom = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotatiom);
    }
}
