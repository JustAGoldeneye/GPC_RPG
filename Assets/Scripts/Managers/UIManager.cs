using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas m_PauseMenu;

    private void Start()
    {
        m_PauseMenu.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            m_PauseMenu.GetComponent<Canvas>().enabled = !m_PauseMenu.GetComponent<Canvas>().enabled;
        }
    }

    public void ClosePauseMenu()
    {
        m_PauseMenu.GetComponent<Canvas>().enabled = false;
    }
}