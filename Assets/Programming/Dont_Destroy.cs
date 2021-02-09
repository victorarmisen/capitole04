using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy : MonoBehaviour {	

	void Update ()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Canvas"));
	}
}
