﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {
    Animator anim;
    public TaskData task;
    public Kant_1 test;
    public T1 t1;
    public BLMFOD_1 BL;
    Animation add;
    public int HP;
    public bool haha;

    void Start () {

        anim = GetComponent<Animator>();
        test = GetComponent<Kant_1>();
        t1 = GetComponent<T1>();
        BL = GetComponent<BLMFOD_1>();
        HP = 5;
    }


    public void OnCollisionEnter(Collision collision)
    {
        //status: 0=休息1=走2=跑3=受傷4=死亡
        switch (collision.gameObject.name)
        {
            case "E_user__":
                

                    //任務1
                    if (task.BT[0].Schedule == 0)
                    {
                        test.XLL(0);
                        task.BT[0].Schedule = 1;
                        t1.tt1();

                    }
                    else if (task.BT[0].Conditions[0].Currently >= task.BT[0].Conditions[0].Max)
                    {
                        test.XLL(2);
                        task.BT[0].Schedule = 2;

                }
                    else if (task.BT[0].Schedule == 1)
                    {
                        test.XLL(1);
                        task.BT[0].Schedule = 1;


                    }

                if (task.BT[1].Schedule >= 2)
                {
                    test.win2();
                    haha = true;
                } else if (haha ==true) {
                    test.win3();
                }

                







                    break;

            case "FloorPlane":
                animcon("status", 3);
                //檢查死亡
                die(HP);
                break;

            default:
                Debug.Log("錯誤碰撞");
                break;
        }

    }
    public void OnCollisionExit(Collision collision)
    {
        haha = false;
    }


    void animcon(string name,int x) {
        anim.SetInteger(name, x);
        if (haha == false) {
            anim.SetInteger(name, x);
        }
    }
    void die(int x)
    {
        if (x < 0)
        {
            animcon("status", 3);
            Destroy(gameObject,5);
        }
    }
}


