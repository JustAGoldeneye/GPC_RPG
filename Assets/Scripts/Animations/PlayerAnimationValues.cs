using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Not in use
public class PlayerAnimationValues : MonoBehaviour
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        m_Animator.SetFloat("Speed", Input.GetAxis("Vertical"));
    }

    public void RequestAttack()
    {
        
    }

    public void RequestTakeDamage()
    {

    }

    public void RequestDeath()
    {

    }
}
