using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;


public class TextPokemon : MonoBehaviour
{

    public string textToShow;
    public Text text;
    private int counter = 0;
    private float timeLeft = 0.01f;
    public AudioSource click;
    private int i = 0;
    public bool Zoomed;
    private GameObject player;
    public int MaxCharacters;
    private int auxCounter = 0;
    public GameObject Viñeta;
    public bool exit_level3 = false;
    public GameObject fade;
    private bool Fin = false;
    public GameObject Imagen_Stage;
    public bool Imagen;
    public bool zoom_presentation;
    public GameObject zoom_object;
    private bool start = true;

    private float t = 0.5f;

    public PostProcessingProfile post;
    private bool tok1 = false;
    private Vector3 original_Scale, original_Position, o_Pos_Viñeta;

    void Start()
    {
        if (zoom_presentation)
        {         
            zoom_object.gameObject.SetActive(true); ///ERROR
        }
        

        if (gameObject.tag == "Text_Introduction")
        {
            GameObject t = GameObject.FindGameObjectWithTag("Text_Intro");
            text = t.GetComponent<Text>();
        }

        text.text = "";

        player = GameObject.FindGameObjectWithTag("Player");
        Viñeta.GetComponent<Image>().enabled = true;
        if (Imagen)
            Imagen_Stage.GetComponent<Image>().enabled = true;

        original_Scale = Viñeta.GetComponent<RectTransform>().localScale;
        original_Position = text.GetComponent<RectTransform>().position;
        o_Pos_Viñeta = Viñeta.GetComponent<RectTransform>().position;

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

    IEnumerator delay(float s)
    {
        yield return new WaitForSeconds(s);
    }

    // Update is called once per frame
    void Update()
    {
        

        /////////////////////////////////////////////////////////////////////////////////////////////
        int coun = 0;
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //PLAYER
            player.GetComponent<player_movement>().speed = 0;
            player_movement.CAN_MOVE = false;
            player.GetComponent<Animator>().SetFloat("speed", 0.0f);



            if (counter < textToShow.Length)
            {  
                if (auxCounter == 0 && !start) {
                    /*text.text = " ";*/
                    text.text += "\n";
                    text.rectTransform.position += Vector3.up * 20.00f;
                    coun++;
                    Viñeta.GetComponent<RectTransform>().localPosition += Vector3.up * 10.33f;
                    Viñeta.GetComponent<RectTransform>().localScale += Vector3.up * 0.23f;        
                }
                else { start = false; }
                if (coun == 2) { text.text = " "; coun = 0; }
                if ((auxCounter <= MaxCharacters) || ((auxCounter >= MaxCharacters) && (textToShow[counter] != ' ')))
                {
                    text.text += textToShow[counter];
                    counter++;
                    auxCounter++;
                    timeLeft = 0.06f;
                    click.Play();                 
                }
                else
                {
                    auxCounter = 0;
                    timeLeft = 1.4f;
                }
            }
            else if (tok1 == false)
            {
                tok1 = true;
                timeLeft = 1.65f; //DANGER
            }
            else if (tok1 == true)
            {
                player.GetComponent<player_movement>().speed = 4;
                StartCoroutine(timer(2.0f));
                text.text = "";
                player.gameObject.GetComponent<player_movement>().enabled = true;
                player.GetComponent<player_movement>().speed = 4;
                player_movement.CAN_MOVE = true;
                Viñeta.GetComponent<RectTransform>().localScale = original_Scale;
                Viñeta.GetComponent<RectTransform>().position = o_Pos_Viñeta;
                Viñeta.GetComponent<Image>().enabled = false;
                text.GetComponent<RectTransform>().position = original_Position;
                if (Imagen) Imagen_Stage.GetComponent<Image>().enabled = false;
                Destroy(this.gameObject);
            }
        }



    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
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
 