using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_IT : MonoBehaviour {

	void Update ()
    {
        Destroy(this.gameObject, 8.0f);
        GetComponent<SphereCollider>().enabled = false;
	}
}
