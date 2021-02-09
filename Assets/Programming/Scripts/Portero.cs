using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portero : MonoBehaviour {

    private Vector3[] random_tirada = new Vector3[3];
    public float fuerza_impulso;
    private Animator anim;

    void Start ()
    {
        random_tirada[0] = Vector3.right;
        random_tirada[1] = -Vector3.right;
        random_tirada[2] = Vector3.zero;
        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {

        //Aplicamos una fuerza para simular la tirada
        //del portero

        //Cuando simulamos esa fuerza??
        //Normalmente el portero realiza
        //la accion cuando el jugador chuta

        Tirada_Portero();

    }


    void Tirada_Portero()
    {

        if(Chute.CHUTE)
        {
            anim.SetBool("Parada", true);
            anim.Play("Parada");

            this.gameObject.GetComponent<Rigidbody>().AddForce(
                random_tirada[Random.Range(0, 3)] * fuerza_impulso, ForceMode.Impulse);
            Chute.CHUTE = false;
        }

    }


}
