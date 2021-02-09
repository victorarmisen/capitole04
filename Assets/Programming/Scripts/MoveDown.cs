using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {

    private Transform original_pose;
    private Transform position_back;
    private Transform position_up;
    public GameObject player;
    float timer2 = 0.0f;
    float timer3 = 0.0f;
    float timer4 = 0.0f;
    float timer5 = 0.0f;
    private bool check = false;
    private bool check2 = false;

    private void Start()
    {
        original_pose = GameObject.FindGameObjectWithTag("original_pose").gameObject.transform;
        position_back = GameObject.FindGameObjectWithTag("position_back").gameObject.transform;
        position_up = GameObject.FindGameObjectWithTag("position_up").gameObject.transform;
    }

    void Update()
    {

        

        if (Vector3.Distance(transform.position, position_back.position) >= 3)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(position_back.position.x,
            position_back.transform.position.y, position_back.position.z), timer2);
            timer2 = timer2 + Time.deltaTime;
        }
        else
        {
            check = true;
        }

        if (check)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(original_pose.position.x,
              original_pose.transform.position.y, original_pose.position.z), timer3);
            timer3 = timer3 + Time.deltaTime;

           

        }


        if (Vector3.Distance(player.transform.position, position_back.position) >= 3)
        {
            player.transform.position = Vector3.Slerp(player.transform.position, new Vector3(position_back.position.x,
            position_back.transform.position.y, position_back.position.z), timer4);
            timer4 = timer4 + Time.deltaTime;
        }
        else
        {
            check2 = true;
        }

        if (check2)
        {
            player.transform.position = Vector3.Slerp(player.transform.position, new Vector3(original_pose.position.x,
              original_pose.transform.position.y, original_pose.position.z), timer5);
            timer5 = timer5 + Time.deltaTime;

            if (Vector3.Distance(player.transform.position, original_pose.transform.position) <= 1.5f)
            {
                Destroy(this);
            }


        }
    }


    IEnumerator timer(float s)
    {
        yield return new WaitForSeconds(s);
    }
}
