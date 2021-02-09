using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_stats : MonoBehaviour {

    //State bars that the player has to fill to get the victory of the game.
    public float motivation, knowledge, happiness;
    //public Text liveDisplay;
    public Transform initialPos;
    private Quaternion O_Rot;
    private Animator anim;

    public SimpleHealthBar healthBar;
    public SimpleHealthBar healthBarMovitacion;
    public SimpleHealthBar healthBarConocimiento;
    public SimpleHealthBar healthBarFelicidad;

    private float Die_Anim_Time = 5.0f;
    private bool die_already = false;

    private GameObject initial;

    public bool level1, level2, level3, level4, level5, levelBoss;

    public static float live;

    private float tim_Dead = 3.0f;

    //AUDIO DEAD
    public AudioSource dead_fail;

    //AUX:
    private float timer = 2.0f;
    //FAK
    private bool nasty1, nasty2, nasty3;
    public Text die_boss;
    private bool Once = true;
    public Transform initial_pos;

    public Text die_text;


	void Start ()
    {
        live = 100;
        //motivation = 50;
        //knowledge = 50;
        //happiness = 10;
        O_Rot = transform.rotation;
        anim = GetComponent<Animator>();
        nasty1 = true;

    }
	
	void Update ()
    {
        //liveDisplay.text = live.ToString();
        Die();

        healthBar.UpdateBar(live, 100);
        healthBarMovitacion.UpdateBar(motivation, 100);
        healthBarConocimiento.UpdateBar(knowledge, 100);
        healthBarFelicidad.UpdateBar(happiness, 100);

        if(die_already)
        {
            die_text.text = "YOU DIED";
            die_text.enabled = true;
            tim_Dead -= Time.deltaTime;
            if(tim_Dead <= 0)
            {
                Reset_Scene();
            }      
        }

    }

    public void GetDamage(float damage)
    {
        live -= damage;
    }

    void Reset_Scene()
    {
        die_text.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Die()
    {
        if(live <= 0)
        {
            if(level1)
            {
                dead_fail.Play();
                transform.position = initial_pos.position;
                live = 100;
            }              
               
           
            if (level2 || level3 || level4 || level5)       
                live = 100;
                        
            if (level3)
            {
                dead_fail.Play();
                transform.position = initial_pos.position;
                live = 100;


            }
                      
            if (levelBoss)
            {
                //Die_Anim_Time -= Time.deltaTime;

                transform.rotation = O_Rot;

                //anim.SetLayerWeight(2, 100);
                //anim.SetBool("Die", true);
                //anim.Play("Die");
                //anim.SetBool("dead", true);


                if(Once)
                {
                    GetComponent<player_movement>().speed = 0;
                    //die_boss.GetComponent<Text>().enabled = true;
                    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                    //anim.SetBool("dead", true);
                    Destroy(this.GetComponent<player_movement>());
                    Destroy(this.GetComponent<player_attack>());
                    Once = false;
                    die_already = true;
                }

                //if (Die_Anim_Time <= 0)
                //{
                //    die_already = true;
                //}
            }
               

            
        } else
        {
            //anim.SetBool("dead", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy_Projectile")
        {
            GetDamage(20.0f);
            collision.gameObject.AddComponent<Destroy_IT>();
        }
    }

}
