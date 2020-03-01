using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedHealControl : HealControl
{
    public float m_MaxLifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }
}
