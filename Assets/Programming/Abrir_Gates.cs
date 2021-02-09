using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrir_Gates : MonoBehaviour {

    GameObject[] PuertasAbajo;
    GameObject[] PuertasArriba;

    void Start()
    {
        PuertasAbajo = GameObject.FindGameObjectsWithTag("GateDown");
        PuertasArriba  = GameObject.FindGameObjectsWithTag("GateUp");
    }

	void Update ()
    {
		if(Bomba.EXPLOTAR == true)
        {
            for (int i = 0; i < PuertasAbajo.Length; i++)
            {
                PuertasAbajo[i].GetComponent<OpenGate>().enabled = true;
                PuertasArriba[i].GetComponent<OpenGate>().enabled = true;               
            }

            Destroy(this);
        }


	}

}
