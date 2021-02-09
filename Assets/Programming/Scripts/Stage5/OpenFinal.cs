using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFinal : MonoBehaviour {

    private float timer = 8.0f;
    public Vector3 direction;
    public bool FinalOpen = false;
    //private bool enterSecond = true;
    private int dir = 1;

    void Start()
    {

    }

    void Update()
    {

        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //float distance = Vector3.Distance(player.transform.position, transform.position);

        //if (distance < 5.0f && enterSecond)
        //{
        //    enterFirst = true;
        //    enterSecond = false;
        //}


        if (FinalOpen == true)
        {
            timer -= Time.deltaTime;

            if (timer > 0.0f)
            {
                transform.Translate(direction * dir * Time.deltaTime);

            }
            else
            {
                FinalOpen = false;
            }


        }
    }
}


