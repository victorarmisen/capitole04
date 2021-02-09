using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class PC_Stage3 : MonoBehaviour {

    public GameObject cam;
    public GameObject main_player;
    public Text tittle;
    public Text play, controls, objective;
    public bool gameBegins = false;
    public GameObject minigame;
    public bool MINIGAME = false;
    public GameObject portatil;
    public GameObject jugador, enemigos, paredes, complication;
    public GameObject mini_condition;
    public GameObject[] botones_A;

    bool estadentro = false;

    void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("Object_Camera");
    }

    private void Update()
    {
        if(estadentro)
        {
            if (gameBegins == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    cam.GetComponent<Camera_Follow>().enabled = false;
                    cam.transform.position = portatil.transform.position;
                    cam.transform.GetChild(0).transform.localEulerAngles = Vector3.zero;

                    main_player.gameObject.GetComponent<player_movement>().enabled = false;
                    main_player.gameObject.GetComponent<player_attack>().enabled = false;

                    tittle.gameObject.SetActive(true);
                    play.gameObject.SetActive(true);
                    controls.gameObject.SetActive(true);
                    objective.gameObject.SetActive(true);
                    gameBegins = true;
                }
            }

            
        }
        if (gameBegins)
        {
            StartCoroutine(Delay_Game(1));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            estadentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            estadentro = false;
        }
    }

    private IEnumerator Delay_Game(float s)
    {
        yield return new WaitForSeconds(s);
        if (Input.GetKeyDown(KeyCode.Return))
        {

            tittle.gameObject.SetActive(false);
            play.gameObject.SetActive(false);
            controls.gameObject.SetActive(false);
            objective.gameObject.SetActive(false);

            jugador.gameObject.SetActive(true);
            enemigos.gameObject.SetActive(true);
            paredes.gameObject.SetActive(true);
            //Instantiate(minigame, transform.position, Quaternion.identity);
            mini_condition.SetActive(true);
            //mini_condition.GetComponent<Minigame_Pc>().Win = false;
            complication.gameObject.SetActive(true);
            //Desactivamos los botones. 
            for (int i = 0; i < botones_A.Length; i++)
            {
                botones_A[i].SetActive(false);
            }
            MINIGAME = true;
            Player_Minigame.player_move = true;

        }
    }

}
