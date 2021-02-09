using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Rendering.PostProcessing;
using CameraFading;

public class Armor : MonoBehaviour {

    public int Level;
    public int LevelBar;
    public GameObject camera_player;
    public GameObject fade;
    public AudioSource get_click;
    public float timer = 2.5f;
    private bool Music = false;
    private bool PlayOnce = true;
    //public PostProcessingBehaviour PP;

    //public PostProcessVolume post;

    //Vignette vig = null;

    void Start()
    {
        camera_player = GameObject.FindGameObjectWithTag("Object_Camera").transform.GetChild(0).gameObject;
        //Debug.Log(camera_player.name);
    }

    void Fade_Function()
    {
        //post.profile.TryGetSettings(out vig);
    }

    void Update()
    {
        if(Music)
        {
            timer -= Time.deltaTime;

            Fade_Function();
            //vig.intensity.value += 0.001f;

            if (timer < 0.0f)
            {
                switch(LevelBar)
                {
                    case 2:
                        //GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                        //ob.GetComponent<Fade>().Out = true;
                        //ob.GetComponent<Fade>().Enter = false;
                        //ob.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                        //ob.GetComponent<Fade>().post = post;
                        
                        SceneManager.LoadScene(Level);
                        //CameraFade.Out(2f);
                        break;
                    case 3:
                        //GameObject ob2 = Instantiate(fade, transform.position, Quaternion.identity);
                        //ob2.GetComponent<Fade>().Out = true;
                        //ob2.GetComponent<Fade>().Enter = false;
                        //ob2.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                        ////ob2.GetComponent<Fade>().post = post;
                        //ob2.GetComponent<Fade>().Level = Level;
                        //CameraFade.Out(2f);
                        SceneManager.LoadScene(Level);
                        break;
                    case 4:
                        //GameObject ob3 = Instantiate(fade, transform.position, Quaternion.identity);
                        //ob3.GetComponent<Fade>().Out = true;
                        //ob3.GetComponent<Fade>().Enter = false;
                        //ob3.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                        ////ob3.GetComponent<Fade>().post = post;
                        //ob3.GetComponent<Fade>().Level = Level;
                        //CameraFade.Out(2f);
                        SceneManager.LoadScene(Level);
                        break;
                    case 5:
                        //GameObject ob4 = Instantiate(fade, transform.position, Quaternion.identity);
                        //ob4.GetComponent<Fade>().Out = true;
                        //ob4.GetComponent<Fade>().Enter = false;
                        //ob4.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                        //ob4.GetComponent<Fade>().post = post;
                        //ob4.GetComponent<Fade>().Level = Level;
                        ////collision.gameObject.GetComponent<player_stats>().happiness += 50;
                        //CameraFade.Out(2f);
                        SceneManager.LoadScene(Level);
                        //CameraFade.Out(2f);
                        break;
                    case 6:
                        //GameObject ob5 = Instantiate(fade, transform.position, Quaternion.identity);
                        //ob5.GetComponent<Fade>().Out = true;
                        //ob5.GetComponent<Fade>().Enter = false;
                        //ob5.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                        ////ob5.GetComponent<Fade>().post = post;
                        //ob5.GetComponent<Fade>().Level = Level;
                        //CameraFade.Out(2f);
                        SceneManager.LoadScene(Level);
                        break;
                    case 7:
                        //GameObject ob6 = Instantiate(fade, transform.position, Quaternion.identity);
                        //ob6.GetComponent<Fade>().Out = true;
                        //ob6.GetComponent<Fade>().Enter = false;
                        //ob6.GetComponent<Fade>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                        ////ob6.GetComponent<Fade>().post = post;
                        //ob6.GetComponent<Fade>().Level = Level;
                        ////CameraFade.Out(2f);
                        //SceneManager.LoadScene(Level);
                        SceneManager.LoadScene(Level);
                        break;


                }
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(LevelBar == 2)
            {
                //collision.gameObject.GetComponent<player_stats>().motivation += 50;
                //camera_player.GetComponent<Camera_Follow>().offset2 = new Vector3(0, 2, 4.0f);
                if(PlayOnce)
                {
                    get_click.Play();
                    PlayOnce = false;
                }
                   
                Music = true;
                //if(timer < 0.0f)
                //{
                //    GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                //    ob.GetComponent<Fade>().Out = true;
                //    ob.GetComponent<Fade>().Enter = false;
                //    ob.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                //    ob.GetComponent<Fade>().post = post;
                //    ob.GetComponent<Fade>().Level = Level;
                //}
                
            }
            if (LevelBar == 3)
            {
                if (PlayOnce)
                {
                    get_click.Play();
                    PlayOnce = false;
                }

                Music = true;
                //if (timer < 0.0f)
                //{
                //    GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                //    ob.GetComponent<Fade>().Out = true;
                //    ob.GetComponent<Fade>().Enter = false;
                //    ob.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                //    ob.GetComponent<Fade>().post = post;
                //    ob.GetComponent<Fade>().Level = Level;
                //    //collision.gameObject.GetComponent<player_stats>().knowledge += 50;
                //}
            }
            if(LevelBar == 4)
            {
                if (PlayOnce)
                {
                    get_click.Play();
                    PlayOnce = false;
                }
                Music = true;
                //if (timer < 0.0f)
                //{
                //    GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                //    ob.GetComponent<Fade>().Out = true;
                //    ob.GetComponent<Fade>().Enter = false;
                //    ob.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                //    ob.GetComponent<Fade>().post = post;
                //    ob.GetComponent<Fade>().Level = Level;
                //    //collision.gameObject.GetComponent<player_stats>().happiness += 20;
                //}
            }
            if (LevelBar == 5)
            {
                if (PlayOnce)
                {
                    get_click.Play();
                    PlayOnce = false;
                }
                Music = true;
                if (timer < 0.0f)
                {
                    //GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                    //ob.GetComponent<Fade>().Out = true;
                    //ob.GetComponent<Fade>().Enter = false;
                    //ob.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                    //ob.GetComponent<Fade>().post = post;
                    //ob.GetComponent<Fade>().Level = Level;
                    //collision.gameObject.GetComponent<player_stats>().happiness += 50;
                    //SceneManager.LoadScene(Level);
                }
            }
            if (LevelBar == 6)
            {
                if (PlayOnce)
                {
                    get_click.Play();
                    PlayOnce = false;
                }
                Music = true;
                //if (timer < 0.0f)
                //{
                //    GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                //    ob.GetComponent<Fade>().Out = true;
                //    ob.GetComponent<Fade>().Enter = false;
                //    ob.GetComponent<Fade>().cam = camera_player.GetComponentInChildren<Camera>();
                //    ob.GetComponent<Fade>().post = post;
                //    ob.GetComponent<Fade>().Level = Level;
                //}
            }
            if (LevelBar == 7)
            {
                if (PlayOnce)
                {
                    get_click.Play();
                    PlayOnce = false;
                }
                Music = true;
                //if (timer < 0.0f)
                //{
                //    GameObject ob = Instantiate(fade, transform.position, Quaternion.identity);
                //    ob.GetComponent<Fade>().Out = true;
                //    ob.GetComponent<Fade>().Enter = false;
                //    ob.GetComponent<Fade>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                //    ob.GetComponent<Fade>().post = post;
                //    ob.GetComponent<Fade>().Level = Level;
                //    SceneManager.LoadScene(Level);
                //}
            }
        }
    }
}
