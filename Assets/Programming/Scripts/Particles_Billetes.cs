using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles_Billetes : MonoBehaviour {

    //public GameObject Pick_Billete;
    public AudioSource sonido;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Patinete")
        {
            //GameObject plasma = Instantiate(Pick_Billete, transform.position, Quaternion.identity);
            //Destroy(plasma, 3.0f);
            sonido.Play();
        }
    }

}
