using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minijuego_Futbol : MonoBehaviour {

    public static int counterGoals = 0;
    public GameObject jugador_aux;
    public GameObject camera_pos;
    public GameObject cam;
    public static bool begin_futbol = false;
    public GameObject chutador, portero, redtarget, ball;
    private GameObject player;
    public Text marcador;
    //public GameObject gympass_text;
    public GameObject player_outside;
 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("Object_Camera");
        marcador.text = "";
    }

    void Update()
    {
  
        if(begin_futbol)
            marcador.text = "SCORE: " + Minijuego_Futbol.counterGoals.ToString();

        if (counterGoals == 3 && begin_futbol)
        {

            //GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(true);
            player.transform.position = jugador_aux.transform.position;
            player.gameObject.SetActive(true);
            cam.GetComponent<Camera_Follow>().enabled = true;
            //gympass_text.GetComponent<Text_Pokemon>().Gympass = true;
            Destroy(portero);
            Destroy(chutador);
            Destroy(redtarget);
            ball.GetComponent<Ball>().enabled = false;       
            marcador.text = "";
            Destroy(this);
     
            //Debug.Log(counterGoals);
            //Move player to initial pos
            //
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = player_outside.transform.position;
            col.gameObject.SetActive(false);

            cam.transform.position = camera_pos.transform.position;
            cam.GetComponent<Camera_Follow>().enabled = false;
            //Instantiate(gympass_text, transform.position, Quaternion.identity);
            
            //GameObject.FindGameObjectWithTag("Viñeta").gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Chutador").GetComponent<Chute>().enabled = true;
            //gympass_text.gameObject.SetActive(true);

            begin_futbol = true;
        }
    }




}
