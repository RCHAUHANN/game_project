using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject Blowup;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float LaserHitModifier = 10f;
    [SerializeField] Sheild sheild;

    public void asteroidHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);
        if (sheild == null)
        {
            return;
        }
        sheild.TakeDamage();
    }
    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            asteroidHit(contact.point);
        }
    }

    public void AddForce(Vector3 hitposition, Transform hitSource)
    {
        asteroidHit(hitposition);
        if(rigidbody == null)
        {
            return;
        }
        Vector3 forceVector = (hitSource.position - hitposition).normalized;
        rigidbody.AddForceAtPosition(forceVector * LaserHitModifier, hitposition,ForceMode.Impulse);
    }

    

   public void BlowUp()
    {
        
        GameObject temp =  Instantiate(Blowup, transform.position, Quaternion.identity) as GameObject;
        Destroy(temp, 3f);
        Destroy(gameObject);

    }
}
