using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Transform Ball;
    [SerializeField] Transform playerCam;
    [SerializeField] LayerMask button;
    [SerializeField] Transform BallSpawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, 3, button))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Ball.position = BallSpawnPoint.position;
                    Ball.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
    }
}
