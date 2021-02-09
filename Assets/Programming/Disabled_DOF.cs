using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Disabled_DOF : MonoBehaviour
{
    public PostProcessingProfile profile;
    void Start()
    {
        profile.depthOfField.enabled = false;
    }


}
