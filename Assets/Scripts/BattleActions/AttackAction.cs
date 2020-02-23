using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackAction : MonoBehaviour
{
    public float m_CooldownTime = 2f;
    public float m_AttackPosX = 0f;
    public float m_AttackPosY = 0f;
    public float m_AttackPosZ = 0f;
    public string m_ActionName = "Unnamed action";

    public Collider m_Attack;
    public Slider m_CooldownSlider;
    public Text m_ActionNameTetx;

    private float m_ActionStartTime = -10f;

    private void Start()
    {
        m_ActionNameTetx.text = m_ActionName;
        m_CooldownSlider.maxValue = m_CooldownTime;
        m_CooldownSlider.value = m_CooldownTime;
    }

    private void Update()
    {
        m_CooldownSlider.value = Mathf.Min(Time.time - m_ActionStartTime, m_CooldownTime);
    }

    public void Execute()
    {
        if (Time.time - m_ActionStartTime >= m_CooldownTime)
        {
            Collider m_SwordAttack1Instance = Collider.Instantiate(m_Attack, transform.position + new Vector3(m_AttackPosX, m_AttackPosY, m_AttackPosZ), transform.rotation);
            m_ActionStartTime = Time.time;

            // Add animations etc. here
        }
    }
}
