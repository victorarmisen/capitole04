using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {

    public Transform initial_position;

	void Start ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = initial_position.position;
        //player.GetComponent<State_Player>().enabled = true;
	}
	

}
