using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patinete : MonoBehaviour {

    public float speed;
    public static bool onScooter = false;
    public GameObject player_scooter_pos;
    public GameObject player;
    public GameObject jump_patinete;
    public BoxCollider col1, col2;
    public GameObject get_out;
    public GameObject posee;
    public float jumpForce;
    public GameObject ui;
    public GameObject cam;


    private Rigidbody rb = new Rigidbody();

    //Audio
    public AudioSource jump, land;
    private bool jump_ = false;

    void Start ()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        player_scooter_pos = GameObject.FindGameObjectWithTag("Erizo_Patinete");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && onScooter && jump_)
        //{
        //    GetComponent<Rigidbody>().AddForce((Vector3.up * jumpForce) * Time.deltaTime, ForceMode.Impulse);
        //    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
        //    jump.Play();
        //    //Instantiate particles
        //    //Instantiate(jump_patinete, transform.position, Quaternion.identity);
        //}

        if (onScooter == true)
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime;

            //transform.Translate(0, 0, -h * speed);
            rb.MovePosition(rb.position + new Vector3(h * speed, 0, 0));

        }

    }

	void Update ()
    {

        //if (Input.GetKeyDown(KeyCode.Space) && onScooter && jump_)
        //{
        //    GetComponent<Rigidbody>().AddForce((Vector3.up * jumpForce) * Time.deltaTime, ForceMode.Impulse);
        //    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
        //    jump.Play();
        //    //Instantiate particles
        //    //Instantiate(jump_patinete, transform.position, Quaternion.identity);
        //}

        //if (onScooter == true)
        //{
        //    float h = Input.GetAxis("Horizontal") * Time.deltaTime;

        //    //transform.Translate(0, 0, -h * speed);
        //    Rigidbody body = GetComponent<Rigidbody>();
        //    body.MovePosition(body.position + new Vector3(h * speed, 0, 0));

        //}


        if (onScooter == false)
        {
            posee.gameObject.SetActive(false);
            player.gameObject.SetActive(true);
            cam.GetComponent<Camera_Follow>().offset2 = new Vector3(0, 1.6f, 4.28f);
            speed = 0.0f;
        }
        if(onScooter == true)
        {

            cam.GetComponent<Camera_Follow>().offset2 = new Vector3(2, 1.6f, 4.28f);

            if (Input.GetKeyDown(KeyCode.Space) && jump_)
            {
                rb.AddForce((Vector3.up * jumpForce));
                GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                jump.Play();
                //Instantiate particles
                //Instantiate(jump_patinete, transform.position, Quaternion.identity);
            }

            //transform.Translate(0, 0, -h * speed);


            speed = 6 + Coger_Dieta.addition;
         
            posee.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
 
            if (transform.position.x > get_out.transform.position.x)
            {
                player.gameObject.SetActive(true);
                player.transform.SetParent(null);

                player.GetComponent<player_movement>().enabled = true;
                onScooter = false;
                player.GetComponent<Animator>().enabled = true;
                player.AddComponent<Rigidbody>();
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                BoxCollider[] boxes = player.GetComponentsInChildren<BoxCollider>();
                cam.GetComponent<Camera_Follow>().offset2 = new Vector3(0, 1.6f, 4.28f);
                cam.GetComponent<Camera_Follow>().STAGE2_SCOOTER = false;

                for (int i = 0; i < boxes.Length; i++)
                {
                    boxes[i].enabled = true;
                }

                posee.gameObject.SetActive(false);
                Destroy(gameObject.GetComponent<Patinete>());
                Destroy(gameObject.GetComponent<Coger_Dieta>());
               
            }
        }
	}

    //void OnTriggerEnter(Collider col) 
    //{
    //    if(col.gameObject.tag == "Get_out_scooter")
    //    {
    //        player.gameObject.SetActive(true);
    //        player.transform.SetParent(null);

    //        player.GetComponent<player_movement>().enabled = true;
    //        onScooter = false;
    //        player.GetComponent<Animator>().enabled = true;
    //        player.AddComponent<Rigidbody>();
    //        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    //        BoxCollider[] boxes = player.GetComponentsInChildren<BoxCollider>();

    //        for (int i = 0; i < boxes.Length; i++)
    //        {
    //            boxes[i].enabled = true;
    //        }

    //        Destroy(gameObject);
    //    }
    //}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Carretera")
        {
            land.Play();
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

                if(onScooter == false)
                {
                    Destroy(ui.gameObject);
                    col.gameObject.transform.position = player_scooter_pos.transform.position + new Vector3(3.0f,0,0);
                    col.transform.SetParent(transform);
                    Debug.Log("Enter");
                    col.gameObject.GetComponent<player_movement>().enabled = false;
                    onScooter = true;
                    cam.GetComponent<Camera_Follow>().STAGE2_SCOOTER = true;
                    
                    col.gameObject.GetComponent<Animator>().enabled = false;
                    //col.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    //col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    BoxCollider[] boxes = col.GetComponentsInChildren<BoxCollider>();
                    

                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].enabled = false;
                    }

                    Destroy(col.gameObject.GetComponent<Rigidbody>());
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                }

                

            }


        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Soil")
        {
            jump_ = true;
        }
    }


    void OnCollisionExit(Collision col)
    {
        if (jump_)
        {
            jump_ = false;
        }
    }









}
