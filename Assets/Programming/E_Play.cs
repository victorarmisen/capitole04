using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E_Play : MonoBehaviour
{
    public bool Special = false;
    public AudioSource click;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E))
        {
            if(!Special)
            {
                click.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Destroy(this);
            }
            else
            {
                click.Play();
                SceneManager.LoadScene(0);
                Destroy(this);
            }
            
        }
	}
}
