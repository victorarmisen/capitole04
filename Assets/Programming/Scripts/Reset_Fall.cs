using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;

public class Reset_Fall : MonoBehaviour 
{

    public GameObject player;
    public GameObject Helicopter_prefab;
    public GameObject particle_save_erizo;
    public AudioSource heli_sound, chof;
    public GameObject Camera_main;
    //public PostProcessVolume pv;

    private bool Once = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heli_sound.Play(); 
        //heli = GameObject.FindGameObjectWithTag("Helicopter");
    }

    void Update()
    {
        if(player.transform.position.y < 0.2f)
        {
            //Erizo can't move
            if(Once)
            {
                chof.Play();
            }
            Camera_main.transform.gameObject.SetActive(false);
            player.GetComponent<player_movement>().enabled = false;
            player.GetComponent<Animator>().Play("Die");
           
            Destroy(player.GetComponent<Rigidbody>());
            GameObject h = Instantiate(Helicopter_prefab, transform.position, Quaternion.identity);
            //h.GetComponent<Helicopter_Help>().post = pv;
            //Set the player in the helicopter
            //player.transform.position = Helicopter_prefab.transform.position;
            //player.transform.SetParent(Helicopter_prefab.transform);
            //Instantiate(particle_save_erizo, player.transform.position, Quaternion.identity);


            //this.enabled = false;
            Destroy(this.gameObject);
        }
    }



}
