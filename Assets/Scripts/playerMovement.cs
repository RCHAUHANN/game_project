using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float Movement = 100;
    [SerializeField] float turnSpeed = 60;
    [SerializeField] Thruster[] thruster;
    Transform myT;

    void Awake()
    {
        myT = transform;
    }

    // Update is called once per frame
    void Update()
    {
        thrust();
        turn();
    }

    void turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
        myT.Rotate(-pitch,yaw,-roll);
    }

    void thrust()

    {

        if (Input.GetAxis("Vertical") > 0)        
            myT.position += myT.forward * Movement * Time.deltaTime * Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.W))
            foreach(Thruster t in thruster)
                t.Activate();
        else if(Input.GetKeyUp(KeyCode.W))
            foreach (Thruster t in thruster)
                t.Activate(false);

    }
}
