using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A0 : MonoBehaviour {



    public void OnTriggerEnter(Collider other)
    {
        BiologicaSystem sd = other.gameObject.GetComponent<BiologicaSystem>();
        if (sd != null)
        { 
            sd.hp(-14);
        }
    }


}
