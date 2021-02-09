using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Patinete : MonoBehaviour {

    public AudioSource hit;

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Patinete")
        {
            hit.Play();
        }
    }


}
