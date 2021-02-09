using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Active : MonoBehaviour {



	void Update ()
    {
        GameObject[] llaves = GameObject.FindGameObjectsWithTag("Key");

        if (llaves.Length == 0)
        {
            //Activamos explosivo
            //Destruimos este objeto
            //Le añadimos al objeto el script para poder ser explotado
            //explosivo.AddComponent<Explosive_Detonar>();

            //GameObject[] OtherPlayers = GameObject.FindGameObjectsWithTag("OtherPlayer");
            //for (int i = 0; i < OtherPlayers.Length; i++)
            //{
            //    //OtherPlayers[i].AddComponent<Seek>();
            //    //OtherPlayers[i].GetComponent<Seek>().enabled = true;
            //    //OtherPlayers[i].GetComponent<Seek>().speed = 40;
            //    //OtherPlayers[i].GetComponent<Seek>().ActiveKey = true;
            //}

            //Debug.Log("Ha funcionado");
            Destroy(this);


        }


    }
}
