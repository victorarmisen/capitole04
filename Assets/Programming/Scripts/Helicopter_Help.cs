using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;

public class Helicopter_Help : MonoBehaviour {

    private GameObject player;
    private float time1 = 0.0f;
    private float time2 = 0.0f;
    public Transform posicion_helicopter;
    private bool reachPlayer = false;
    private Vector3 player_near_point;
    private Quaternion initialRot;
    private Vector3 distance_from;
    public GameObject reset_fall;
    public GameObject exit_helicoptero;
    private GameObject cam_second;

    private float timeCount2 = 0.0f;

    //public PostProcessVolume post;

    //Vignette vig = null;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //distance_from = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        cam_second = GameObject.FindGameObjectWithTag("MainCamera");
        //Debug.Log(cam_second.gameObject.name);
        initialRot = player.transform.rotation;
        player_near_point = GameObject.FindGameObjectWithTag("Point_Respawn").transform.position;
        
        //post = cam_second.gameObject.GetComponent<PostProcessVolume>();


    }

    void Fade_Function()
    {
        //post.profile.TryGetSettings(out vig);
    }

    void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
	
	void Update ()
    {
        //Va a la posicion del jugador
        //lo añadimos como child del helicoptero
        //Lo posicionamos en el helicoptero
        //Va a la posicion segura

        //transform.position = Vector3.Slerp(transform.position, player.transform.position, time1);
        //time1 = time1 * Time.deltaTime;

        if(!reachPlayer && Vector3.Distance(transform.position, player.transform.position) > 2.0f)
        {
            float step = 3.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            player.gameObject.SetActive(false);
            //transform.LookAt(player.transform);
            
            //transform.LookAt(player.transform, Vector3.up);
        }
        else
        {
            reachPlayer = true;
        }

        //player.transform.SetParent(transform);

        //posicion_helicopter = transform.GetChild(2).transform.position;

        //player.transform.position = posicion_helicopter;

        Debug.Log(reachPlayer);

        if (reachPlayer)
        {

            //GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            

            Debug.Log(player_near_point);

            player.gameObject.SetActive(false);

            player.transform.position = posicion_helicopter.position;

            BoxCollider[] boxes = player.GetComponentsInChildren<BoxCollider>();

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].enabled = false;
            }

            player.GetComponent<Animator>().enabled = false;

            player.transform.SetParent(transform);

            //transform.LookAt(player.transform);

            transform.eulerAngles = Vector3.up * 90;

            //Conseguir el child para que el jugador se ponga ahi

            Debug.Log("Go to the point");

            float step2 = 4.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player_near_point, step2);
            
            //Cuando lleguemos al destino, lo soltamos para que siga jugando

            if(Vector3.Distance(transform.position, player_near_point) < 2.0f)
            {
                player.gameObject.SetActive(true);
                player.GetComponent<player_movement>().enabled = true;
                player.GetComponent<Animator>().enabled = true;
                player.AddComponent<Rigidbody>();
                player.transform.rotation = initialRot;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ
                    | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;

                //Instance Particle to disappear the helicopter
                player.transform.parent = null;
                player.transform.position = player_near_point;

                player.GetComponent<Animator>().SetFloat("speed", 1);

                BoxCollider[] boxes2 = player.GetComponentsInChildren<BoxCollider>();

                for (int i = 0; i < boxes2.Length; i++)
                {
                    boxes2[i].enabled = true;
                }

                //GameObject.FindGameObjectWithTag("Object_Camera").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x,
                //    GameObject.FindGameObjectWithTag("Player").transform.position.y, distance_from.z);

                reset_fall = GameObject.Find("Reset_Fall");

                GameObject.Find("Heli_sound").GetComponent<AudioSource>().volume = 0.25f;

                Destroy(this.gameObject);
                GameObject.FindGameObjectWithTag("Object_Camera").transform.GetChild(0).gameObject.SetActive(true);
                Destroy(GameObject.Find("Heli_sound"));

                //transform.position = Vector3.Slerp(transform.position, new Vector3(356f,
                //    10.0f, 0.0f), timeCount2);
                //timeCount2 = timeCount2 + Time.deltaTime * 0.001f;

                //Destroy(reset_fall.gameObject);
            }

        }

 

    }

  

}
