using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTired : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<State_Player>().Tired = true;
            Destroy(this);
        }
    }

}
