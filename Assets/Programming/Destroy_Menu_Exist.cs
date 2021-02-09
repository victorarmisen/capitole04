using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Menu_Exist : MonoBehaviour {

	void Update ()
    {
		if(GameObject.Find("PAUSE_GAME"))
        {
            Destroy(GameObject.Find("PAUSE_GAME"));
        }
	}
}
