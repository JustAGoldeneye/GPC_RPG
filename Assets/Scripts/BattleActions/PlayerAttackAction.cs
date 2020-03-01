using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerAttackAction : AttackAction
{

    public Text m_ActionNameText;
    public Slider m_CooldownTimer;

    private void Start()
    {
        m_ActionNameText.text = m_ActionName;
        m_CooldownTimer.maxValue = m_CooldownTime;
        m_CooldownTimer.value = m_CooldownTime;
    }

    private void Update()
    {
        m_CooldownTimer.value = Mathf.Min(Time.time - m_ActionStartTime, m_CooldownTime);
    }

    public void ExecuteViaUI()
    {
        Execute();
        // Event trigger can't utilize methods with return values.
    }
}
