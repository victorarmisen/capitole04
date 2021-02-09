using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Minigame : MonoBehaviour {

    public float speed;
    //public Transform Initial_Pos_Minigame;
    public static bool player_move;
    private Vector3 init_pos;
    public AudioSource congrats;
    public GameObject complication;
    private GameObject juego_Minjuego;
    public GameObject mini_condition;

    void Start()
    {
        init_pos = this.transform.position;
        juego_Minjuego = GameObject.FindGameObjectWithTag("Minijuego_PC");
    }

    void FixedUpdate()
    {
        if (juego_Minjuego.GetComponent<PC_Stage3>().MINIGAME && player_move)
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * Time.deltaTime;

            //transform.Translate(h * speed, v, 0.0f);
            Rigidbody body = GetComponent<Rigidbody>();
            body.MovePosition(body.position + new Vector3(h * speed, v * speed, 0.0f));
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Reach")
        {
            //Fin
            mini_condition.GetComponent<Minigame_Pc>().Win = true;
            congrats.Play();
            Debug.Log("HELLO");
        }

        if (col.gameObject.tag == "Enemigo_Minijuego")
        {
            //Fin
            Die_In_Minigame();
            complication.GetComponent<Minigame_Complication>().counter++;
            //Debug.Log("Die");
        }
    }

    public void Die_In_Minigame()
    {
        //Reset position
        this.transform.position = init_pos;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
