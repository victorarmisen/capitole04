using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_win_mi : MonoBehaviour {

    public GameObject mini_condition;

	void Update ()
    {
		if(mini_condition.GetComponent<Minigame_Pc>().Win)
        {
            //Se destruye la PUERTA IT'S OKAY
            Destroy(this.gameObject); 
        }
	}
}
