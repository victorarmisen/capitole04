using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Activity : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim_player;
    private float time = 0.2f;
    private float time2 = 2.7f;
    private bool anim_bool = false;

    void Start()
    {
        anim_player.SetBool("Start_A1", true);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time < 0.0f && anim_bool == false)
        {
            anim_player.SetBool("Start_A1", false);
            anim_bool = true;
            //Destroy(this);
        }

        time2 -= Time.deltaTime;
        player_movement.CAN_MOVE = false;
        if (time2 < 0.0f)
        {
            player_movement.CAN_MOVE = true;
            Destroy(this);
        }



    }


}
