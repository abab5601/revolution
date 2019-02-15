using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class map1 : MonoBehaviour {



    public GameObject gameObject;

    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<SceneSwitch>().switching(3);
            //SceneManager.LoadScene();


        }


    }
}
