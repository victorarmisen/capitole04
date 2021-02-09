using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Quieto : MonoBehaviour {

    private float timer = 2.65f;

    void Start()
    {
        if(this.gameObject.GetComponent<Enemy_Stats_Stage1>() != null)
            this.gameObject.GetComponent<Enemy_Stage1>().speed = 0;
    }

	void Update ()
    {
        timer -= Time.deltaTime;
        
        if(timer < 0.0f)
        {
            if (this.gameObject.GetComponent<Enemy_Stats_Stage1>() != null)
                this.gameObject.GetComponent<Enemy_Stage1>().speed = 1.1f;
            Destroy(this);
        }

	}
}
