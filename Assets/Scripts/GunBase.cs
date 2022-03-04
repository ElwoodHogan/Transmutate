using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField] List<GunModBase> GunMods = new List<GunModBase>();
    [SerializeField] int currentGunModIndex = 0;

    [SerializeField] Transform lineStartPoint;  //Should be camera
    [SerializeField] Transform lineDirection;  //Should be camera
    [SerializeField] LayerMask blockLayer; 

    [SerializeField] bool OnlyOneBlockCanBeChanged = true;

    GameObject lastHitObject;
    Material lastHitObjectMaterial;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            print("shot!");
            RaycastHit hit;

            if (Physics.Raycast(lineStartPoint.position, lineDirection.forward, out hit, 999, blockLayer))
            {
                print("hit!");
                if (lastHitObject)
                {
                    lastHitObject.GetComponent<Renderer>().material = lastHitObjectMaterial;
                    lastHitObject.GetComponent<Collider>().material = null;
                }
                if (OnlyOneBlockCanBeChanged)
                {
                    lastHitObject = hit.collider.gameObject;
                    lastHitObjectMaterial = new Material(hit.collider.GetComponent<Renderer>().material);
                }

                GunMods[currentGunModIndex].OnBlockShoot(hit.collider);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(lineStartPoint.position, lineDirection.forward * 99);
    }
}
