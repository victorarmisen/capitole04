﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boquete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(),
                gameObject.GetComponent<Collider>());
        }
    }

}
