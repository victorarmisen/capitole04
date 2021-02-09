using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Prueba : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().SetBool("Idle", true);
    }

    void Update()
    {
        
    }
}
