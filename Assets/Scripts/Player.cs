using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    Creator/Editor: Phillip De Kock
    Creation Date: 17/3/2020
    Last Update: 17/3/2020
    Description: Determines the players movement capabilities.
    */

public class Player : MonoBehaviour
{
    public bool checkForward = false;
    public bool checkForwardDown = false;
    public bool checkForwardUp = false;
    public bool checkUp = false;
    public bool checkDown = true;

    public LayerMask check;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Detect()
    {
        Vector3 offsetRay = new Vector3(0, 0.6f, 0);
        RaycastHit hit;
        //Fires a raycast forward
        Ray rayForward = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);
        //Fires a raycast forward down
        Ray rayForwardDown = new Ray(transform.position - offsetRay, Vector3.forward);
        Debug.DrawRay(transform.position - offsetRay, Vector3.forward, Color.green);
        //Fires a raycast forward up
        Ray rayForwardUp = new Ray(transform.position + offsetRay, Vector3.forward);
        Debug.DrawRay(transform.position + offsetRay, Vector3.forward, Color.green);
        //Fires a raycast up
        Ray rayUp = new Ray(transform.position, Vector3.up);
        Debug.DrawRay(transform.position, Vector3.up, Color.green);
        
        //Fires a raycast down
        Ray rayDown = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(transform.position, -Vector3.up, Color.green);

        //Check forward
        if (Physics.Raycast(rayForward, out hit, 1, check))
        {
            checkForward = true;
            Debug.Log("Forward: Detected");
        }
        else
        {
            checkForward = false;
            Debug.Log("Forward: Clear");
        }
        //Check forward down
        if (Physics.Raycast(rayForwardDown, out hit, 1, check))
        {
            checkForwardDown = true;
            Debug.Log("Forward Down: Detected");
        }
        else
        {
            checkForwardDown = false;
            Debug.Log("Forward Down: Clear");
        }
        //Check forward up
        if (Physics.Raycast(rayForwardUp, out hit, 1, check))
        {
            checkForwardUp = true;
            Debug.Log("Forward Up: Detected");
        }
        else
        {
            checkForwardUp = false;
            Debug.Log("Forward Up: Clear");
        }
        //Check up
        if (Physics.Raycast(rayUp, out hit, 1, check))
        {
            checkUp = true;
            Debug.Log("Up: Detected");
        }
        else
        {
            checkUp = false;
            Debug.Log("Up: Clear");
        }
        
        //Check down
        if (Physics.Raycast(rayDown, out hit, 0.5f, check))
        {
            checkDown = true;
            Debug.Log("Platform");
        }
        else
        {
            checkDown = false;
            Debug.Log("No Platform");
        }
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, 270.0f, 0.0f, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Detect();

            if (checkDown == false)
            {
                //Player Fall
            }
            //Horizontal Movement
            else if (checkForward == false && checkForwardDown == false)
            {
                //Move Forward
                transform.Translate(Vector3.forward);
            }
            //Vertical Movement
            else if (checkForwardUp == false && checkUp == false)
            {
                //Move Up/Forward
                transform.Translate(Vector3.up);
                transform.Translate(Vector3.forward);
            }
        }
    }
}
