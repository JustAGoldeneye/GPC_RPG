using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed =10f;
    
    private float m_MovementInputValueForward;
    private float m_MovementInputValueRight;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_MovementInputValueForward = Input.GetAxis("Vertical");
        m_MovementInputValueRight = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementForward = transform.forward * m_MovementInputValueForward * m_Speed * Time.deltaTime;
        Vector3 movementRight = transform.right * m_MovementInputValueRight * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movementForward + movementRight);
    }
}
