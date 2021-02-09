using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Action : MonoBehaviour {

    public Text text;
    public string textSure;
    public bool activeAction = false;

    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Text_Intro").GetComponent<Text>();
        text.text = "";
        //gameObject.SetActive(false);
    }

    void Update ()
    {

		if(activeAction)
        {
            StartCoroutine(PrintText(5));
        }

        //Debug.Log(activeAction);

	}


    IEnumerator PrintText(float s)
    {
        text.text = textSure;
        yield return new WaitForSeconds(s);
        text.text = "";
        activeAction = false;
    }

}
