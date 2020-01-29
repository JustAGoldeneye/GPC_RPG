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
    private Transform Player;

    //private Rigidbody m_Rigidbody;

    /*private void Awake() {
        //m_Rigidbody = GetComponent<Rigidbody>();
    }*/

    private void Update()
    {
        m_TurnInputValue = Input.GetAxis("Horizontal Camera");

        //transform.position = transform.forward * 4 + Player.position;
    }

    private void FixedUpdate()
    {   
        //Debug.Log("Horizontal Camera (input value): " + m_TurnInputValue);

        //Turn();
        //MoveWhileTurning();

        transform.RotateAround(transform.parent.position ,Vector3.up, -1 * m_TurnInputValue * m_TurnSpeed * Time.deltaTime);
    }

    private void Turn()
    {
        float turn = -1 * m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        //Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        Quaternion rotation = Quaternion.Euler(m_AngleX, transform.localEulerAngles.y + turn, m_AngleZ);

        //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * rotation);
        transform.localRotation = rotation;
    }

    private void MoveWhileTurning()
    {
        Vector3 movement = transform.right * m_TurnInputValue * m_MoveSpeed * Time.deltaTime;

        //m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        transform.localPosition = transform.localPosition + movement;
        //huono ratkaisu, koska pakenee
    }

    private void ResetCamera()
    {
        //TODO
    }
}
