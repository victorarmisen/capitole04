using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(h * speed, 0, v * speed);

	}
}
