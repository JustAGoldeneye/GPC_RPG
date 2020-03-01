using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public GameObject m_RedBoss;
    public GameObject m_RoadBlock;

    private bool m_RedBossBeaten = false;

    public void Start()
    {
        CheckIfRedBossBeaten();
    }

    public void NotifyRedBossBeaten()
    {
        if (m_RedBoss) {
            Destroy(m_RedBoss);
        }
        Destroy(m_RoadBlock);
        m_RedBossBeaten = true;

        GetComponent<SaveFileManager>().FlagRedBossFlag();
    }

    public void CheckIfRedBossBeaten()
    {
        m_RedBossBeaten = GetComponent<SaveFileManager>().GetRedBossFlag();
        if (m_RedBossBeaten)
        {
            NotifyRedBossBeaten();
        }
    }
}
