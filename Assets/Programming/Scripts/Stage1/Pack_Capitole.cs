using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack_Capitole : MonoBehaviour {

    //Simple code to give the player the capitole starter pack
    //When enemies are eliminated, the last enemy respawn the pack.

    public GameObject spawn_Text;
    public string text_;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            //GameObject text = GameObject.FindGameObjectWithTag("TextAction");

            //text.GetComponent<Text_Pokemon>().textToShow = text_;

            //Instantiate(text, this.gameObject.transform.position, Quaternion.identity);


        }
    }





}
