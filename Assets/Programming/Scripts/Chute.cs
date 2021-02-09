using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour {

    private GameObject chutador;
    private GameObject punto_chute, target;
    float time1 = 0.0f;
    public Vector3 posI, posFinal;
    public static bool CHUTE = false;
    public GameObject ball;
    public static bool ENTRADA = false;
    private Animator anim;

    public AudioSource chute;

    private bool cooldown_chute = false;
    private float t_cool = 1.5f;

    void Start()
    {
        chutador = GameObject.FindGameObjectWithTag("Chutador");    
        punto_chute = GameObject.Find("Punto_de_Chute");
        target = GameObject.Find("Target");
        posI = chutador.transform.position;
        posFinal = punto_chute.transform.position;
        anim = GetComponent<Animator>();
    }

	void Update ()
    {

        if(ENTRADA)
        {
            float step = 3.0f * Time.deltaTime;
            anim.Play("Walk");
            transform.position = Vector3.MoveTowards(transform.position, punto_chute.transform.position, step);           
            //Debug.Log(ENTRADA);

        }
     

        if (Vector3.Distance(transform.position, posFinal) < 3.0f && ENTRADA)
        {
            //anim.SetBool("Chute", true);
            anim.Play("Chute");
            chute.Play();



        } else
        {
            anim.Play("Walk");
        }

        if (Vector3.Distance(transform.position, posFinal) < 2.0f && ENTRADA)
        {

            ball.AddComponent<Rigidbody>();
            ball.GetComponent<Rigidbody>().velocity = BallisticVel(target.transform, 10.0f);
            cooldown_chute = true;

            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();

            //if (ball.GetComponent<Rigidbody>().velocity != Vector3.zero)
            //{
            //    CHUTE = true;
            //}
            //else
            //{
            //    CHUTE = false;
            //}

            CHUTE = true;
           
            ENTRADA = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !cooldown_chute)
        {
            ENTRADA = true;             
        }

        if(cooldown_chute)
        {
            t_cool -= Time.deltaTime;

            if(t_cool < 0.0f)
            {
                cooldown_chute = false;
                t_cool = 1.5f;
            }
        }
        

    }

    private Vector3 BallisticVel(Transform _target, float _angle)
    {
        Vector3 _dir = _target.position - this.transform.position;  // get target direction
        float _h = _dir.y;  // get height difference
        _dir.y = 0f;  // retain only the horizontal direction
        float _distance = _dir.magnitude;  // get horizontal distance
        float _newAngle = _angle * Mathf.Deg2Rad;  // convert angle to radians
        _dir.y = _distance * Mathf.Tan(_newAngle);  // set dir to the elevation angle
        _distance += _h / Mathf.Tan(_newAngle);  // correct for small height differences
        // calculate the velocity magnitude
        float _vel = Mathf.Sqrt(_distance * Physics.gravity.magnitude / Mathf.Sin(2 * _newAngle));
        return _vel * _dir.normalized;
    }

}
