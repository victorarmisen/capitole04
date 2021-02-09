using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Camera cam;
    public float speed;
    private Animator anim;

    public static float h;
    public static float v;
    public float Jump_Force;
    public static bool CAN_MOVE = true;
    public Quaternion iz, de;
    public bool PlayerMove = false;
    bool grounded;
    private float timerWalk = 0.1f;

    private bool jump_ = false;

    public GameObject particles_por;

    //Sound player
    public AudioSource jump;
    public AudioSource walk;
    public AudioSource key;

    //Key
    public bool Stage5 = false;

    //public GameObject chof;

    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayerMove = true;
        CAN_MOVE = true;
    }

    IEnumerator timer(float seconds)
    {    
        yield return new WaitForSeconds(seconds);
        //anim.SetBool("isJumping", false);
        //anim.SetBool("isFalling", true);
    }

    /*
    h = Input.GetAxis("Horizontal") * Time.deltaTime;

    if (h != 0 && jump_ == true)
    {
        anim.Play("Walk");

        anim.SetLayerWeight(0, 100);
        anim.SetBool("punch", false);
        anim.SetBool("Walk_bool", true);

        timerWalk -= Time.deltaTime;

        if (timerWalk < 0.0f)
        {
            walk.Play();
            timerWalk = 0.5f;
        }
    }
    else if (h == 0 && jump_ == true)
    {
        anim.Play("Idle");
        anim.SetLayerWeight(0, 100);
        anim.SetBool("punch", false);
        anim.SetBool("Idle_bool", true);
    }
    else
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(3, 100);

    }

    if (CAN_MOVE)
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.MovePosition(rigidbody.position + moveDirection * speed * Time.deltaTime);
    }

    Jump(Jump_Force);
    */ //Copy of the main code of the player movement

    void FixedUpdate()
    {
        if (CAN_MOVE)
        {
            Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.MovePosition(rigidbody.position + moveDirection * speed * Time.deltaTime);
        }

    }

    void Update()
    {
        if (CAN_MOVE)
        {
            h = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //Makes player movement: Axis: Values (-1.0f and 1.0f)
            anim.SetFloat("speed", Mathf.Abs(h));
        }
        else
        {
            anim.SetFloat("speed", 0.0f);
        }

        //Make the player walk
        //What we need to make the player walk? 

        //Debug.Log(Mathf.Abs(h));

        if (h != 0 && jump_ == true && CAN_MOVE)
        {
            timerWalk -= Time.deltaTime;
            if (timerWalk < 0.0f)
            {
                walk.Play();
                timerWalk = 0.5f;
            }
        }

        Jump(Jump_Force);


    }

    void Jump(float forceJump)
    {

        //Debug.Log(jump_);
        if (Input.GetKeyDown(KeyCode.Space) && jump_)
        {
            anim.SetBool("isJumping", true);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, forceJump, 0));
            //GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().shakeAmount = 0.6f;
            jump.Play();
            //Debug.Log("Jump");
        }
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    StartCoroutine(timer(0.65f));
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key" && Stage5)
        {
            Destroy(collision.gameObject);
            //Instantiate(particles_por, collision.transform.position - new Vector3(0,1,0), Quaternion.identity);
            key.Play();
        }

        if (collision.gameObject.tag == "Soil")
        {
            //When player falls
            //walk.Play();
            anim.SetBool("isJumping", false);
        }

       

    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Soil")
        {
            jump_ = true;
            //anim.SetBool("isJumping", false);

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



