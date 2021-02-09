using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class MoveRedTarget : MonoBehaviour
{



    public float speed;

    public GameObject RedTarget;

    private float last_position;



    void Update()

    {

        if (Minijuego_Futbol.begin_futbol)

        {

            float h = Input.GetAxis("Horizontal") * Time.deltaTime;

            //Debug.Log(this.transform.position.x);

            if (this.transform.position.x >= 203.76 - 4.5f && this.transform.position.x <= 203.76 + 5)

            {

                this.transform.Translate(h * speed, 0, 0);

                last_position = this.transform.position.x;

                RedTarget.transform.position = this.transform.position;

            }

            else if (this.transform.position.x >= 203.76 + 5)

            {

                //this.transform.position = new Vector3(last_position - 0.3f, this.transform.position.y, this.transform.position.z);

                this.transform.position = new Vector3(203.76f + 5.0f, this.transform.position.y, this.transform.position.z);

            }

            else if (this.transform.position.x <= 203.76 - 4.5f)

            {

                //this.transform.position = new Vector3(last_position + 0.3f, this.transform.position.y, this.transform.position.z);

                this.transform.position = new Vector3(203.76f - 4.0f, this.transform.position.y, this.transform.position.z);

            }

        }

    }

}