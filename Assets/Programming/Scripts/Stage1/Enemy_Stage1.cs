using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stage1 : MonoBehaviour {

    public Transform start_position;
    public Transform patrolA;
    public Transform patrolB;
    public float speed = 1.1f;
    private int rt = 1;
    public LayerMask enemy;
    public bool animal;
    private bool toChangeDir = false;

    private float timerMonster = 0.1f;
    private float timerAttack = 1.0f;

    //Audio
    public AudioSource monster;
    private Animator anim;
    private GameObject player;

    //Tipos: proyectos aburridos, monotonia, ganas de cambio
    public AudioSource attack_monster;

	void Start ()
    {
        gameObject.transform.position = start_position.position;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

	void Update ()
    {	     
        if(!animal)
        {
            if (this.gameObject != null)
            {
                //monster.playOnAwake = true;
                //monster.transform.position = transform.position;
                //monster.Play();
            }

            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 5.0f)
            {

                timerMonster -= Time.deltaTime;

                if (timerMonster < 0.0f)
                {
                    monster.Play();
                    timerMonster = 5.0f;
                }

            }
        }

        if(!toChangeDir)
        {
            if (rt == -1)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }

            if (rt == 1)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
        else
        {
            timerAttack -= Time.deltaTime;

            transform.LookAt(player.transform, Vector3.up);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if (timerAttack < 0.0f)
            {
                toChangeDir = false;
            }
        }

        //Debug.Log("RT: " + rt);
        if (transform.position.x <= patrolA.position.x)
        {
            rt = -1;      
        }
         //Vector3.Distance(transform.position, patrolB.position) < 1
        if (transform.position.x >= patrolB.position.x)
        {
            rt = 1;
        }

        if(!animal)
        {
            if (GetComponent<Enemy_Stats_Stage1>().enemy_life > 0)
                transform.position -= new Vector3((rt * speed) * Time.deltaTime, 0, 0);
        } else
        {
            transform.position -= 
                new Vector3((rt * speed) * Time.deltaTime, 0, 0);
        }
       
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
        }

        if (collision.gameObject.tag == "Player")
        {
            toChangeDir = true;
            timerAttack = 1.0f;
            gameObject.AddComponent<Enemigo_Quieto>();
            anim.SetBool("Attack", true);
            attack_monster.Play();
            player_stats.live -= 10;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", false);
        }
    }

  

}
