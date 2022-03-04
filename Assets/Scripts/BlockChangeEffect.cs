using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlockChangeEffect : MonoBehaviour
{
    [SerializeField] Transform lineStartPoint;  //Should be camera
    [SerializeField] Transform lineDirection;  //Should be camera
    [SerializeField] LayerMask blockLayer;  //Should be camera

    [SerializeField, Space(10)] PhysicMaterial bouncePhysMaterial;
    [SerializeField] Material bounceMaterial;

    GameObject lastHitObject;
    Material lastHitObjectMaterial;
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(lineStartPoint.position, lineDirection.forward, out hit, 999, blockLayer))
            {
                print("hit!");
                if (lastHitObject)
                {
                    lastHitObject.GetComponent<Renderer>().material = lastHitObjectMaterial;
                    lastHitObject.GetComponent<Collider>().material = null;
                }
                lastHitObject = hit.collider.gameObject;
                Material hitMat = hit.collider.GetComponent<Renderer>().material;
                lastHitObjectMaterial = new Material(hitMat);

                hitMat = bounceMaterial;
                hit.collider.material = bouncePhysMaterial;


            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(lineStartPoint.position, lineDirection.forward * 99);
    }
}
