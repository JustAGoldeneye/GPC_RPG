using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float m_DetectionRange = 200f;
    public float m_BattleStayStillRange = 10f;
    public float m_Speed = 10f;
    public float m_TurnSpeed = 3f;

    public GameObject m_Player;

    private bool m_Battling;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Battling = false;
    }

    private void FixedUpdate()
    {
        CheckPlayerInDetectionRange();

        if (m_Battling) {

            LookToPlayer();
            
            if (DistanceToPlayer() > m_BattleStayStillRange) {
                Move();
            }

            // Contact attacking script from here ???
        }
    }

    private float DistanceToPlayer()
    {
        return (transform.position - m_Player.transform.position).magnitude;
    }

    private void CheckPlayerInDetectionRange()
    {
        m_Battling = DistanceToPlayer() <= m_DetectionRange;
    }

    // Method LookToPlayer() adapted from https://answers.unity.com/questions/417920/how-to-make-a-rigidbody-rotate-towards-an-object-u.html
    private void LookToPlayer()
    {
        Vector3 TargetDirection = m_Player.transform.position - transform.position;
        Vector3 LocalTarget = transform.InverseTransformPoint(m_Player.transform.position);

        float Angle = Mathf.Atan2(LocalTarget.x, LocalTarget.z) * Mathf.Rad2Deg;

        Vector3 EulerAngleVelocity = new Vector3(0, Angle, 0);

        Quaternion DeltaRoation = Quaternion.Euler(EulerAngleVelocity * m_TurnSpeed * Time.deltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * DeltaRoation);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
}
