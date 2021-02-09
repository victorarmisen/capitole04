using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Minigame_Pc : MonoBehaviour {

    public GameObject cam;
    private bool begin_minigame = true;
    public bool Win = false;
    private GameObject title_minigame, play_minigame;
    private bool GET_OBJECTIVE = false;
    private GameObject minijuego;

    private GameObject Enemigos, Jugador, Paredes;
    private Vector3 distance_from;
    private Vector3 original_rot;
    private GameObject juego_Minjuego;

    public GameObject complication;
    public GameObject resetPos_Player;

    void Start ()
    {

        title_minigame = GameObject.FindGameObjectWithTag("Tittle_Minigame");
        play_minigame = GameObject.FindGameObjectWithTag("Play_Minigame");

        distance_from = GameObject.FindGameObjectWithTag("Object_Camera").transform.position;
        original_rot = new Vector3(12.8f, 0.0f, 0.0f);

        Enemigos = GameObject.Find("Enemigos");
        Jugador = GameObject.Find("Jugador");
        Paredes = GameObject.Find("Paredes");

        cam = GameObject.FindGameObjectWithTag("Object_Camera");
        juego_Minjuego = GameObject.FindGameObjectWithTag("Minijuego_PC");

    }

    void Update ()
    {

        if (Win /*&& complication == complication.activeSelf == false*/ && complication != null)
        {

            Debug.Log("HAS GANADO");

            juego_Minjuego.GetComponent<PC_Stage3>().MINIGAME = false;    
            
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<player_movement>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<player_attack>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<player_stats>().knowledge = 80.0f;

            //Position Camera
            GameObject.FindGameObjectWithTag("Object_Camera").transform.position 
                = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x,
                   1.754517f, distance_from.z);

            //Rotation Camera
            GameObject.FindGameObjectWithTag("Object_Camera").transform.GetChild(0).localEulerAngles
               = new Vector3(12.8f, -0.1f,
                   0.0f);
        
            cam.GetComponent<Camera_Follow>().enabled = true;

            //Complication: 
            if(complication.gameObject != null)
            {
                complication.GetComponent<Minigame_Complication>().counter = 0;
                complication.GetComponent<Minigame_Complication>().selection_game.SetActive(false);
                for (int i = 0; i < complication.GetComponent<Minigame_Complication>().buttons_choose.Length; i++)
                {
                    complication.GetComponent<Minigame_Complication>().buttons_choose[i].SetActive(false);
                }           

                complication.SetActive(false);
                complication.GetComponent<Minigame_Complication>().enabled = false;
            }
            
            //Destroy(this.gameObject); //Mas que destruir, poner invisible y reinciarlo para que se pueda volver a jugar.
            gameObject.SetActive(false);
            //Destroy(Enemigos); // Same
            Enemigos.SetActive(false); // Reiniciar velocidad a la rapida por si vuelve a jugar. 
            //Destroy(Jugador); // Reiniciar player position.
            Jugador.transform.position = resetPos_Player.transform.position;
            Jugador.SetActive(false);
            //Destroy(Paredes); // Reinciar paredes. 
            Paredes.SetActive(false);
            //Destroy(GameObject.FindGameObjectWithTag("Press_E"));
            //GameObject.FindGameObjectWithTag("Press_E").SetActive(false);
            //if complicacion ya no se usa eliminarlo y evitar problemas. 
            juego_Minjuego.GetComponent<PC_Stage3>().gameBegins = false;
            Win = false;
        }
   
    }

    private IEnumerator Delay_Game(float s)
    {
        yield return new WaitForSeconds(s);
    }

}
