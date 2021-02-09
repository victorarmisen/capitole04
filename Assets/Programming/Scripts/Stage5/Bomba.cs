using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;

public class Bomba : MonoBehaviour {

    public static bool EXPLOTAR = false;
    public GameObject explosivo;
    public GameObject explosive1;
    public GameObject particles_explosion;
    public GameObject fade;
    private bool get_out = false;
    public Text text_introduction;
    public Text t_fight;
    public GameObject viñeta;
    public GameObject search_keys;

    //public PostProcessVolume post;
    //Vignette vig = null;
    public AudioSource explote_puerta;

    private float timer = 3.0f, timer2 = 5.0f, timerLlaves = 3.0f;

    void Start()
    {
        fade.GetComponent<Fade>().Level = 7;

        t_fight.gameObject.SetActive(false);
    }

    void Fade_Function()
    {
        //post.profile.TryGetSettings(out vig);
    }


    void Update()
    {
        GameObject[] llaves = GameObject.FindGameObjectsWithTag("Key");

        if (llaves.Length == 0)
        {
            search_keys.SetActive(false);
            EXPLOTAR = true;          
        }
        else
        {
            search_keys.SetActive(true);
            EXPLOTAR = false;
        }

        if(get_out)
        {
            timer2 -= Time.deltaTime;

            Fade_Function();
            //vig.intensity.value += 0.001f;

            if (timer2 < 0)
            {
                Instantiate(fade, transform.position, Quaternion.identity);
            }

        }

    }



    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {

            if(EXPLOTAR)
            {
                text_introduction.text = "Press E to detonate";               
                viñeta.GetComponent<Image>().enabled = true;
            }

            if(Input.GetKeyDown(KeyCode.E) && EXPLOTAR)
            {

                text_introduction.gameObject.SetActive(false);
                viñeta.SetActive(false);
                t_fight.gameObject.SetActive(true);

                Instantiate(particles_explosion, explosivo.transform.position, Quaternion.identity);
                Destroy(explosivo.gameObject);
                //Destroy(this.gameObject);
                Destroy(explosive1.gameObject);
                //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Follow>().enabled = false;
                GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                explote_puerta.Play();

                //timer -= Time.deltaTime;


                get_out = true;
                //Destroy(this.gameObject);
                       
                //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().shakeAmount = 5.0f;
              

            }
            if (Input.GetKeyDown(KeyCode.E) && !EXPLOTAR)
            {

                text_introduction.text = "You need 2 keys to detonate the dynamite.";
                
                viñeta.GetComponent<Image>().enabled = true;


            }

        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            text_introduction.text = "";
            viñeta.GetComponent<Image>().enabled = false;
        }
         
    }



}
