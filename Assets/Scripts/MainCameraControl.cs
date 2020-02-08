using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControl : MonoBehaviour
{
    public float m_TurnSpeed = 200f;
    private float m_TurnInputValue;

    private Vector3 m_LocalStartPos;
    private Quaternion m_LocalStartRot;

    private void Start()
    {
        m_LocalStartPos = gameObject.transform.localPosition;
        m_LocalStartRot = gameObject.transform.localRotation;
    }

    private void Update()
    {
        m_TurnInputValue = Input.GetAxis("Horizontal Camera");
    }

    private void LateUpdate()
    {   
        RoateCamera();

        if (Input.GetButtonDown("Reset Camera")) {
            ResetCamera();
        }
    }

    private void RoateCamera()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, -1 * m_TurnInputValue * m_TurnSpeed * Time.deltaTime);
    }

    private void ResetCamera()
    {
        transform.localPosition = m_LocalStartPos;
        transform.localRotation = m_LocalStartRot;
    }
}
