using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField] float GunCooldownTimer = .2f;
    [Space]
    [SerializeField] List<GunMod> GunMods = new List<GunMod>();
    [SerializeField] int currentGunModIndex = 0;
    [Space]
    [SerializeField] Transform Camera;  //Should be camera
    [SerializeField] LineRenderer ShootLine;
    [SerializeField] Transform GunTip;
    [SerializeField] Transform ScienceBall;
    [SerializeField] LayerMask blockLayer; 
    [SerializeField] bool OnlyOneBlockCanBeChanged = true;

    GameObject lastHitObject;
    Material lastHitObjectMaterial;
    bool onCooldown = false;

    private void Start()
    {
        ShootLine.material = GunMods[currentGunModIndex].ModMaterial;
    }
    private void Update()
    {

        ShootLine.SetPositions(new Vector3[] { ScienceBall.position, GunTip.position, (Camera.position + (Camera.forward * 5)) });

        if (onCooldown) return;  //The gun cant be fired on cooldown
        if (Input.GetMouseButtonDown(0))
        {
            //print("shot!");

            //The gun has shot, it is now on cooldown
            onCooldown = true;
            Timer.SimpleTimer(() => onCooldown = false, GunCooldownTimer);

            //Visual
            ShootLine.enabled = true;
            Timer.SimpleTimer(() => ShootLine.enabled = false, .05f);

            RaycastHit hit;

            if (Physics.Raycast(Camera.position, Camera.forward, out hit, 999, blockLayer))
            {
                //print("hit!");
                
                if (lastHitObject && OnlyOneBlockCanBeChanged)
                {
                    lastHitObject.GetComponent<Renderer>().material = lastHitObjectMaterial;
                    lastHitObject.GetComponent<Collider>().material = null;

                    //Removing transmutated properties from last hit block
                    foreach (var script in lastHitObject.GetComponents<MonoBehaviour>())
                    {
                        Destroy(script);
                    }

                    lastHitObjectMaterial = new Material(hit.collider.GetComponent<Renderer>().material);
                    lastHitObject = hit.collider.gameObject;
                } else { 
                    lastHitObject = hit.collider.gameObject;
                    lastHitObjectMaterial = new Material(hit.collider.GetComponent<Renderer>().material);
                }

                //Removing transmutated properties before adding a new one
                foreach (var script in hit.collider.GetComponents<MonoBehaviour>())
                {
                    Destroy(script);
                }
                GunMods[currentGunModIndex].OnBlockShoot(hit.collider);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Camera.position, Camera.forward * 99);
    }
}
