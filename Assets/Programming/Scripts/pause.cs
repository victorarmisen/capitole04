using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {

    private float[] time_scale = new float[2];
    private int counter = 0;
    public static bool isPaused = false;
    public Image pauseIcon;
    public GameObject buttonReiniciar, /*buttonmenu,*/ buttonControls, controles;

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        //controles.gameObject.SetActive(false);
    }

	void Update ()
    {

        //Debug.Log(isPaused);

		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                Time.timeScale = 0;
                //pauseIcon.enabled = true;
                buttonReiniciar.gameObject.SetActive(true);
                //buttonMenu.gameObject.SetActive(true);
                buttonControls.gameObject.SetActive(true);                
                isPaused = true;               
            }
            else
            {
                Time.timeScale = 1;
                //pauseIcon.enabled = false;
                buttonReiniciar.gameObject.SetActive(false);
                //buttonMenu.gameObject.SetActive(false);
                buttonControls.gameObject.SetActive(false);
                controles.gameObject.SetActive(false);
                isPaused = false;
            }
    
        }

        

    }
}
