using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Player : MonoBehaviour {

    public bool Tired = true;
    private float speedTired = 0.0f;
    private float speedNotTired = 0.0f;
    public bool Stage2;
    private Animator anim;

    void Start()
    {
        speedTired = GetComponent<player_movement>().speed / 2;
        speedNotTired = GetComponent<player_movement>().speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //if (Tired)
        //{
        //    GetComponent<player_movement>().speed = speedTired;
        //    anim.SetLayerWeight(0, 100);
        //    anim.SetLayerWeight(1, 0);
        //}
        //else
        //{
        //    GetComponent<player_movement>().speed = speedNotTired;
        //    anim.SetLayerWeight(1, 100);
        //}

    }
}