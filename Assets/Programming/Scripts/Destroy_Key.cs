using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Key : MonoBehaviour {

    public GameObject particles_roto;
    public AudioSource explosion;
    public bool Stage5_Explosion;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Transpalet")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            //Instantiate particles
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
            //Instantiate(particles_roto, transform.position, Quaternion.identity);
            if(Stage5_Explosion)
                explosion.Play();
        }
    }

}
