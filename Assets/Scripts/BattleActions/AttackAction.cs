using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
A new subclass of this script (or some of its subclasses) should always be created when added to a game object
as the same game object may several instances of this script.
*/

public abstract class AttackAction : MonoBehaviour
{
    public float m_CooldownTime = 2f;
    public float m_AttackPosX = 0f;
    public float m_AttackPosY = 0f;
    public float m_AttackPosZ = 0f;
    public bool m_MakeFightersChild = true;
    public string m_ActionName = "Unnamed action";

    public Collider m_Attack;

    protected float m_ActionStartTime;

    private void Start()
    {
        m_ActionStartTime = Time.time;
    }

    public bool Execute()
    {
        if (Time.time - m_ActionStartTime >= m_CooldownTime)
        {
            Collider m_AttackInstance = Collider.Instantiate(m_Attack, transform.position, transform.rotation);
            m_AttackInstance.transform.parent = gameObject.transform;
            m_AttackInstance.transform.localPosition = new Vector3(m_AttackPosX, m_AttackPosY, m_AttackPosZ);

            if (!m_MakeFightersChild)
            {
                m_AttackInstance.transform.parent = null;
            }
            
            m_AttackInstance.GetComponent<AttackControl>().m_Damage += gameObject.GetComponentInParent<FighterStatsControl>().m_Atk;
            m_ActionStartTime = Time.time;

            return true;
        }

        return false;
    }
    /*
    protected virtual void RequestAnimation()
    {
        Debug.Log("Animation request not defined!");
    }
    */
}
