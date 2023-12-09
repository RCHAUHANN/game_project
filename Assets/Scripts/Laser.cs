using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = 0.5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float FireDelay = 2f;
    LineRenderer lr;
    bool canFire;


    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Start()
    {
        lr.enabled = false;
        canFire = true;

    }
    //void Update()
    //{
    //    Firelaser(transform.forward * maxDistance);
        
    //}

    Vector3 castRay()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;
        if(Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("we hit: " + hit.transform.name);
            SpawnExplosion(hit.point, hit.transform);

            if (hit.transform.CompareTag("Pickup"))
            {
                hit.transform.GetComponent<Pickup>().PickupHit();
            }
           
            return hit.point;   
        }
        Debug.Log("we missed...");
        return transform.position + transform.forward * maxDistance;
    }

    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if (temp != null)
        {
            temp.asteroidHit(hitPosition);
            temp.AddForce(hitPosition, transform);
        }
    }
    public void Firelaser()
    {
       Vector3 pos = castRay();
        FireLaser(pos);
        
    }

    public void FireLaser(Vector3 targetposition, Transform target = null)
    {
        if (canFire)
        {
            if (target != null) {
                SpawnExplosion(targetposition, target);
            }
            
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetposition);
            canFire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("Canfire", FireDelay);
        }
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        canFire = true;
     }

    public float Distance
    {
        get{ return maxDistance; }
    }

    void Canfire()
    {
        canFire = true;
    }
}
