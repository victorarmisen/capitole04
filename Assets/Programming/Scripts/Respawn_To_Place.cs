using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_To_Place : MonoBehaviour {

    public Transform newPlace;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.position = newPlace.position;
        }
    }


}
