using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLayer : MonoBehaviour
{
    public float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Vector3 endPos = transform.position + new Vector3(0, 1, 0);
            transform.position = Vector3.Lerp(transform.position, endPos, 1f);
            timer = 3;
        }

    }

    //collision
    private void OnTriggerEnter(Collider other)
    {
        if ()
        {

        }
    }
}
