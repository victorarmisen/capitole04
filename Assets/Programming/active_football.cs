using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_football : MonoBehaviour
{
    private void Update()
    {
        //Debug.Log(Minijuego_Futbol.counterGoals);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
            transform.GetChild(0).gameObject.SetActive(true);
    }
}
