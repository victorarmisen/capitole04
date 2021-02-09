using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class Entrada_Erizo : MonoBehaviour {

    public GameObject player, cam, camera_lejos;
    private Animator anim;

    public Transform zoom_pos, initial_cam;

    private float timeCount = 0.0f;
    private float timeCount2 = 0.0f;
    private float timer = 3.0f;

    private Vector3 original;
    public static Quaternion iz, de;

    public GameObject viñeta, tittle, effects; /*effects*/
    private Vector3 O_Pos;
    private float SmoothSpeed = 0.125f;
    private float t = 0.0f;

    private float journeyTime = 100.0f;
    private float startTime;

    private float frac2;
    public static bool go, back;
    private bool Once = true;

    public bool Enemy = false;

    public string enemy_name;
    public GameObject own_enemy;
    //public GameObject particles_cinematic;
    public bool objeto_inanimado;

    //Sound
    public AudioSource shine, enemy_sound, erizo_llegada;

    private void Start()
    {
        //if(!Enemy)
        //    door.GetComponent<Rigidbody>().AddForce(-Vector3.forward * Random.Range(1, 5000), ForceMode.Force);
        anim = player.GetComponent<Animator>();
        cam.GetComponent<Camera_Follow>().enabled = false;
        O_Pos = cam.transform.position;
        startTime = Time.time;
        frac2 = 0.0f;
        go = true;
        back = false;

        player.transform.localEulerAngles = new Vector3(0, 180, 0);

        viñeta.SetActive(false);
        tittle.SetActive(false);
        effects.SetActive(false);

    }

    private void Update()
    {
        if(go)
        {
            float fracComplete = (Time.time - startTime) / journeyTime;
            if (Enemy)
            {
                cam.transform.position = Vector3.Slerp(cam.transform.position, zoom_pos.position - new Vector3(0,0,2), fracComplete);
                anim.Play("Idle");
                EffectsDisabled();
            }
            else
            {
                cam.transform.position = Vector3.Slerp(cam.transform.position, zoom_pos.position, fracComplete);
                player_movement.CAN_MOVE = false;
                EffectsDisabled();
            }
        }

        if(!Enemy)
        {
            if (Vector3.Distance(cam.transform.position, player.transform.position) < 2.85f) 
            {

                go = false;
                back = true;

                //viñeta.SetActive(true);
                //tittle.SetActive(true);
                effects.SetActive(true);
                //light_cinematic.SetActive(true);
                //particles_cinematic.SetActive(true);
                player_movement.CAN_MOVE = false;

                //cam.GetComponent<CameraShake>().Ad
                if (Once)
                {
                    //GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                    //shine.Play();
                    Once = false;
                }
        
            }
        }
        else
        {
            if (Vector3.Distance(cam.transform.position, zoom_pos.transform.position - new Vector3(0, 0, 2)) < 0.5f)
            {

                go = false;
                back = true;
                if (!objeto_inanimado)
                    own_enemy.transform.LookAt(cam.transform);

                //viñeta.SetActive(true);
                //tittle.SetActive(true);
                //tittle.GetComponent<Text>().text = enemy_name;
                player_movement.CAN_MOVE = false;
                if(!objeto_inanimado)
                    own_enemy.GetComponent<Enemy_Stage1>().speed = 0.0f;
                effects.SetActive(true);
    

                //cam.GetComponent<CameraShake>().Ad
                if (Once)
                {
                    //GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraShake>();
                    if(!objeto_inanimado)
                        enemy_sound.Play();
                    else shine.Play();
                    Once = false;
                }

            }
        }
       

        if (back)
        {
            if(!Enemy)
            {
                timer -= Time.deltaTime;

                if (timer < 0.0f)
                {
                    //viñeta.SetActive(false);
                    //tittle.SetActive(false);
                    effects.SetActive(false);
                    //light_cinematic.SetActive(false);
                    //particles_cinematic.SetActive(false);

                    float frac2 = (Time.time - startTime) / journeyTime;
                    cam.transform.position = Vector3.Slerp(cam.transform.position, initial_cam.position, frac2);

                    float distance = Vector3.Distance(cam.transform.position, initial_cam.position);

                    if (distance < 1.0f)
                    {
                        player.transform.position -= Vector3.forward * 4.5f;
                        erizo_llegada.Play();
                        player.transform.eulerAngles += new Vector3(0, -90, 0);
                        cam.GetComponent<Camera_Follow>().enabled = true;
                        player_movement.CAN_MOVE = true;
                        //cam.transform.GetChild(0).GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;                    
                        EffectsDisabled();
                        
                        Destroy(this);
                    }
                }
            } 
            else
            {
                timer -= Time.deltaTime;

                if (timer < 0.0f)
                {
                    //viñeta.SetActive(false);
                    //tittle.SetActive(false);
                    effects.SetActive(false);

                    float frac2 = (Time.time - startTime) / journeyTime;
                    cam.transform.position = Vector3.Slerp(cam.transform.position, Camera_Follow.addition.transform.position, frac2);

                    //X: -12.786
                    //Y: -0.8253467
                    //Z: -4.8

                    float distance = Vector3.Distance(cam.transform.position, Camera_Follow.addition.transform.position);

                    if (distance < 1.0f)
                    {
                        //Debug.Log("ACTIVATE");
                        //player.transform.position -= Vector3.forward * 4.5f;
                        //player.transform.eulerAngles += new Vector3(0, -90, 0);
                        cam.GetComponent<Camera_Follow>().enabled = true;
                        //cam.transform.GetChild(0).GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;
                        if (!objeto_inanimado)
                            own_enemy.GetComponent<Enemy_Stage1>().speed = 1.0f;
                        player_movement.CAN_MOVE = true;
                        EffectsDisabled();
                        effects.SetActive(false);
                        Destroy(this);
                    }
                }


            }
            

        }

    }


    void EffectsDisabled()
    {
        ////cam.transform.GetChild(0).GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;
        //ChromaticAberrationModel.Settings ca = new ChromaticAberrationModel.Settings();
        //ca.intensity = 0.35f;
        //cam.transform.GetChild(0).GetComponent<PostProcessingBehaviour>().profile.chromaticAberration.settings = ca;
    }

 
   

}
