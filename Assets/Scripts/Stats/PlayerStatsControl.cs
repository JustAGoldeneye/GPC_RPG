using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsControl : FighterStatsControl
{
    public override void OnDeath() {
        GetComponent<GameOver>().Execute();
    }
}
