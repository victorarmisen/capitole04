using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Minijuego : MonoBehaviour
{
    private Vector3 originalPos, reachPos, reachPosV;
    public float timer, timer2;
    public bool vertical = false;
    public int direction;
    public float actual_velocity;

    void Start()
    {
        originalPos = transform.position;
        reachPos = transform.position + Vector3.right * direction * 30.0f;
        reachPosV = transform.position + Vector3.up * direction * 30.0f;
        timer = 0.4f;
        timer2 = 0.4f;
        actual_velocity = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0.0f)
        {
            if(vertical)
            {
                transform.position = Vector3.MoveTowards(originalPos, reachPosV, 1000);
                GetComponent<Image>().color = Color.magenta;
            }
            else
            {
                transform.position = Vector3.MoveTowards(originalPos, reachPos, 1000);
                GetComponent<Image>().color = Color.magenta;
            }

            timer2 -= Time.deltaTime;

            if (timer2 < 0.0f)
            {
                if (vertical)
                {
                    transform.position = Vector3.MoveTowards(reachPos, originalPos, 1000);
                    GetComponent<Image>().color = Color.red;
                }
                    
                else
                {
                    transform.position = Vector3.MoveTowards(reachPosV, originalPos, 1000);
                    GetComponent<Image>().color = Color.red;
                }
                    

                timer = actual_velocity;
                timer2 = actual_velocity;
            }            
        }


    }

}
