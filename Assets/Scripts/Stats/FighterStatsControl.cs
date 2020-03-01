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
    private bool m_Dead;
    
    public Text m_PlayerHPCounterText;

    private void Start()
    {
        m_HP = m_MaxHP;
        m_Dead = false;
        SetHPCounterText();
    }

    public void TakeDamage(int damage)
    {
        if (damage > m_Def && damage > 0)
        {
            m_HP -= damage - m_Def;
            if (m_HP <= 0)
            {
                m_HP = 0;
                if (!m_Dead) {
                    m_Dead = true;
                    OnDeath();
                }
            }
            SetHPCounterText();
        }
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            m_HP += heal;
            if (m_HP > m_MaxHP)
            {
                m_HP = m_MaxHP;
            }
            SetHPCounterText();
        }
    }

    private void SetHPCounterText()
    {
        m_PlayerHPCounterText.text = "HP " + m_HP + "/" + m_MaxHP;
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
