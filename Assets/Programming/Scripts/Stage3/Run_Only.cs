using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_Only : MonoBehaviour {

    private GameObject juego_Minjuego;

    private void Start()
    {
        juego_Minjuego = GameObject.FindGameObjectWithTag("Minijuego_PC");
    }

    void Update ()
    {
		if(juego_Minjuego.GetComponent<PC_Stage3>().MINIGAME)
        {
            GetComponent<Image>().enabled = true;
        } else
        {
            GetComponent<Image>().enabled = false;
        }
	}
}
