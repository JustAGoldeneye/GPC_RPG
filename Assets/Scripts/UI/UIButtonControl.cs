﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonControl : MonoBehaviour
{
    public Image m_ButtonPressedImage;

    private Canvas m_Canvas;

    private void Awake()
    {
        m_Canvas = GetComponentInParent<Canvas>();
    }

    public void ShowSelection()
    {
        Image m_ButtonPressedImageInstance = Image.Instantiate(m_ButtonPressedImage, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("UI").transform);
    }
}
