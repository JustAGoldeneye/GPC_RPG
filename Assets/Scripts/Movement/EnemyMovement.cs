using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float m_DetectionRange = 200f;
    public float m_BattleStayStillRange = 10f;
    public float m_Speed = 10f;
    public float m_TurnSpeed = 3f;
    public bool m_MoveOutsideBattle = true;
    public float m_MinWanderTime = 5f;
    public float m_MaxWanderTime = 15f;
    public float m_MinWanderWait = 3f;
    public float m_MaxWanderWait = 20f;

    public GameObject m_Player;

    private bool m_Battling;
    private bool m_Wandering;
    private float m_CurrentWanderTime;
    private float m_CurrentWanderWait;
    private float m_WanderTimer;
    private int m_WanderDirectionAndStrength; // negative for left, 0 for forward, positive for right 

    private Rigidbody m_Rigidbody;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Battling = false;
        m_Wandering = false;
        CalculateCurrentWanderWait();
    }

    private void FixedUpdate()
    {
        CheckPlayerInDetectionRange();

        if (m_Battling) {

            LookToPlayer();
            
            if (DistanceToPlayer() > m_BattleStayStillRange) {
                Move();
                // Contact attacking script from here ???
            }
        }
        else if (m_MoveOutsideBattle)
        {
            if (m_Wandering && Time.time - m_WanderTimer < m_CurrentWanderTime)
            {
                Wander();
            }
            else if (m_Wandering && Time.time - m_WanderTimer >= m_CurrentWanderTime)
            {
                StopWandering();
            }
            else if (!m_Wandering && Time.time - m_WanderTimer >= m_CurrentWanderWait)
            {
                StartWandering();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && !m_Battling)
        {
            StartWandering();
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

    private void StartWandering()
    {
        m_WanderDirectionAndStrength = Random.Range(-12,12);
        //Debug.Log("Wander Direction value " + m_WanderDirectionAndStrength);

        CalculateCurrentWanderTime();
        m_WanderTimer = Time.time;
        m_Wandering = true;
    }

    private void Wander()
    {
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * Quaternion.Euler(Vector3.up * m_WanderDirectionAndStrength * m_TurnSpeed * Time.deltaTime));
        Move();
    }

    private void StopWandering()
    {
        CalculateCurrentWanderWait();
        m_WanderTimer = Time.time;
        m_Wandering = false;
    }

    private void CalculateCurrentWanderTime()
    {
        m_CurrentWanderTime = m_MinWanderTime + Random.value * (m_MaxWanderTime - m_MinWanderTime);
        //Debug.Log("Wander for " + m_CurrentWanderTime);
    }

    private void CalculateCurrentWanderWait()
    {
        m_CurrentWanderWait = m_MinWanderWait + Random.value * (m_MaxWanderWait - m_MinWanderWait);
        //Debug.Log("Rest for " + m_CurrentWanderWait);
    }
}
