using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica : MonoBehaviour {

    public GameObject player;
    public GameObject text_recepcion;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update ()
    {	
        if(Vector3.Distance(player.transform.position, transform.position) < 1.0f)
        {
            Instantiate(text_recepcion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

	}
}
