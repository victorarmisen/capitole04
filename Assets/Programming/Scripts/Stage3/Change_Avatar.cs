using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Avatar : MonoBehaviour
{
    public Sprite sprite_Avatar;
    public GameObject player;
    public GameObject juego_Minijuego;

    public void Change()
    {
        player.GetComponent<Image>().sprite = sprite_Avatar;
        juego_Minijuego.GetComponent<PC_Stage3>().MINIGAME = true;
        Player_Minigame.player_move = true;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Buttons");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }





}
