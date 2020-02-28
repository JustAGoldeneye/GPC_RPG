using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
A new subclass of this script (or some of its subclasses) should always be created when added to a game object
as this class doesn't contain input value/state updating.
*/

public class CharacterMovement : MonoBehaviour
{
    public float m_Speed = 20f;
    public float m_TurnSpeed = 300f;
    public float m_JumpSpeed = 20f;
    public float m_JumpTime = 1f;

    protected float m_MovementInputValue;
    protected float m_TurnInputValue;
    private float m_JumpStartTime;
    protected bool m_JumpInputState;
    private bool m_IsGrounded;
    private bool m_IsJumping;

    private Rigidbody m_Rigidbody;
    private Collider m_Collider;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        Move();

        if (m_JumpInputState && (m_IsGrounded || ((Time.time - m_JumpStartTime < m_JumpTime && m_IsJumping))))
        {
            Jump();
        } else {
            m_IsJumping = false;
        }

        Turn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_IsGrounded = false;
        }
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Jump()
    {
        if (m_IsGrounded)
        {
            m_IsJumping = true;
            m_JumpStartTime = Time.time;
        }

        Vector3 upMovement = transform.up * m_JumpSpeed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + upMovement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
