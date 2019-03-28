using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword : MonoBehaviour
{

    private AudioSource m_AudioSource;

    public Prop prop;
    private void Awake()
    {
        prop = GetComponent<Prop>();
       
    }
    // Use this for initialization
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();


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

        m_AudioSource.Play();

    }
}
