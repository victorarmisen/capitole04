using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class See_Prision : MonoBehaviour {

    public GameObject prision;
    public Camera cam;

	void Start ()
    {
		
	}
	
	void Update ()
    {

        Debug.Log(cam.fieldOfView);

		//if(Vector3.Distance(prision.transform.position, transform.position) <= 30.0f &&
  //          cam.transform.position.z >= -100)
  //      {
  //          cam.transform.Translate(-0.2f, -0.2f, -0.2f); 

  //}
        //if (Vector3.Distance(prision.transform.position, transform.position) <= 2.0f &&
        //    cam.fieldOfView == 100 && cam.fieldOfView >= 60)
        //{
        //    cam.fieldOfView -= 1.0f;
        //}

        if(Vector3.Distance(prision.transform.position, transform.position) < 2.0f)
        {
            cam.fieldOfView = 60;
            Destroy(this);
        }


    }
}
