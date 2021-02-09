using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Presentation : MonoBehaviour {


    public GameObject zoom;
    public float timer = 2.0f;
    private Transform original_camera;

	void Start ()
    {
        GameObject ca = GameObject.FindGameObjectWithTag("Object_Camera");
        GameObject.FindGameObjectWithTag("Object_Camera").GetComponent<Camera_Follow>().
                enabled = false;
        original_camera = ca.transform;
        ca.transform.position = zoom.transform.position;

    }

	void Update ()
    {

        timer -= Time.deltaTime;

		if(timer < 0.0f)
        {
            GameObject.FindGameObjectWithTag("Object_Camera").transform.position =
            original_camera.transform.position;
            GameObject.FindGameObjectWithTag("Object_Camera").GetComponent<Camera_Follow>().
                enabled = true;
            Destroy(this.gameObject);
        }
	}
}
