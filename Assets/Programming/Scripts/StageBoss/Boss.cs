using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {


    public Animator anim;
    private float timerAttack = 8.0f;
    private float makeDamage = 1.5f;
    private float timerChangePos = 10.0f;
    public GameObject attack, attack2;
    public Transform aparicion_final;

    public Transform pos1, pos2;

    public SimpleHealthBar healthBoss;

    public float liveBoss;
    public GameObject musica_boss;
    private bool once_final = true;

    private bool isDead = false, isAttacking = false;

    private float timerMonster = 0.1f;

    //Audio
    public AudioSource monster, die_boss_sound, falling;

    public GameObject diamante_Final;

    public AudioSource attack_sound_explote;

    Vector3 direc_ostia;

    public GameObject happy_music;

    public GameObject hehe;

    private bool Once_Attack = true;

    public BoxCollider boxAtaque;


    //Bala:
    public GameObject bala_Lava;
    public Transform shootSpawn;

    int directionBoss = 1;

    void Start ()
    {
        //anim = GetComponent<Animator>();
        if (!isDead)
            anim.Play("Idle");
        if(!isDead)
            InvokeRepeating("Attack", 2.0f, 2.0f);
        musica_boss.GetComponent<AudioSource>().Play();
        liveBoss = 100;

    }
	
    void Attack()
    {

        if(anim.GetBool("Attack"))
        {
            anim.Play("Attack");
        } 

        if (!isDead)
        {
            //BoxCollider[] boxes2 = gameObject.GetComponentsInChildren<BoxCollider>();

            timerAttack -= Time.deltaTime;
           
            isAttacking = false;
            Once_Attack = true;
            if (timerAttack <= 3.0f)
            {
                anim.SetBool("Attack", true);                              
            }               
            if (timerAttack <= 0)
            {
                makeDamage -= Time.deltaTime;
                if(makeDamage <= 0)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                    //Particles Attack
                    //GameObject particles_s = Instantiate(attack, transform.position + transform.forward * 5.0f, transform.rotation);
                    attack_sound_explote.Play();
                    //boxes2[0].enabled = true;
                    //boxes2[1].enabled = true;
                    //boxAtaque.enabled = true;
                    //Throw attack:
                    GameObject obj = Instantiate(bala_Lava, shootSpawn.position, new Quaternion(0, 0, 0, 1));
                   
                    //obj.transform.eulerAngles = Vector3.up * 90.0f;
                    if(directionBoss == 1)
                    {
                        //Make physics throw attack:
                        int Random_ = Random.Range(0, 2);
                        if (Random_ == 0)
                        {
                            obj.GetComponent<Rigidbody>().AddForce(new Vector3(-5, 2, 0), ForceMode.Impulse);
                        }
                        else
                        {
                            obj.GetComponent<Rigidbody>().AddForce(new Vector3(-2, 2, 0), ForceMode.Impulse);
                        }
                        

                    } 
                    if(directionBoss == -1)
                    {
                        //Make physics throw attack:
                        int Random_ = Random.Range(0, 2);
                        if (Random_ == 0)
                        {
                            obj.GetComponent<Rigidbody>().AddForce(new Vector3(5, 2, 0), ForceMode.Impulse);
                        }
                        else
                        {
                            obj.GetComponent<Rigidbody>().AddForce(new Vector3(2, 2, 0), ForceMode.Impulse);
                        }


                    }

                    isAttacking = true;
                    timerAttack = 8.0f;
                    if (Once_Attack)
                    {
                        //GameObject particles_a = Instantiate(attack2, transform.position + Vector3.up * 1.0f + transform.forward * 5.0f, Quaternion.identity);
                        //particles_a.transform.SetParent(this.gameObject.transform);
                       // Destroy(particles_a, 5.0f);
                        Once_Attack = false;
                    }
                    makeDamage = 1.5f;
                }
            }
            else
            {
                //boxes2[1].enabled = false;
                //boxAtaque.enabled = false;
                anim.SetBool("Attack", false);
            }
        }
    }

    void ChangePos()
    {

        if (!isDead)
        {
            timerChangePos -= Time.deltaTime;

            if (timerChangePos < 0)
            {
                float distance1 = Vector3.Distance(transform.position, pos1.position);
                float distance2 = Vector3.Distance(transform.position, pos2.position);

                if (distance1 > distance2)
                {
                    transform.position = pos1.position;
                    anim.SetBool("Idle", false);
                    anim.Play("Jump");
                    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                    transform.eulerAngles = Vector3.up * 90;
                    //GameObject flame_wings = Instantiate(attack, transform.position, Quaternion.identity);
                    //Destroy(flame_wings.gameObject, 3.0f);
                    direc_ostia = -Vector3.left;
                    directionBoss = -1;
                    attack_sound_explote.Play();
                }
                
                if (distance2 > distance1)
                {
                    transform.position = pos2.position;
                    anim.SetBool("Idle", false);
                    anim.Play("Jump");
                    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                    transform.eulerAngles = Vector3.up * -90;
                    //GameObject flame_wings = Instantiate(attack, transform.position, Quaternion.identity);
                    //Destroy(flame_wings.gameObject, 3.0f);
                    direc_ostia = Vector3.left;
                    directionBoss = 1;
                    attack_sound_explote.Play();
                }
                timerChangePos = 10.0f;
            }
        }

        

    }

    void SuperPower()
    {
        if(liveBoss <= 75 && once_final)
        {
            die_boss_sound.Play();
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            GameObject.FindGameObjectWithTag("Player").AddComponent<SuperPower>();
            GameObject.FindGameObjectWithTag("Player").GetComponent<player_attack>().SuperPowerBoss
                = true;
            Instantiate(attack, GameObject.FindGameObjectWithTag("Player").transform.position, attack.transform.rotation);
            once_final = false;
        }
    }

    void Die()
    {
        if(liveBoss <= 0)
        {
            anim.Play("Die");
            anim.SetBool("isDead", true);
            die_boss_sound.Play();
            falling.Play();
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            diamante_Final.gameObject.transform.position = aparicion_final.position;

            Destroy(musica_boss);
            happy_music.SetActive(true);
            //hehe.SetActive(true); ///CUIDADO

            Destroy(this);
            Destroy(this.gameObject.GetComponent<Animator>(), 3.7f);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            GameObject.FindGameObjectWithTag("Player").transform.localScale -= new Vector3(1.5f, 1.5f, 1.5f);
            Instantiate(attack, transform.position, Quaternion.identity);
            //Change scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

	void Update ()
    {
        Die();
        SuperPower();
        ChangePos();
        Attack();

        timerMonster -= Time.deltaTime;

        if (timerMonster < 0.0f)
        {
            monster.Play();
            timerMonster = 20.0f; //Hacer un random
        }

        if (!isDead)
            anim.SetBool("Idle", true);

        //Debug.Log(liveBoss);

        healthBoss.UpdateBar(liveBoss, 100);
    }

    //void OnTriggerStay(Collider col)
    //{
    //    if(col.gameObject.tag == "Player" && isAttacking)
    //    {
    //        //col.gameObject.GetComponent<Rigidbody>().AddForce(direc_ostia * 20.0f, ForceMode.Impulse);
    //        player_stats.live -= 60;     
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //player_stats.live -= 60;
        }
    }



}
