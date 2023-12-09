using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Laser laser;
    Vector3 hitPosition;
    private void Update()
    {
        if (!FindTarget())
            return;
        InFront();
        HaveLineOfSight();
        if(InFront() && HaveLineOfSight())
        {
            Debug.Log("firing lasers ffs >:( ");
            FireLaser();
        }
    }
    bool InFront()
    {
        Vector3 directiontoTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directiontoTarget);

        if(Mathf.Abs(angle)> 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position,target.position, Color.green);
            return true;
        }
        //Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = target.position - laser.transform.position;

        // Check if the player is within the laser's distance
        
        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                // Debug draw line to player
                Debug.DrawRay(laser.transform.position, direction, Color.green);
                hitPosition = hit.transform.position;
                return true;
            }
            else
            {
                // Debug draw line to hit object (not player)
                Debug.DrawRay(laser.transform.position, direction, Color.yellow);
                Debug.Log("Ray hit object: " + hit.transform.name);
            }
        }
        else
        {
            // Debug draw line showing the laser's maximum distance
            Debug.DrawRay(laser.transform.position, direction.normalized * laser.Distance, Color.red);
            Debug.Log("No line of sight to player. Distance: " + Vector3.Distance(laser.transform.position, target.position));
        }

        return false;
    }

    void FireLaser()
    {
        Debug.Log("fire lasers !!!!!...." + hitPosition + ",Target: "+ target.position);
        laser.FireLaser(hitPosition,target);
    }

    bool FindTarget()
    {
        if (target != null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp != null)
            {
                target = temp.transform;
            }
            
        }
        if (target == null)
            return false;
        return true;
    }
}
