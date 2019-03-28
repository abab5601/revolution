using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class AnimTouchAPI : MonoBehaviour {
    public bool passive;
    public GameObject money_;
    public GameObject Atk;
    private int income;

    //OnCollisionEnter & OnCollisionExit;
    //passive true & false;
    Animator anim;
    Rigidbody con;

    [Header("-----開發者選項-----")]
    public int hp;
     public string namee;
    public User user;
    //public BiologicaSystem BS;
    void Start()
    {
        //BS = GetComponents<BiologicaSystem>();
        anim = GetComponent<Animator>();
        con = GetComponent<Rigidbody>();

        MonterData MD = new MonterData(10, "我是任務", 3, 5);
        //task.name[2] = MD.MonsterName;


    }


    //status: 0=休息1=走2=跑3=受傷4=死亡
    //
    //fighting:0=休息1=攻擊2=攻擊3=攻擊
    //animcon
    public void animcon(string name, int x)
    {
        anim.SetInteger(name, x);
        //anim.SetInteger(name, 0);  
    }
    public void die() {

        anim.SetInteger("status", 4);

        Destroy(gameObject,3);
    }
    void money()
    {
        income = 10;
        Instantiate(money_, transform.position, new Quaternion(90, 90, 0, 0));

    }


}
