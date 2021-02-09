using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Erizo_Working : MonoBehaviour {

    //Move the IA by the nav mesh

    public NavMeshAgent agent;
    public Transform [] precise_locations;
    private float timer = 5.0f;

    private void Update()
    {
        if(timer < 0.0f)
        {
            agent.SetDestination(precise_locations[Random.Range(0, precise_locations.Length - 1)].position);
            timer = 5.0f;
        } else
        {
            timer -= Time.deltaTime;
        }
   
    }


}
