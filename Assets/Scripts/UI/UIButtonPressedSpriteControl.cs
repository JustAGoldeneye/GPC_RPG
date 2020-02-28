using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonPressedSpriteControl : MonoBehaviour
{
    public float m_DestroyDelay = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        Object.Destroy(gameObject, m_DestroyDelay);
    }
}
