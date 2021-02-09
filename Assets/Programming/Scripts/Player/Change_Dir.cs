using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Dir : MonoBehaviour {

    private int dir = 1;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y * dir, transform.localEulerAngles.z);
        //    Debug.Log("IZQUIERDA");
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y * dir, transform.localEulerAngles.z);
        //    Debug.Log("DERECHA");
        //}
        //Debug.Log(player_movement.h);
        if (player_movement.h < 0)
        {
            dir = -1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90 * dir, transform.eulerAngles.z);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y * dir, transform.localEulerAngles.z);
        }

        if (player_movement.h > 0)
        {
            dir = 1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90 * dir, transform.eulerAngles.z);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y * dir, transform.localEulerAngles.z);
        }

    }
}
