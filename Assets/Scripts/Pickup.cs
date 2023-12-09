using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(CapsuleCollider))]
public class Pickup : MonoBehaviour
{
    static int points = 100;
    bool gotHit=false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            if (!gotHit)
            {
                PickupHit();
            }
            
        }
    }

    public void PickupHit()
    {
        if (!gotHit)
        {
            gotHit = true;           
        }

        Debug.Log("player hit us");

        EventManager.ScorePoints(points);
        EventManager.RespawnPickup();
        Destroy(gameObject);
    }
}
