using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto_Burbuja : MonoBehaviour {

    public Text texto_burbuja;
    public GameObject burbuja;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            burbuja.SetActive(true);
            texto_burbuja.GetComponent<Text>().enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            burbuja.SetActive(false);
            texto_burbuja.GetComponent<Text>().enabled = false;
        }

        //Destroy(this.GetComponent<Texto_Burbuja>());


    }


}
