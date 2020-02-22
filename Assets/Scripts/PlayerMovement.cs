using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 20f;
    public float m_TurnSpeed = 300f;
    public float m_JumpSpeed = 20f;
    public float m_JumpTime = 1f; // in seconds

    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_JumpStartTime;
    private bool m_IsGrounded;
    private bool m_IsJumping;

    private Rigidbody m_Rigidbody;
    private Collider m_Collider;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
    }

    private void Update()
    {
        // Old m_MovementInputValue code, should be removed when it is certain that it is unneccessary.
        /*float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(VerticalInput) >= Mathf.Abs(HorizontalInput)) {
            m_MovementInputValue = VerticalInput;
        } else {
            m_MovementInputValue = Mathf.Abs(HorizontalInput);
        }*/

        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetButton("Jump") && (m_IsGrounded || ((Time.time - m_JumpStartTime <= m_JumpTime && m_IsJumping))))
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
