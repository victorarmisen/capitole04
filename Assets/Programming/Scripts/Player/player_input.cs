using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour {

    public Camera cam;
    private bool ZOOM = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TextAction")
        {
            other.gameObject.SetActive(true);
            if(other.gameObject.GetComponent<TextPokemon>() != null)
            {
                other.gameObject.GetComponent<TextPokemon>().enabled = true;
                ZOOM = other.gameObject.GetComponent<TextPokemon>().Zoomed;
            }
            
            StartCoroutine(StopPlayer(10.0f));
        }

    }

    IEnumerator StopPlayer(float s)
    {
        GetComponent<player_movement>().speed = 0;
        if (ZOOM)
        {
            cam.gameObject.AddComponent<Zoom_In_Stage2>();
            cam.gameObject.GetComponent<Zoom_In_Stage2>().end_pos = cam.transform.position + new Vector3(0, 0, 3);
            cam.gameObject.GetComponent<Camera_Follow>().enabled = false;
        }
        
        //this.gameObject.GetComponent<Change_Dir>().enabled = false;
        this.gameObject.GetComponent<player_movement>().PlayerMove = false;
        yield return new WaitForSeconds(s);
        if (ZOOM)
        {
            Destroy(gameObject.GetComponent<Zoom_In_Stage2>());
            cam.gameObject.GetComponent<Camera_Follow>().enabled = true;
        }
        this.gameObject.GetComponent<player_movement>().PlayerMove = true;
        this.gameObject.GetComponent<Change_Dir>().enabled = true;

        GetComponent<player_movement>().speed = 4;


    }


}
