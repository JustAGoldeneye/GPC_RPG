using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAttackControl : AttackControl
{
    public float m_MaxLifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }
}
