using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsControl : FighterStatsControl
{
    protected override void OnDeath() {
        GetComponent<GameOver>().Execute();
    }
}
