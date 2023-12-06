using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.8f;
    [SerializeField] float rotationOffset = 100f;
    public static float destructionDelay = 1.0f;
    
    Transform myT;
    Vector3 randonRotation;

    private void Awake()
    {
        myT = transform;
    }

    void Start()
    {
        //random size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        myT.localScale = scale;

        //random rotation
        randonRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randonRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randonRotation.z = Random.Range(-rotationOffset, rotationOffset);

        //Debug.Log(randonRotation);
    }

    // Update is called once per frame
    void Update()
    {
       myT.Rotate(randonRotation * Time.deltaTime); 
    }


    public void SelfDestruct()
    {
        float timer = Random.Range(0, destructionDelay);
        Invoke("GoBoom", timer);
    }

    public void GoBoom()
    {
        GetComponent<Explosion>().BlowUp();
    }
   
}
