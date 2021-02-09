using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis_Cartel : MonoBehaviour {

    public GameObject entrada_erizo;
    public bool Error_ = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(Error_)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < 7.0f)
            {
                entrada_erizo.SetActive(true);
                player_movement.CAN_MOVE = false;
                Destroy(this);
            }
        }
        else
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < 3.0f)
            {
                entrada_erizo.SetActive(true);
                player_movement.CAN_MOVE = false;
                Destroy(this);
            }
        }
       
    }
}
