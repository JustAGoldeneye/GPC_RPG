using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
A new subclass of this script (or some of its subclasses) should NOT be created when added to a game object.
*/

public class AttackControl : MonoBehaviour
{
    public int m_Damage = 3;
    
    public string m_AttackTarget = "Enemy";

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == m_AttackTarget || (m_AttackTarget == "All" && (collider.tag == "Player" || collider.tag == "Enemy")))
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