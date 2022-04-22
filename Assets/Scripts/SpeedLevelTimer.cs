using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class SpeedLevelTimer : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] LayerMask button;
    [SerializeField] float TimerTime;
    float currentTime;
    [SerializeField] Text Timer;
    [SerializeField] DoorMover Door;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, 3, button))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Door.StartMovement(TimerTime);
                    currentTime = TimerTime;
                }
            }
        }

        if(currentTime > 0)
        {
            Timer.text = Mathf.RoundToInt(currentTime) + "";
            currentTime -= Time.deltaTime;
        }
    }
}
