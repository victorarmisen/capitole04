using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection_Minigame : MonoBehaviour {

    public Sprite [] sprite_Avatar;
    public GameObject player;
    private GameObject juego_Minjuego;


    private void Start()
    {
        juego_Minjuego = GameObject.FindGameObjectWithTag("Minijuego_PC");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAvatar(sprite_Avatar[0]);
            //Destroy(this);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAvatar(sprite_Avatar[1]);
            //Destroy(this);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeAvatar(sprite_Avatar[2]);
            //Destroy(this);
        }
    }

    void ChangeAvatar(Sprite sprite_Avatar)
    {
        player.GetComponent<Image>().sprite = sprite_Avatar;
        juego_Minjuego.GetComponent<PC_Stage3>().MINIGAME = true;
        Player_Minigame.player_move = true;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Buttons");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
