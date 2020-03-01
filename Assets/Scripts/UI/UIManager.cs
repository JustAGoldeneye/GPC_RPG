using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject m_PauseMenu;

    private bool m_PauseMenuOpen;

    private GameObject m_PauseMenuInstance;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!m_PauseMenuOpen)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }
    }

    private void OpenPauseMenu()
    {
        m_PauseMenuInstance = Instantiate(m_PauseMenu, Vector3.zero, Quaternion.identity);

        m_PauseMenuOpen = true;
    }

    private void ClosePauseMenu()
    {

        Destroy(m_PauseMenuInstance);

        m_PauseMenuOpen = false;
    }
}