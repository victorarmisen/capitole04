using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_Attack : MonoBehaviour
{

    public GameObject particles_prefab;

    private void OnCollisionEnter(Collision collision)
    {
        //Instanciamos particulas
        if(collision.gameObject.tag == "Soil" || collision.gameObject.tag == "Player")
            Instantiate(particles_prefab, collision.contacts[0].point, new Quaternion(0,-90,0,1));
        if (collision.gameObject.tag == "Player")
        {
            player_stats.live -= 60;
            Destroy(this.gameObject);          
        }
        if(collision.gameObject.tag == "Soil")
        {
            Destroy(this.gameObject);
        }
    }


}
