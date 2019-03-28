using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    Animator anim;
    public AnimTouchAPI animapi;
    public User user;
    public World world;
    public Article_inventory Article_Inventory;
    private float Time_;
    public BiologicaSystem bs;

    public void Start()
    {
        bs = GetComponent<BiologicaSystem>();
        AnimTouchAPI animapi = GetComponent<AnimTouchAPI>();

        
    }
    //tuoch code


}


