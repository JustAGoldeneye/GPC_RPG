using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionControl : MonoBehaviour
{
    public float m_RemoveTextAfter = 2f;

    public Text m_ActioNameText;

    private float m_TextAppearTime;
    private bool m_TextUpdated;

    private void Start()
    {
        m_TextAppearTime = -1000f;
        m_ActioNameText.text = "";
        m_TextUpdated = true;
    }

    private void Update()
    {
        if (Time.time - m_TextAppearTime >= m_RemoveTextAfter && !m_TextUpdated)
        {
            m_ActioNameText.text = "";
            m_TextUpdated = true;
        }
    }

    public void ExecuteAttacksInRange(float Distance)
    {
        if (GetComponent<EnemyAttack1Action>().ExecuteIfInRange(Distance))
        {
            m_TextAppearTime = Time.time;
            m_ActioNameText.text = GetComponent<EnemyAttack1Action>().m_ActionName;
            m_TextUpdated = false;
        }
        if (GetComponent<EnemyAttack2Action>().ExecuteIfInRange(Distance))
        {
            m_TextAppearTime = Time.time;
            m_ActioNameText.text = GetComponent<EnemyAttack2Action>().m_ActionName;
            m_TextUpdated = false;
        }
        if (GetComponent<EnemyAttack3Action>().ExecuteIfInRange(Distance))
        {
            m_TextAppearTime = Time.time;
            m_ActioNameText.text = GetComponent<EnemyAttack3Action>().m_ActionName;
            m_TextUpdated = false;
        }
    }
}
