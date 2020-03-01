using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatsControl : FighterStatsControl
{
    public GameObject m_GameManger;

    public override void OnDeath() {
        m_GameManger.GetComponent<FlagManager>().NotifyRedBossBeaten();
        Destroy(gameObject);
    }
}
