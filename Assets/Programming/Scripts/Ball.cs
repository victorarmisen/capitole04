using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    private Vector3 initialPos;
    public GameObject posicion_portero;
    public GameObject portero;

    [SerializeField]
    private Transform _target;
    public AudioSource goal, fail;

    float _forceApplied = 10.0f;
    private float col_port = 2.0f;
    bool colision_portero = false;

    private bool goal_text = false, fail_text = false;
    public Text goalText, failText;
    private float t_goal = 2.0f, t_fail = 2.0f;

    void Start()
    {
        initialPos = this.transform.position;
        posicion_portero.transform.position = portero.transform.position;
    }

    private void FixedUpdate()
    {
        if(colision_portero)
        {
            col_port -= Time.deltaTime;

            if (col_port < 0.0f)
            {
                Destroy(this.GetComponent<Rigidbody>());
                this.transform.position = initialPos;
                //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                GameObject chutador = GameObject.FindGameObjectWithTag("Chutador");

                chutador.transform.position = chutador.GetComponent<Chute>().posI;
                chutador.GetComponent<Animator>().Rebind();

                portero.transform.position =
                posicion_portero.transform.position;
                portero.GetComponent<Animator>().Rebind();
                portero.GetComponent<Rigidbody>().velocity = Vector3.zero;
                colision_portero = false;
            }
        }

        if (transform.position.y < 0.0f)
        {
            //Destroy(this.GetComponent<Rigidbody>());
            this.transform.position = initialPos;
            //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if(goal_text)
        {
            goalText.enabled = true;
            t_goal -= Time.deltaTime;
            if(t_goal <= 0)
            {
                goalText.enabled = false;
                t_goal = 2.0f;
                goal_text = false;
              
            }       
        }

        if(fail_text)
        {
            failText.enabled = true;
            t_fail -= Time.deltaTime;
            if (t_fail <= 0)
            {
                failText.enabled = false;
                t_fail = 2.0f;
                fail_text = false;
                
            }           
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "GOAL")
        {
            Minijuego_Futbol.counterGoals++;

            //Sonido GOAL:
            goal.Play();

            GameObject chutador = GameObject.FindGameObjectWithTag("Chutador");

            chutador.transform.position = chutador.GetComponent<Chute>().posI;

            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.position = initialPos;
            Destroy(this.GetComponent<Rigidbody>());
            
            portero.transform.position = posicion_portero.transform.position;
            
            chutador.GetComponent<Animator>().Rebind();

            portero.GetComponent<Animator>().Rebind();
            portero.GetComponent<Rigidbody>().velocity = Vector3.zero;

            goal_text = true;

            ////Solve error
            //Instantiate(this.gameObject, initialPos, Quaternion.identity);
            //Destroy(this.gameObject);
 
        }

        if (col.gameObject.tag == "FAIL")
        {

            GameObject chutador = GameObject.FindGameObjectWithTag("Chutador");

            chutador.transform.position = chutador.GetComponent<Chute>().posI;

            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.position = initialPos;
            Destroy(this.GetComponent<Rigidbody>());
     

            //Sonido FAIL
            fail.Play();

   
            chutador.GetComponent<Animator>().Rebind();

            portero.transform.position =
            posicion_portero.transform.position;
            portero.GetComponent<Animator>().Rebind();
            portero.GetComponent<Rigidbody>().velocity = Vector3.zero;

            fail_text = true;

            ////Solve error
            //Instantiate(this.gameObject, initialPos, Quaternion.identity);
            //Destroy(this.gameObject);

        }

        if(col.gameObject.tag == "Portero")
        {
            fail.Play();
            colision_portero = true;
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
