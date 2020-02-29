using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : AttackAction
{
    public float m_ActivationDistance = 10f;

    public void ExecuteIfInRange(float Distance)
    {
        if (Distance <= m_ActivationDistance)
        {
            Execute();
        }
    }
}
