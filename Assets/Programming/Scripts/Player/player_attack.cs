using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour {

    public BoxCollider hitBox;
    private Animator anim;
    //public GameObject platform;
    public AudioSource punch_Sound;
    //public AudioSource activate;
    private bool available_attack = false;
    private float onAttack = 1.65f;
    public AudioSource end_sound;
    public bool SuperPowerBoss;

    private void Start()
    {
        hitBox.enabled = false;
        anim = GetComponent<Animator>();
        end_sound = GameObject.FindGameObjectWithTag("End_Punch").gameObject.GetComponent<AudioSource>();
    }

    IEnumerator timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetBool("punch", false);
        //GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
        //end_sound.Play();
        player_movement.CAN_MOVE = true;
    }

    /*  
    if (!available_attack)
        onAttack -= Time.deltaTime;

    if (onAttack < 0.0f)
    {
        available_attack = true;
    }
    //Input.GetKeyDown(KeyCode.F)

    if (Input.GetKeyDown(KeyCode.F) && available_attack)
    {
        anim.SetLayerWeight(1, 100);
        anim.Play("Punch");
        punch_Sound.Play();
        hitBox.enabled = true;
        GetComponent<player_movement>().speed = 0;
        GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
        //Instantiate(par, this.transform.position, this.transform.rotation);
        available_attack = false;
        onAttack = 1.65f;
    }
    else if (Input.GetKeyUp(KeyCode.F) && !available_attack)
    {
        hitBox.enabled = false;
        StartCoroutine(timer(0.4f));

        GetComponent<player_movement>().speed = 4;
    }

    platform = GameObject.FindGameObjectWithTag("Plataforma");  
    */ //Code sample to attack
    
    void Update()
    {
        if (!available_attack)
            onAttack -= Time.deltaTime;

        if (onAttack < 0.0f)
        {
            available_attack = true;
        }


        if (Input.GetKeyDown(KeyCode.F) && available_attack)
        {
            anim.SetBool("punch", true);
            punch_Sound.Play();
            hitBox.enabled = true;
            player_movement.CAN_MOVE = false;
            //Instantiate(par, this.transform.position, this.transform.rotation);
            available_attack = false;
            onAttack = 1.65f;
        }
        else if (Input.GetKeyUp(KeyCode.F) /*&& !available_attack*/)
        {
            hitBox.enabled = false;
            StartCoroutine(timer(1.2f));
            GetComponent<player_movement>().speed = 4;

        }

        //platform = GameObject.FindGameObjectWithTag("Plataforma");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy") //Posible Error
        {
            if(other.gameObject.GetComponent<Enemy_Stats_Stage1>() != null)
            {
                other.gameObject.GetComponent<Enemy_Stats_Stage1>().enemy_life -= 10;
                other.GetComponent<Enemy_Stats_Stage1>().anim.SetTrigger("Hit_Enemy");
            }

            other.gameObject.AddComponent<Enemigo_Quieto>();

        }
        if (other.gameObject.tag == "Boss")
        {
            if(!SuperPowerBoss)
                other.gameObject.GetComponent<Boss>().liveBoss -= 5;
            else
                other.gameObject.GetComponent<Boss>().liveBoss -= 15;
            //other.GetComponent<Enemy_Stats_Stage1>().anim.SetTrigger("Hit_Enemy");
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "ButtonOpen" && Input.GetKeyDown(KeyCode.E))
    //    {
    //        Debug.Log("ButtonOpen Activated");
    //        platform.AddComponent<MovePlatform>();
    //        platform.GetComponent<MovePlatform>().player = this.gameObject;
    //        Destroy(other.gameObject);
    //        activate.Play();
    //        //Seek.ActiveKey = true;

    //    }

    //    if (other.gameObject.tag == "ButtonDown" && Input.GetKeyDown(KeyCode.E))
    //    {
    //        Debug.Log("ButtonOpen Activated");
    //        platform.AddComponent<MoveDown>();
    //        platform.GetComponent<MoveDown>().player = this.gameObject;
    //        Destroy(other.gameObject);
    //        activate.Play();
    //        //Seek.ActiveKey = true;

    //    }

    //}



}
