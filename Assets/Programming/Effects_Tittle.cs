using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Effects_Tittle : MonoBehaviour
{
    public Camera cam;
    //DepthOfFieldModel.Settings dof = new DepthOfFieldModel.Settings();
    ChromaticAberrationModel.Settings ca = new ChromaticAberrationModel.Settings();

    //public float FOCUS, APERTURE, FOCAL;

    void Update()
    {
        //dof.focusDistance = 1.97f;
        //dof.aperture = 3.4f;
        //dof.focalLength = 91;

        //dof.focusDistance = FOCUS;
        //dof.aperture = APERTURE;
        //dof.focalLength = FOCAL;

        //ca.intensity = 1.0f;
        //cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = true;
        //cam.GetComponent<PostProcessingBehaviour>().profile.depthOfField.settings = dof;
        //cam.GetComponent<PostProcessingBehaviour>().profile.chromaticAberration.settings = ca;
    }


}
