using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    Animator anim;
    public TaskData taskData;
    public AnimTouchAPI animapi;
    public User user;
    public World world;
    public Article_inventory Article_Inventory;
    private float Time_;
    public BiologicaSystem bs;
    //public TaskData task;
    float a = 14;
    [Header("-----生物ID-----")]
    public int e;
    [Header("-----第x任務-----")]
    public int number;
    [Header("-----給予多少單位-----")]
    public int t;
    //status: 0=休息1=走2=跑3=受傷4=死亡
    //fighting:0=休息1=攻擊2=攻擊3=攻擊


    public void Update()
    {
        if (Time_ > 0)
        {
            Time_ -= Time.deltaTime;
        }
        else
        {
            Time_ = 0;
        }
        //Debug.Log();



    }
    public void OnDestroy() {

        if (world.DeathNotebook.Exists( x => x == e) )
        {
            taskData.BT[number].Conditions[0].Currently += t;

        }

    }
    public void Start()
    {
        bs = GetComponent<BiologicaSystem>();
        AnimTouchAPI animapi = GetComponent<AnimTouchAPI>();
        e = gameObject.GetInstanceID();
        
    }
    //tuoch code
    public void OnCollisionEnter(Collision s)
    {
        //status: 0=休息1=走2=跑3=受傷4=死亡
        animapi.passive = true;
    }

    private void OnCollisionStay(Collision s){

        bs = s.gameObject.GetComponent<BiologicaSystem>();

        if (bs != null && s.gameObject.tag == "Player" && Time_ == 0)
        {
            Time_ = 3;
            bs.hp(-25);
        }


        animapi.animcon("status", 0);
        animapi.passive = false;
    }

}


