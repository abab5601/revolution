using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class map1 : MonoBehaviour {


    public SceneSwitch @object;

    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            @object.gameObject.SetActive(true);
            @object.switching(3);

        }


    }
}
