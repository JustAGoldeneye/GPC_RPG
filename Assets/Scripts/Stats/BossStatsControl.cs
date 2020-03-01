using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatsControl : FighterStatsControl
{
    public GameObject m_RoadBlock;

    public override void OnDeath() {
        Destroy(m_RoadBlock);
        Destroy(gameObject);
    }
}
