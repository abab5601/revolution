using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    Animator anim;
    public AnimTouchAPI animapi;
    
    //public TaskData task;

    //status: 0=休息1=走2=跑3=受傷4=死亡
    //fighting:0=休息1=攻擊2=攻擊3=攻擊


    public void Start()
    { 
        AnimTouchAPI animapi = GetComponent<AnimTouchAPI>();
    }

    //tuoch code
    public void OnCollisionEnter(Collision collision)
    {
        //status: 0=休息1=走2=跑3=受傷4=死亡
        Debug.Log(collision.gameObject.name);
        switch (collision.gameObject.name)
        {

            case "E_user__":

                animapi.animcon("status", 3);
                animapi.hp--;
                Instantiate(animapi.Atk, transform.position, new Quaternion(90, 90, 0, 0));
                if (animapi.hp <= 0)
                {
                    animapi.die();
                    animapi.task.BT[0].Conditions[0].Currently += 1;
                }
                break;


            case "0(Clone)":

                animapi.animcon("status", 3);
                animapi.hp--;
                Instantiate(animapi.Atk, transform.position, new Quaternion(90, 90, 0, 0));
                if (animapi.hp <= 0)
                {
                    animapi.die();
                }
                break;
        }

        animapi.passive = true;
    }
    public void OnCollisionExit(Collision collision)
    {
        animapi.animcon("status", 0);
        animapi.passive = false;
    }

}

