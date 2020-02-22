using System.Collections;
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
        Image m_ButtonPressedImageInstance = Image.Instantiate(m_ButtonPressedImage, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("UI").transform);
        // Luodaan jonkinlainen valintaa osoittava UI-objekti painikkeen suhteellisen
        // sijainnin kohdalle (anna julkisen muuttujan määritteeksi prefab).
        // Objekti tuhoaa itsensä määritellyn ajan päästä.
    }
}
