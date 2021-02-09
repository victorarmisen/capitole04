using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    private float timer = 8.0f;
    public Vector3 direction;
    private bool enterFirst = false;
    private bool enterSecond = true;
    private int dir = 1;

    void Start ()
    {
        direction = new Vector3(0, 0, 1);

    }
	
	void Update ()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector3.Distance(player.transform.position, transform.position);

        Debug.Log(distance);

        if(gameObject.tag == "GateDown")
        {
            dir = -1;
        }

        if (gameObject.tag == "GateUp")
        {
            dir = 1;
        }

        //if (distance < 5.0f && enterSecond)
        //{
        //    enterFirst = true;
        //    enterSecond = false;
        //}


        //if (enterFirst == true)
        //{
            timer -= Time.deltaTime;

            if (timer > 0.0f)
            {
                transform.Translate(direction * dir * Time.deltaTime);
                
            } else
            {
                enterFirst = false;
            }


        //}

        

	}



}
