using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helices : MonoBehaviour {

    public Vector3 direction;
	
	void Update ()
    {

        transform.Rotate(direction);

	}

}
