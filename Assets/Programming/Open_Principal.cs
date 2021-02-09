using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Principal : MonoBehaviour {

    public AudioSource open;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, 
            transform.position);

        if (distance < 5.0f)
        {
            open.Play();
            Destroy(this);
        }
       

    }
}
