using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles_image : MonoBehaviour {

    public GameObject controles_;
    bool active = false;

    private void Start()
    {
        active = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowControls();
        }
    }

    public void ShowControls()
    {
        active = !active;
        controles_.SetActive(active);
    }
}
