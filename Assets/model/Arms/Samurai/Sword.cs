using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    public Prop prop;
    private void Awake()
    {
        prop = GetComponent<Prop>();
       
    }
    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag=="player")
        { }
      else if(collision.gameObject.tag=="NPC")
        collision.gameObject.GetComponent<BiologicaSystem>().hp(-10);
    }
}
