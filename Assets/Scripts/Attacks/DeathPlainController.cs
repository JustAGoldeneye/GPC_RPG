using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlainController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" || collider.tag == "Enemy")
        {
            FighterStatsControl FSC = collider.GetComponent<FighterStatsControl>();
            if (FSC)
            {
                FSC.OnDeath();
            }
        }
    }
}
