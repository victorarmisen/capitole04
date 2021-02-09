using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraFading;

public class Fade_In : MonoBehaviour
{

    void Start()
    {
        CameraFade.Alpha = 1;
        CameraFade.In(5f);


    }


}
