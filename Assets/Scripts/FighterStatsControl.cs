using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterStatsControl : MonoBehaviour
{
    public int m_MaxHP = 20;
    public int m_Atk = 3;
    public int m_Def = 0;

    private int m_HP;
    
    public Text m_PlayerHPCounterText;

    private void Start()
    {
        m_HP = m_MaxHP;
        SetPlayerHPCounterText();
    }

    public void TakeDamage(int damage)
    {
        if (damage > m_Def)
        {
            m_HP -= damage - m_Def;
            SetPlayerHPCounterText();
            if (m_HP <= 0)
            {
                OnDeath();
            }
        }
    }

    void SetPlayerHPCounterText()
    {
        m_PlayerHPCounterText.text = "HP " + m_HP + "/" + m_MaxHP;
    }

    void OnDeath()
    {
        Debug.Log("OnDeath not imtplemented yet");
    }
}
