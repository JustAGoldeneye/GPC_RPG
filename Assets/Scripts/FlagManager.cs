using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private bool m_RedBossBeaten = false;

    public GameObject m_RedBoss;
    public GameObject m_RoadBlock;

    public void Start()
    {
        // lue save file
        // destroy tarvittaessa objektit
    }

    public void NotifyRedBossBeaten()
    {
        Destroy(m_RoadBlock);
        m_RedBossBeaten = true;
    }

    public bool CheckIfRedBossBeaten()
    {
        return m_RedBossBeaten;
    }
}
