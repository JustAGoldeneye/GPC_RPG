﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionControl : MonoBehaviour
{
    private float m_DefaultAttackInputValue;

    private void Update()
    {
        m_DefaultAttackInputValue = Input.GetAxis("Normal Attack");
    }

    private void FixedUpdate()
    {
        
    }
}
