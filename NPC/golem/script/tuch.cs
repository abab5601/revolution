using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuch : MonoBehaviour {

    Animator anim;
    Animation add;
    public BLMFOD_1 test;
    public TaskData task;
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

        //status: 0=休息1=走2=跑3=受傷4=死亡
        if (collision.gameObject.name == "E_user__")
        {

            test.XLL(0);



        }



    }


}
