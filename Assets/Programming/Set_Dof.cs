using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Set_Dof : MonoBehaviour {

    public Camera cam;
    DepthOfFieldModel.Settings dof = new DepthOfFieldModel.Settings();
    public bool level1, level2, level3, level4, level5, levelBoss;


    void Start ()
    {
        if (level1)
        {
            dof.aperture = 5.6f;
            dof.focalLength = 91;
            dof.focusDistance = 3.56f;
            cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.settings = dof;
        }

        if (level2)
        {
            dof.aperture = 4.3f;
            dof.focalLength = 91;
            dof.focusDistance = 4.96f;
            cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.settings = dof;
        }

        if (level3)
        {
            dof.aperture = 6.9f;
            dof.focalLength = 91;
            dof.focusDistance = 4.86f;
            cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.settings = dof;
        }

        if (level4)
        {
            dof.aperture = 5f;
            dof.focalLength = 122;
            dof.focusDistance = 4.81f;
            cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.settings = dof;
        }

        if (level5)
        {
            dof.aperture = 5f;
            dof.focalLength = 122;
            dof.focusDistance = 4.81f;
            cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.settings = dof;
        }


    }
	
	
}
