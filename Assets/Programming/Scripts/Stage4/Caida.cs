using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //Instanciamos particulas que se rompen
        }
    }

}
