using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class map1 : MonoBehaviour {





    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.name == "E_user__")
        {
            SceneManager.LoadScene(2);


        }


    }
}
