using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;


public class Text_Pokemon : MonoBehaviour {

    public string textToShow;
    public Text text;
    public GameObject plan_imagen;
    private int counter = 0;
    private float timeLeft = 0.1f;
    public AudioSource click;
    private int i = 0;
    public bool Zoomed;
    private GameObject player;
    public int MaxCharacters = 15;
    private int auxCounter = 0;
    public GameObject viñeta;
    public bool exit_level3 = false;
    public GameObject fade;
    private bool Fin = false;
    public bool Imagen = false;
    public bool Gympass = false;
    

    //Things
    public PostProcessingProfile post;


    // Use this for initialization
    void Start ()
    {
        text = GameObject.FindGameObjectWithTag("Text_Intro").GetComponent<Text>();
        plan_imagen = GameObject.FindGameObjectWithTag("Plan_Imagen");
        plan_imagen.GetComponent<Image>().enabled = true;
        //click = GameObject.Find("Click").GetComponent<AudioSource>();
        viñeta = GameObject.FindGameObjectWithTag("Viñeta");
        //fade = GameObject.Find("fade_out");

        if (gameObject.tag == "Text_Introduction")
        {
            GameObject t = GameObject.FindGameObjectWithTag("Text_Intro");
            text = t.GetComponent<Text>();
        }

        text.text = "";

        if(Imagen)
            plan_imagen.gameObject.SetActive(true);

        if (!Gympass)
            player = GameObject.FindGameObjectWithTag("Player");
        viñeta.SetActive(true);
    }

    IEnumerator timer(float seconds)
    {
        if (exit_level3)
        {      
            Instantiate(fade, transform.position, Quaternion.identity);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            GameObject music = GameObject.FindGameObjectWithTag("Music");

            GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
            ob.GetComponent<Fade>().Out = true;
            ob.GetComponent<Fade>().Enter = false;
            ob.GetComponent<Fade>().cam = camera.GetComponent<Camera>();
            //ob.GetComponent<Fade>().post = post;
            ob.GetComponent<Fade>().Level = 4;

            DontDestroyOnLoad(player.gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(camera.gameObject);
            DontDestroyOnLoad(music);

            player.gameObject.GetComponent<player_stats>().happiness += 20;
        }

        yield return new WaitForSeconds(seconds);
      
    }

    // Update is called once per frame
    void Update ()
    {       
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0 && counter < textToShow.Length && auxCounter < MaxCharacters)
        {

            //click.Play();
            text.text += textToShow[counter];
            counter++;
            auxCounter++;
            
            timeLeft = 0.1f;
            //if(!Gympass)
            //    player.GetComponent<player_movement>().speed = 0;
            //player_movement.h = 0;
            player_movement.CAN_MOVE = false;

            if (!Gympass)
                player.GetComponent<Animator>().SetBool("Idle", true);
 

        } 

        if(auxCounter >= MaxCharacters)
        {
                
            text.text = "";
            auxCounter = 0;           
        }

        if(counter >= textToShow.Length)
        {
            if (!Gympass)
                player.GetComponent<player_movement>().speed = 4;          
            StartCoroutine(timer(2.0f));
            text.text = "";
            //if (!Gympass)
                player.gameObject.GetComponent<player_movement>().enabled = true;
            //if (!Gympass)
                player.GetComponent<player_movement>().speed = 4;
            player_movement.CAN_MOVE = true;
            viñeta.SetActive(false);
            if (Imagen)
                plan_imagen.gameObject.SetActive(false);
                        
            Destroy(this.gameObject);
        }


    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<player_movement>().enabled = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<player_movement>().enabled = true;
        }
    }

    private void Reset()
    {
        if (counter == MaxCharacters)
        {
            text.text = "";
        }
    }



}
