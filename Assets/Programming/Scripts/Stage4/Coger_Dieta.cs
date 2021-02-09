using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coger_Dieta : MonoBehaviour {

    private float originalSpeed = 0.0f;
    public bool activeTimer = false;
    private float timer = 3.0f;
    public static float addition;
    public GameObject Pick_Billete;

    void Start()
    {
        originalSpeed = gameObject.GetComponent<Patinete>().speed;
    }

    void Update()
    {
        //Debug.Log(activeTimer);

        if (activeTimer)
        {
            timer -= Time.deltaTime;

            if (timer >= 0.0f)
            {
                addition = 4;
                Debug.Log(gameObject.GetComponent<Patinete>().speed);
            }
            else
            {
                activeTimer = false;
                timer = 3.0f;
                addition = 0.0f;
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "DietObject")
        {
            //gameObject.GetComponent<State_Player>().Tired = false;
            //gameObject.GetComponent<player_stats>().happiness += 5;
            //gameObject.GetComponent<Patinete>().speed++;
            //Routine to add the scooter bigger speed by a time
            activeTimer = true;
            ////Instantiate(Pick_Billete, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            



        }
    }

}
