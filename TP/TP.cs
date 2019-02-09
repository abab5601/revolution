using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour {

    public GameObject g;//user
    public GameObject y;//

    public void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.name == "E_user__")
        {
            y.gameObject.transform.position = g.gameObject.transform.position  ;


        }


    }

}
