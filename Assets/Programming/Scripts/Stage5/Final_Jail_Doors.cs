using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour {

    private GameObject[] Gates_Down;
    private GameObject[] Gates_Up;

    void Start ()
    {
        Gates_Down = GameObject.FindGameObjectsWithTag("GateDown");
        Gates_Up = GameObject.FindGameObjectsWithTag("GateUp");

        for (int i = 0; i < Gates_Down.Length; i++)
        {
            Gates_Down[i].AddComponent<OpenGate>().enabled = true;
        }
        for (int i = 0; i < Gates_Up.Length; i++)
        {
            Gates_Up[i].AddComponent<OpenGate>().enabled = true;
        }

    }
	

	void Update () {
		
	}
}
