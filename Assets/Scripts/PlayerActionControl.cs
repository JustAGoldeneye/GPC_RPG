using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionControl : MonoBehaviour
{
    private bool m_AttackNormalInputValue;

    private void Update()
    {
        m_AttackNormalInputValue = Input.GetButton("Normal Attack");
    }

    private void FixedUpdate()
    {
        if (m_AttackNormalInputValue) {
            gameObject.GetComponent<PlayerAttackNormalAction>().Execute();
        }
    }
}
