using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealControl : MonoBehaviour
{
    public int m_HealAmount = 10;

    public string m_HealTarget = "Player";

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == m_HealTarget || (m_HealTarget == "All" && (collider.tag == "Player" || collider.tag == "Enemy")))
        {
            FighterStatsControl FSC = collider.GetComponent<FighterStatsControl>();
            if (FSC)
            {
                FSC.Heal(m_HealAmount);
            }
            Destroy(gameObject);
        }
    }
}
