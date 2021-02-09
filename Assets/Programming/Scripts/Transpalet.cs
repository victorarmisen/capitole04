using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transpalet : MonoBehaviour {

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(Input.GetMouseButton(0) && col.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                col.gameObject.GetComponent<Animator>().Play("Empujar");
            }
        }
    }

}
