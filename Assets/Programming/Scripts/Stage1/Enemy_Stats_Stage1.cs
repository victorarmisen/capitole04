using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats_Stage1 : MonoBehaviour {

    public int enemy_life;
    public Animator anim;
    private GameObject _player;
    public bool level2;
    public GameObject particles_die;
    public GameObject capitole_pack;
    public bool Enemy3 = false;
    public GameObject die_particles_explosion;
    public bool isDead = false;
    private float timer2 = 2.0f;
    //public GameObject nombre_texto;

    void Start ()
    {
        //enemy_life = 20;
        anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.enabled = false;
    }

    void Update ()
    {

        if(!isDead)
            anim.SetBool("Walking", true);


        if (enemy_life == 0)
        {
        
            Physics.IgnoreCollision(GetComponent<Collider>(), _player.GetComponent<Collider>());

            ////Explosion enemy
            //Instantiate(particles_die, transform.position, particles_die.transform.rotation);        

            //GameObject[] E_Alive = GameObject.FindGameObjectsWithTag("Enemy");

            //if (E_Alive.Length == 1)
            //{
            //    Instantiate(capitole_pack, this.gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                
            //    Debug.Log("All enemies dead");
            //}

            Die_Enemy();

 
        }
        

    }


    void Die_Enemy()
    {

        if(Enemy3)
        {
            isDead = true;
            anim.SetBool("Die", true);
            anim.SetBool("Walking", false);

            Instantiate(die_particles_explosion, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            Destroy(this.gameObject);
         
        } else
        {

            anim.SetTrigger("Hit_Enemy");
            anim.SetTrigger("Die");
        }

        GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
        //Destroy(nombre_texto.gameObject);
        Destroy(this);
        Destroy(this.GetComponent<Enemy_Stage1>());
        Destroy(this.GetComponent<Enemy_Stats_Stage1>());
    }

}
