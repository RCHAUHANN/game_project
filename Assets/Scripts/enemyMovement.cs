using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationdamp = .5f;
    [SerializeField] float movement = 10f;
    [SerializeField] float RaycastOffset = 2.5f;
    [SerializeField] float detectionDistance = 10f;


    // Update is called once per frame


    private void OnEnable()
    {
        EventManager.onPlayerDeath += FindmainCamera;
        EventManager.onStartGame += SelfDestruct;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDeath -= FindmainCamera;
        EventManager.onStartGame -= SelfDestruct;
    }
    void Update()
    {
        if(!FindTarget()) 
            return;

        PathFinding();
        //Turn();
        Move();
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
    void Turn()
    {
        Vector3 pos = target.position -transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationdamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movement * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastoffset = Vector3.zero;
        Vector3 left = transform.position - transform.right * RaycastOffset;
        Vector3 right = transform.position + transform.right * RaycastOffset;
        Vector3 up = transform.position + transform.up * RaycastOffset;
        Vector3 down = transform.position - transform.up * RaycastOffset;

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
        {
            raycastoffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            raycastoffset -= Vector3.right;
        }
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            raycastoffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            raycastoffset += Vector3.up;
        }
        if (raycastoffset != Vector3.zero)
        {
            transform.Rotate(raycastoffset * 5f * Time.deltaTime);
        }
        else
            Turn();

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

    void FindmainCamera()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
}
