using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Fall : MonoBehaviour {
    
    public GameObject reset_fall;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update ()
    { 

        if (player.transform.position.x > transform.position.x)
        {
            reset_fall.gameObject.SetActive(true);
            Destroy(this);
        }
    }
}
