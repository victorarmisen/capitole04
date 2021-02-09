using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Game_Buttons : MonoBehaviour {
    public bool Stage4;
    public GameObject minijuego;
    public Text marcador;
    public void Reiniciar_Nivel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Stage4)
        {
            Minijuego_Futbol.begin_futbol = false;
            minijuego.SetActive(false);
            marcador.text = "";
            Minijuego_Futbol.counterGoals = 0;
        }
         
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Reiniciar_Nivel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Back_Menu();
        }
    }
    public void Back_Menu()
    {
        SceneManager.LoadScene(0);
    }

}
