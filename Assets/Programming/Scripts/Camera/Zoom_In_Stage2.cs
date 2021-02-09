using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_In_Stage2 : MonoBehaviour {

    //public Camera camera_main;
    public Vector3 end_pos;
    private float acc = 1.0f;
    //private float t = 0.000012323;
	
	void Update ()
    {
        //transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(0,0,10), timer);
        //timer += timer * Time.deltaTime;

       float distance = Vector3.Distance(transform.position, end_pos);
       if (distance > 1.1f)
        {
            transform.Translate(0, 0, 1 * acc * Time.deltaTime);
            acc += 0.02f;
        }


           

        //Debug.Log(distance);

	}
}
