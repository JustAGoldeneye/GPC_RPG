using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionControl : MonoBehaviour
{
    private float m_AttackNormalInputValue;

    private void Update()
    {
        m_AttackNormalInputValue = Input.GetAxis("Normal Attack");
    }

    private void FixedUpdate()
    {
        if (m_AttackNormalInputValue > 0) {
            gameObject.GetComponent<PlayerAttackNormalAction>().Execute();
        }
    }
}
