using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte_Stage4 : MonoBehaviour {

    public GameObject respawn;
    private bool DIE = false;
    GameObject player;
    private float timer = 1.0f;
    public AudioSource dead_fail;
    public GameObject chof;
    public bool Stage4 = false;
    private bool once_die = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        once_die = true;
    }

    void Update()
    {
        if(DIE)
        {
            timer -= Time.deltaTime;
            player_movement.CAN_MOVE = false;
            if (Stage4)
                player.SetActive(false);
            if (once_die)
            {
               dead_fail.Play();
               if (Stage4)            
                   Instantiate(chof, player.gameObject.transform.position, chof.transform.rotation);             
               once_die = false;
            }               
            if (timer <= 0)
            {              
                player_movement.CAN_MOVE = true;
                player.SetActive(true);
                player.gameObject.transform.position = respawn.transform.position;         
                player.gameObject.GetComponent<Animator>().Play("Idle");
                timer = 1.0f;
                DIE = false;
                once_die = true;
            }           
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //if (Stage4)
            //    Instantiate(chof, col.gameObject.transform.position, chof.transform.rotation);
            DIE = true;         
            //col.gameObject.GetComponent<Animator>().SetLayerWeight(3, 100);
            //col.gameObject.GetComponent<Animator>().Play("Die");

        }
        
    }

}
