using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHp : MonoBehaviour {
    public int HP ;
    private void OnCollisionEnter(Collision collision)
    {
        BiologicaSystem biologicaSystem = collision.gameObject.GetComponent<BiologicaSystem>();
        if (biologicaSystem != null)
            biologicaSystem.hp(-HP);
    }
    private void OnTriggerEnter(Collider other)
    {
        BiologicaSystem biologicaSystem = other.gameObject.GetComponent<BiologicaSystem>();
        if (biologicaSystem != null)
            biologicaSystem.hp(-HP);
    }
}
