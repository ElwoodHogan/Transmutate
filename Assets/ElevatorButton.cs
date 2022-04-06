using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    [SerializeField] Elevator elevator;
    [SerializeField] Transform playerCam;
    [SerializeField] LayerMask button;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            RaycastHit hit;
            if(Physics.Raycast(playerCam.position, playerCam.forward, out hit, 3, button))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    elevator.Lift();
                }
            }
        }
    }
}
