using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {
    Animator anim;
    public TaskData task;
    public Kant_1 test;
    public Kant_2 test2;

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

                if (task.BT[0].Schedule == 0)
                {
                    test.XLL(0);
                }
                else if (task.BT[0].Schedule == 1)
                {
                    test.XLL(1);

                }
                if (task.BT[0].Schedule == 2) {
                    test.XLL(2);
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


