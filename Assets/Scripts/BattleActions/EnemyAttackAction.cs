using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackAction : AttackAction
{
    public float m_ActivationDistance = 10f;

    public bool ExecuteIfInRange(float Distance)
    {
        if (Distance <= m_ActivationDistance)
        {            
            return Execute();
        }
        return false;
    }
}
