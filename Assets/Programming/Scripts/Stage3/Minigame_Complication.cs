using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_Complication : MonoBehaviour {

    public int counter = 0;
    public int maxFails = 3;
    public Text dificil;
    public GameObject[] buttons_choose;
    public GameObject[] enemigos;
    private float timer = 3.0f, timer2 = 5.0f;
    private bool choosen = false;
    public GameObject selection_game;
	
    void Start()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo_Minijuego");
    }

	void Update ()
    {

        //Debug.Log("Deads: " + counter);

		if(counter >= maxFails)
        {
            //Instantiate text: Dificil verdad?
            dificil.enabled = true;
            Player_Minigame.player_move = false;

            timer -= Time.deltaTime;

            if (timer < 0.0f)
            {
                //Change speed and color of the minigame to make it easy
                for (int i = 0; i < enemigos.Length; i++)
                {
                    enemigos[i].GetComponent<Enemy_Minijuego>().actual_velocity = 3.0f;
                }

                timer2 -= Time.deltaTime;

                dificil.text = "Capitole to the rescue! \n " + "With us you \n " +
                    "will access to any type of training:";

                if (timer2 < 0.0f)
                {
                    choosen = true;
                    dificil.enabled = false;
                }      
            }
                  
        }

        if(choosen)
        {
            //3 buttons on:
            selection_game.SetActive(true);
            for (int i = 0; i < buttons_choose.Length; i++)
            {
                buttons_choose[i].SetActive(true);
            }

            //Destroy(this.gameObject); //Mas que destruir desativar y volver a reinciar. 
            choosen = false;
            this.gameObject.SetActive(false);


            


        }


    }
}
