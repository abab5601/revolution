using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuch : MonoBehaviour {

    Animator anim;
    Animation add;
    public BLMFOD_1 test;
    public int HP;
    public bool haha;
    //布魯姆菲爾德 = BLMFOD

    void Start()
    {
            
        anim = GetComponent<Animator>();
        add = GetComponent<Animation>();
        test = GetComponent<BLMFOD_1>();
        HP = 10;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //status: 0=休息1=走2=跑3=受傷4=死亡
        if (collision.gameObject.name == "E_user__")
        {
            test.XLL(0);
            //anim.SetInteger("status", 1);
            Debug.Log("你點到我了or你碰到我呃");
        }

        if (collision.gameObject.name == "FloorPlane")
        {
            anim.SetInteger("status", 3);
            HP++;
            Debug.Log(collision.gameObject.name);
            //HP--;
        }

        //死亡
        if (HP < 0)
        {
            anim.Play("hit");
        }
        haha = true;

    }
    public void OnCollisionExit(Collision collision)
    {

        haha = false;
    }


}
