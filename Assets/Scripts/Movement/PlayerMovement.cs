﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 20f;
    public float m_TurnSpeed = 300f;
    public float m_JumpSpeed = 20f;
    public float m_JumpTime = 1f;
    [HideInInspector] public bool m_ControlsEnabled = true;

    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_JumpStartTime;
    private bool m_JumpInputState;
    private bool m_IsGrounded;
    private bool m_IsJumping;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
        m_JumpInputState = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        if (m_ControlsEnabled)
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

    public void DisableControls()
    {
        m_ControlsEnabled = false;
    }
}
