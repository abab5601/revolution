using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {
    Animator anim;
    public Kant_1 test;
    Animation add;
    public int HP;
    public bool haha;

    void Start () {

        anim = GetComponent<Animator>();
        test = GetComponent<Kant_1>();
        HP = 5;
    }


    public void OnCollisionEnter(Collision collision)
    {
        //status: 0=休息1=走2=跑3=受傷4=死亡
        switch (collision.gameObject.name)
        {
            case "E_user__":
                test.XLL(0);
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


