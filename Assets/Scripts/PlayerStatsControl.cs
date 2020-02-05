using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsControl : MonoBehaviour
{
    public int m_MaxHP = 20;

    private int m_HP;
    
    public Text m_PlayerHPCounterText;

    void Start()
    {
        m_HP = m_MaxHP;
        SetPlayerHPCounterText();
    }

    // TEMPORARY SOLUTION
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard" && m_HP >= 1)
        {
            m_HP--;
            SetPlayerHPCounterText();
        }
    }

    void SetPlayerHPCounterText()
    {
        m_PlayerHPCounterText.text = "HP: " + m_HP + "/" + m_MaxHP;
    }
}
