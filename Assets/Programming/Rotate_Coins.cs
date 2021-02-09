using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Coins : MonoBehaviour {

    private float velocity = 70.0f;
    public bool ARMOR = false;

	void Update ()
    {
        if(!ARMOR)
        transform.Rotate(Vector3.up * velocity * Time.deltaTime);
        else transform.Rotate(Vector3.forward * velocity * Time.deltaTime);
    }

}
