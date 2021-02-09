using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public int Level;
    public Camera cam;
    //public PostProcessingProfile post;
    //VignetteModel.Settings newSettigns = new VignetteModel.Settings();
    public bool Enter;
    public bool Out;

    void Start ()
    {

        //Camera ob = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //cam = ob;

        //if (Enter)
        //{
        //    newSettigns.intensity = 1.0f;
        //}
        //if (Out)
        //{
        //    newSettigns.intensity = 0.0f;
        //}

        //newSettigns.smoothness = 1;
        //newSettigns.roundness = 1;
        //newSettigns.center = new Vector2(-0.24f, 0.0f);
        //cam.GetComponent<PostProcessingBehaviour>().profile.vignette.settings = newSettigns;
        //cam.GetComponent<PostProcessingBehaviour>().profile.vignette.enabled = true;

    }
	
	void Update ()
    {
        if (Enter)
        {
            //if (newSettigns.intensity > 0.01f)
            //{
            //    newSettigns.intensity -= 0.01f;
            //    cam.GetComponent<PostProcessingBehaviour>().profile.vignette.settings = newSettigns;
            //}
            //else
            //{
            //    newSettigns.intensity = 0.01f;
            //    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessingBehaviour>().profile.vignette.settings = newSettigns;
            //    Destroy(this);
            //}
        }

        if (Out)
        {
            //if (newSettigns.intensity < 1.0f)
            //{
            //    newSettigns.intensity += 0.01f;
            //    cam.GetComponent<PostProcessingBehaviour>().profile.vignette.settings = newSettigns;
            //}
            //else
            //{
            //    newSettigns.intensity = 1.0f;
            //    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessingBehaviour>().profile.vignette.settings = newSettigns;
            //    SceneManager.LoadScene(Level);
            //    Destroy(this);
            //}
            SceneManager.LoadScene(Level);
        }


    }

}
