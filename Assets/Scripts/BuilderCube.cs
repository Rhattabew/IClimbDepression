using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCube : MonoBehaviour
{
    /*
    Creator/Editor: Kit
    Creation Date: 6/3/2020
    Last Update: 10/3/2020
    Description: Detects when there is no cube below to support it and falls down there is no cubes below.
    */
    //TODO Despawn the cube
    public bool cubeDown = false;
    public bool cubeDownLeft = false;
    public bool cubeDownRight = false;
    public bool cubeDownForward = false;
    public bool cubeDownBack = false;
    public bool cubeLeft = false;
    public bool cubeRight = false;
    public bool cubeForward = false;
    public bool cubeBack = false;

    public float timerOffset = 0.01f;
    public float cubeTimer = 1f;

    public LayerMask layerMask;
    void OnAwake()
    {
        GetComponent<BoxCollider>().enabled = true;
        cubeTimer = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectDistance();

    }
    void LateUpdate()
    {
        if(cubeTimer <= 0)
        {
            Debug.Log("Timer 2");
            Falling();
        }

        cubeTimer -= Time.deltaTime;
    }

    void DetectDistance()
    {
        Vector3 offsetRay = new Vector3(0,0.6f,0);
        RaycastHit hit;
        //Fires a raycast in each direction
        Ray rayDown = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(transform.position, -Vector3.up, Color.green);

        Ray rayDownLeft = new Ray(transform.position - offsetRay, Vector3.left);
        Debug.DrawRay(transform.position - offsetRay, Vector3.left, Color.green);

        Ray rayDownRight = new Ray(transform.position - offsetRay, -Vector3.left);
        Debug.DrawRay(transform.position - offsetRay, -Vector3.left, Color.green);

        Ray rayDownForward = new Ray(transform.position  - offsetRay, Vector3.forward);
        Debug.DrawRay(transform.position - offsetRay, Vector3.forward, Color.green);

        Ray rayDownBack = new Ray(transform.position - offsetRay, -Vector3.forward);
        Debug.DrawRay(transform.position - offsetRay, -Vector3.forward, Color.green);

        Ray rayLeft = new Ray(transform.position, Vector3.left);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);

        Ray rayRight = new Ray(transform.position, -Vector3.left);
        Debug.DrawRay(transform.position, -Vector3.left, Color.green);

        Ray rayForward = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        Ray rayBack = new Ray(transform.position, -Vector3.forward);
        Debug.DrawRay(transform.position, -Vector3.forward, Color.green);

        if (Physics.Raycast(rayLeft, out hit, 1f, layerMask))
        {
            cubeLeft = true;
            //Debug.Log("Left");
            //Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            cubeLeft = false;
        }
        if (Physics.Raycast(rayRight, out hit, 1, layerMask))
        {
            cubeRight = true;
            //Debug.Log("Right");
        }
        else
        {
            cubeRight = false;
        }
        if (Physics.Raycast(rayForward, out hit, 1, layerMask))
        {
            cubeForward = true;
            //Debug.Log("Forward");
        }
        else
        {
            cubeForward = false;
        }
        if (Physics.Raycast(rayBack, out hit, 1, layerMask))
        {
            cubeBack = true;
            //Debug.Log("Back");
        }
        else
        {
            cubeBack = false;
        }

        //Detects if there is an object next to the cube, if so changes the corresponding bool to true
        if (Physics.Raycast(rayDown, out hit , 0.5f, layerMask))
        {
            cubeDown = true;
            //Debug.Log("Down");
        }
        else
        {
            cubeDown = false;
        }
        if (Physics.Raycast(rayDownLeft, out hit, 1f, layerMask) && cubeDown == false)
        {
            cubeDownLeft = true;
            //Debug.Log("DownLeft");
        }
        else
        {
            cubeDownLeft = false;
        }
        if (Physics.Raycast(rayDownRight, out hit, 1f, layerMask) && cubeDown == false)
        {
            cubeDownRight = true;
            Debug.Log("DownRight");
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            cubeDownRight = false;
        }
        if (Physics.Raycast(rayDownForward, out hit, 1f, layerMask) && cubeDown == false)
        {
            cubeDownForward = true;
            //Debug.Log("DownForward");
        }
        else
        {
            cubeDownForward = false;
        }
        if (Physics.Raycast(rayDownBack, out hit, 1f, layerMask) && cubeDown == false)
        {
            cubeDownBack = true;
            Debug.Log("DownBack");
        }
        else
        {
            cubeDownBack = false;
        }

    }
    void Falling()
    {
        Vector3 endPos = transform.position - new Vector3(0, 1, 0);
        if (cubeDown == false && cubeDownBack == false && cubeDownForward == false && cubeDownLeft == false && cubeDownRight == false)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, 0.5f);
            
            Debug.Log("Timer");
        }
        cubeTimer = 0.5f;
    }


}
