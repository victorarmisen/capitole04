using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura_Poner : MonoBehaviour {

    public GameObject textFinal;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Activamos animacion de armadura: Aumentamos la luz de fosforescencia y la volvemos a bajar
            //Texto de entrada_: Tienes armadura capitole
            Instantiate(textFinal, transform.position, Quaternion.identity);
            //Activamos animacion de puesta de armadura.
            //Instanciamos tambien la imagen de referencia de capitole
            //Instantiate image or sprite -> Gameobject
            //Armadura en la posicion del jugador: Como la pegamos
            //Establecemos un posicion donde estara la armadura en el erizo.

            transform.SetParent(col.gameObject.transform);
            foreach(Transform child in col.gameObject.transform)
            {
                if(child.name == "Armadura_Posicion")
                {
                    transform.position = child.gameObject.transform.position;
                }
            }

            

            gameObject.GetComponent<Armor_Rotate>().enabled = false;

            //Hacemos la accion de pasar a la siguiente escena con el fade.

            

        }

    }

}
