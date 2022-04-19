using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsTrigger : MonoBehaviour
{
    public Text creditsText;
    public Image creditsBackground;
    public Image crosshair;

    void OnTriggerEnter(Collider other)
    {
        crosshair.enabled = false;
        creditsBackground.enabled = true;
        creditsText.enabled = true;
    }
}
