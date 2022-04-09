using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Phase : BlockMod
{
    Collider m_Collider;
    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
        m_Collider.enabled = false;
    }

    private void OnDestroy()
    {
        m_Collider.enabled = true;
    }
}
