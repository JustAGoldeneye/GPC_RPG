using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionControl : MonoBehaviour
{
    public void ExecuteAttacksInRange(float Distance)
    {
        // Joku timer
        GetComponent<EnemyAttack1Action>().ExecuteIfInRange(Distance);
    }
}
