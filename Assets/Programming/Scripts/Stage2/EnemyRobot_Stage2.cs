using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobot : MonoBehaviour {

    public GameObject bala;
    public float force_impulse;
    //public Transform pos_bala;
    private float timer = 3.0f;
    private GameObject player;
    private Transform add;
    private Transform aux;
    private GameObject empty;
    public GameObject particles_shoot;

    private void Start()
    {
        empty = new GameObject();

        aux = empty.transform;

        add = empty.transform;
        //add.rotation = new Quaternion(0, 0.35f, 0, 1.0f);


    }

    void Update ()
    {
        //pos_bala.transform.position = gameObject.transform.forward;

        player = GameObject.FindGameObjectWithTag("Player");
        
        if (Vector3.Distance(player.transform.position, transform.position) < 10.0f)
        {
            timer -= Time.deltaTime;

            if (timer < 0.0f)
            {
                StartCoroutine(Shoot_Enemy(2.0f, player));
                //
                timer = 3.0f;
            }
        }



        transform.LookAt(player.transform.position + new Vector3(0,1,0));

    }

    private IEnumerator Shoot_Enemy(float seconds_shoot, GameObject player)
    {
        Instantiate(particles_shoot, transform.position, Quaternion.identity);
        GameObject obj = Instantiate(bala, transform.position + new Vector3(0,0.35f,0), Quaternion.identity) as GameObject;
        obj.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * force_impulse, ForceMode.Impulse);
        yield return new WaitForSeconds(seconds_shoot);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
    }

}
