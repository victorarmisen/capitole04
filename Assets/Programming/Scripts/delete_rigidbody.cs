using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_rigidbody : MonoBehaviour {

    private GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player.GetComponent<Rigidbody>());
    }

}
