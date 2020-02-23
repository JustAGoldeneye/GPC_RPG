using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    public int m_Damage = 3;
    public int m_MaxLifeTime = 1;
    public string m_AttackTarget = "Enemy";

    public LayerMask m_TargetMask;

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == m_AttackTarget)
        {
            FighterStatsControl FSC = collider.GetComponent<FighterStatsControl>();
            if (FSC)
            {
                FSC.TakeDamage(m_Damage);
            }
            Destroy(gameObject);
        }
    }
}
